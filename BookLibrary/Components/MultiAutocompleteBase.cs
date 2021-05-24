using MatBlazor;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Components
{
    public class MultiAutocompleteBase<TItem> : BaseMatDomComponent
    {
        protected const int DefaultsElementsInPopup = 10;
        private bool isOpened;
        private string stringValue;
        private ICollection<TItem> _value;
        private AutocompleteListSearchResult<TItem> searchResult;
        public MatList ListRef;

        protected IEnumerable<MatAutocompleteListItem<TItem>> GetFilteredCollection(string searchText)
        {
            if (searchResult == null || searchResult.SearchText != searchText || searchResult.Items != Items)
            {
                searchResult = new AutocompleteListSearchResult<TItem>()
                {
                    SearchText = searchText,
                    //  deepcode ignore CSharpSelfAssignment: <Property is set for new AutocompleteListSearchResult>
                    Items = Items,
                    ListResult = Items.Select(x => new MatAutocompleteListItem<TItem>()
                    {
                        StringValue = ComputeStringValue(x),
                        Item = x
                    })
                        .Where
                        (
                            x => x != null
                                 && (string.IsNullOrEmpty(searchText)
                                     || x.StringValue.ToLowerInvariant().Contains(searchText.ToLowerInvariant())
                                     )
                                 )
                        .Take(NumberOfElementsInPopup ?? DefaultsElementsInPopup)
                        .ToList()
                };
            }
            return searchResult.ListResult;
        }

        protected IEnumerable<MatAutocompleteListItem<TItem>> GetAutocompleteItems()
        {
            return Value.Select(i => new MatAutocompleteListItem<TItem>
            {
                StringValue = ComputeStringValue(i),
                Item = i
            });
        }

        protected bool IsShowingClearButton
        {
            get => ShowClearButton && !string.IsNullOrEmpty(this.StringValue);
        }

        public bool IsOpened
        {
            get => isOpened;
            private set
            {
                isOpened = value;
                OnOpenedChanged.InvokeAsync(value);
                StateHasChanged();
            }
        }

        /// <summary>
        /// Maximum number of elements displayed in the popup
        /// </summary>
        [Parameter]
        public int? NumberOfElementsInPopup { get; set; }

        /// <summary>
        /// The label of the TextField
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// The Icon displayed as the leading icon for the TextField
        /// </summary>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// The StringValue displayed in the TextField
        /// </summary>
        [Parameter]
        public string StringValue
        {
            get => stringValue;
            set
            {
                stringValue = value;
                OnTextChanged.InvokeAsync(value);
            }
        }

        /// <summary>
        /// The value to be used to pre-select an item from the list
        /// </summary>
        [Parameter]
        public ICollection<TItem> Value
        {
            get => _value;
            set
            {
                if (value == null || _value != null && Enumerable.SequenceEqual(value, _value))
                {
                    return;
                }

                _value = value;
                ValueChanged.InvokeAsync(_value);
            }
        }

        /// <summary>
        /// ValueChanged is fired when the value is selected(by clicking on an element in the popup)
        /// </summary>
        [Parameter]
        public EventCallback<ICollection<TItem>> ValueChanged { get; set; }

        /// <summary>
        /// ItemTemplate is used to render the elements in the popup if no template is given then the string value of the objects is displayed..
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        /// <summary>
        /// This function is used to select the string part from the item, used both for filtering and displaying if no ItemTemplate is defined.
        /// </summary>
        [Parameter]
        public Func<TItem, string> CustomStringSelector { get; set; }

        /// <summary>
        /// The collection which should be rendered and filtered
        /// </summary>
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        /// <summary>
        /// If this parameter is true then the style of the textbox is outlined see `MatTextfield`
        /// </summary>
        [Parameter]
        public bool Outlined { get; set; }

        /// <summary>
        /// OnOpenedChanged is fired when the popup dialog is opened or close and the parameter indicates whenever is it open, the default value is false
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnOpenedChanged { get; set; }

        /// <summary>
        /// OnTextChanged is fired when the string value is changed(when an input occurs in the textfield or when an item is selected)
        /// </summary>
        [Parameter]
        public EventCallback<string> OnTextChanged { get; set; }

        /// <summary>
        /// This value indicates if the clear button(using a trailing icon) should be displayed, which can clear the entire text and the selected value), the default value is false
        /// </summary>
        [Parameter]
        public bool ShowClearButton { get; set; }

        /// <summary>
        /// This value indicates if the textfield and the dialog will be or not displayed in the full screen, the default value is false
        /// </summary>
        [Parameter]
        public bool FullWidth { get; set; }

        protected void OpenPopup()
        {
            IsOpened = true;
        }

        protected void ClosePopup()
        {
            StringValue = string.Empty;
            IsOpened = false;
        }

        public void OnValueChanged(ChangeEventArgs ev)
        {
            StringValue = (string)ev.Value;
            StateHasChanged();
        }

        public async Task OnKeyDown(KeyboardEventArgs ev)
        {
            if (ev.Key == null ||   // Google auto-fill sends null key
                ev.Key == "Tab")    // user navigates to next field
            {
                return;
            }
            int currentIndex = await ListRef.GetSelectedIndex();
            bool wasCurrentIndexChanged = false;

            if (currentIndex < 0)
            {
                currentIndex = 0;
                wasCurrentIndexChanged = true;
            }

            if (searchResult != null && searchResult.ListResult.Count > 0 && currentIndex > searchResult.ListResult.Count)
            {
                currentIndex = searchResult.ListResult.Count - 1;
                wasCurrentIndexChanged = true;
            }

            switch (ev.Key)
            {
                case "ArrowDown":
                    currentIndex++;
                    wasCurrentIndexChanged = true;
                    break;
                case "ArrowUp":
                    currentIndex--;
                    wasCurrentIndexChanged = true;
                    break;
            }

            if (wasCurrentIndexChanged)
            {
                await ListRef.SetSelectedIndex(currentIndex);
            }

            if (ev.Key == "Enter" && searchResult != null && currentIndex >= 0 && currentIndex < searchResult.ListResult.Count)
            {
                ItemSelected(searchResult.ListResult[currentIndex].Item);
            }
        }

        public void ItemSelected(TItem selectedObject)
        {
            if (Value.Contains(selectedObject))
            {
                return;
            }

            Value.Add(selectedObject);
            StateHasChanged();
        }

        public void ItemRemoved(TItem item)
        {
            if (!Value.Contains(item))
            {
                return;
            }
            Value.Remove(item);
            StateHasChanged();
        }

        /// <summary>
        /// Clears current value of the autocomplete text
        /// </summary>
        /// <param name="e"></param>
        public void ClearText(EventArgs e)
        {
            Value = default;
            StringValue = string.Empty;
            StateHasChanged();
        }

        protected ClassMapper WrapperClassMapper = new ClassMapper();

        public MultiAutocompleteBase()
        {
            WrapperClassMapper
                .Add("mat-autocomplete-list")
                .Add("mat-autocomplete-list-wrapper")
                .If("mat-autocomplete-list-wrapper-fullwidth", () => FullWidth);
        }

        private string ComputeStringValue(TItem obj)
        {
            return CustomStringSelector?.Invoke(obj) ?? obj?.ToString();
        }
    }
}
