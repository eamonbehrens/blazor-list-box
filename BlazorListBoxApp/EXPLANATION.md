# DynamicListBox Component Explanation

## Component Architecture

The DynamicListBox component manages items through a dual-mode approach: it accepts both a data-bound 
`Items` collection and declarative `ChildContent` markup. The parent component (`DynamicListBox.razor`)
maintains a `List<ListBoxItemData>` that tracks all items and their state.

## Selection Handling

Selection is managed via two-way binding using `@bind-SelectedValue`.
When a child `DynamicListBoxItem` is clicked, it invokes an `EventCallback` 
that updates the parent's `SelectedValue` property and triggers `SelectedValueChanged`
to notify the consuming page. The selected item receives a distinct CSS class for visual
feedback.

## UI Synchronization

UI sync is achieved through explicit `StateHasChanged()` 
calls after modifying the Items collection. When removing an item,
the component sets a `removingItemValue` flag, calls `StateHasChanged()`
to apply the blue CSS class, awaits `Task.Delay(1000)`
for the one-second visual feedback (no JavaScript required),
then removes the item and calls `StateHasChanged()` again to refresh the UI.

## Sizing Implementation

The component accepts `Width` and `Height` parameters (default "300px" and "200px") 
and applies them via inline styles on the container div. CSS `overflow-y: auto` 
enables vertical scrolling when content exceeds the specified height, 
providing a native scrollbar without any JavaScript intervention.

## Database Persistence

The demo page loads initial items from a SQL Server database via 
Entity Framework Core, mapping `ListBoxItemModel` entities to `ListBoxItemData`
view models. Add/Remove operations persist to the database immediately via 
`DbContext.SaveChangesAsync()`, ensuring data survives application restarts.

