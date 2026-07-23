# Flowy Todo Spec

## Overview
A single-page, browser-based todo list app ("Flowy Todo" / 让每一天都井井有条), implemented as one self-contained HTML file (`index.html`) with inline CSS and JavaScript — no build step or external dependencies.

## Goals
- Add, complete, and delete todo items.
- Tag each item with a category and an optional due date/time.
- Filter the list by status (all / active / done).
- Persist todos across browser sessions via `localStorage`.

## Non-Goals
- No accounts, sync, or backend — single browser, single device.
- No editing of an existing item's text/tag/due date after creation (delete and re-add instead).
- No reordering (drag-and-drop) or sub-tasks.
- No notifications/reminders for due dates — the due date is display-only.

## Data Model
Each todo is stored as:
```js
{ id: Number, text: String, tag: "个人" | "工作" | "健康", due: String (datetime-local ISO or ""), done: Boolean }
```
- `id` is generated from `Date.now()`.
- All todos are persisted as a JSON array under `localStorage` key `todos-v2`.
- New todos are inserted at the front of the list (most recent first).

## UI Components
- **Header**: gradient app icon (✓), "Flowy Todo" gradient-text title, subtitle "让每一天都井井有条".
- **Stats row**: three cards — 全部任务 (total), 进行中 (active), 已完成 (done) — counts update live from the full todo list regardless of the active filter.
- **Add panel**:
  - Text input ("添加新任务...", max 100 chars) + circular "+" submit button.
  - Tag chips: 个人 (default active) / 工作 / 健康 — single-select, determines the new item's tag.
  - Due date/time picker (`<input type="datetime-local">`), optional.
- **Filter bar**: 全部 / 进行中 / 已完成 — single-select tab group; the active tab is highlighted.
- **Todo list**: one card per item, each with:
  - Circular checkbox (toggles done; shows a ✓ and fills purple when checked).
  - Task text (strikethrough + muted color when done).
  - Meta row: tag badge (color-coded per tag; replaced by a neutral "已完成" badge once done) and a formatted due-date label, if set.
  - "✕" delete button.
- **Empty state**: "还没有待办事项，添加一个吧～" when there are no todos at all, or "这里空空如也" when the current filter has no matches.
- **Footer**: "用❤打造，让生活更美好".

## Behavior Details
- Submitting is via clicking "+" or pressing Enter in the text input; whitespace-only text is ignored (`trim()` check).
- After adding, the input and due-date picker are cleared and focus returns to the text input.
- The selected tag chip and filter tab persist only for the current page session (not saved to `localStorage`); the tag chip resets to 个人 on reload.
- Due-date formatting (`formatDue`): shows "今天 · 下午3:00" / "明天 · ..." / "昨天 · ..." for ±1 day from today, otherwise "M月D日 · ...", using 12-hour 上午/下午 time.
- Toggling or deleting an item immediately re-renders the list and stats and re-saves to `localStorage`.
- Completed items show only the "已完成" badge in place of their tag/due-date meta.

## Visual Design
- Soft light gradient background (lavender → pink, top to bottom), centered card layout (max-width 420px).
- White rounded cards with soft purple-tinted shadows (`rgba(124, 110, 242, 0.06–0.12)`) for stat cards, add panel, filter bar, and todo items.
- Purple/magenta gradient (`--purple` #7c6ef2 → `--purple-2` #c86edb) used for the brand icon, gradient title text, primary "+" button, and checked checkboxes.
- Color-coded tags: 工作 = blue (#3b82f6 on light blue), 个人 = pink (#ec4899 on light pink), 健康 = green (#16a34a on light green); done badge uses neutral gray.
- Stat numbers colored purple (total), coral (active), green (done).
- Rounded pill-style buttons/inputs throughout (chips, filter tabs, due-date input).
- New todo items fade/slide in (`fadeIn` keyframe: opacity + translateY).

## Technical Notes
- Single file: `index.html` (HTML + `<style>` + `<script>`, no external assets or libraries).
- State kept in plain JS: `todos` (array, loaded from/saved to `localStorage`), `currentFilter`, `currentTag`.
- List re-rendered from state on every change (`render()`); DOM nodes built imperatively, no framework.
- `Frame.png` is the visual design reference the implementation is matched against.

## File Structure
```
my-todo/
├── index.html   # app (markup, styles, logic)
├── Frame.png    # visual design reference
└── spec.md      # this document
```
