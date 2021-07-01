using OverlayPlayer.gl;
using OverlayPlayer.Key;
using OverlayPlayer.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayPlayer
{
    class Menu : IDisposable
    {
        const int PAGE_SIZE = 9;

        IEnumerable<AMenuItem> mItems;
        glMenu mGlMenu = null;
        IEnumerable<Guid> mHotkeyIds;
        int mCurrentPage;

        public Menu(IEnumerable<AMenuItem> items)
        {
            mItems = items;
            InitMenu(0);
        }

        void InitMenu(int pageNumber)
        {
            if (mItems.Count() > PAGE_SIZE)
            {
                bool pageUp = pageNumber > 0;
                bool pageDown = mItems.Count() > PAGE_SIZE * (pageNumber + 1);

                var itemsToShow = mItems
                    .Skip(pageNumber * PAGE_SIZE)
                    .Take(PAGE_SIZE);

                InitScopedMenu(itemsToShow, pageUp, pageDown);
            }
            else
            {
                InitScopedMenu(mItems, false, false);
            }
        }

        void InitScopedMenu(IEnumerable<AMenuItem> items, bool pageUp, bool pageDown)
        {
            UnregisterMenu();
            IEnumerable<AMenuItem> itemsToShow = items.ToArray();
            List<Guid> registeredKeys = new List<Guid>();

            if (pageUp)
            {
                itemsToShow = itemsToShow.Concat(new AMenuItem[] { new PlaceboItem() { Caption = "PgUp. Prev Page"} });
                var keyId = HotKeyManager.RegisterHotKey(Keys.PageUp, KeyModifiers.None, HandleHotkey);
                registeredKeys.Add(keyId);
            }

            if (pageDown)
            {
                itemsToShow = itemsToShow.Concat(new AMenuItem[] { new PlaceboItem() { Caption = "PgDown. Next Page"} });
                var keyId = HotKeyManager.RegisterHotKey(Keys.PageDown, KeyModifiers.None, HandleHotkey);
                registeredKeys.Add(keyId);
            }

            mGlMenu = new glMenu(itemsToShow);

            int current = 1;
            foreach (var item in items)
            {
                var keyId = HotKeyManager.RegisterHotKey((Keys)(Keys.D0 + current), KeyModifiers.None, HandleHotkey);
                registeredKeys.Add(keyId);
                current++;
            }

            mHotkeyIds = registeredKeys;
        }

        void HandleHotkey(Keys key, KeyModifiers modifiers)
        {
            if (key >= Keys.D1 && key <= Keys.D9)
            {
                int itemNumber = (int)(key - Keys.D1);
                if (itemNumber >= 0 && itemNumber < mGlMenu.Items.Count())
                {
                    var item = mGlMenu.Items.ElementAt(itemNumber);
                    if (item.SubItems != null && item.SubItems.Any())
                    {
                        mItems = item.SubItems;
                        InitMenu(0);
                    }
                    else
                        UnregisterMenu();

                    item.Execute();
                }
            }
            else if (key == Keys.PageDown)
            {
                InitMenu(++mCurrentPage);
            }
            else
            {
                InitMenu(--mCurrentPage);
            }
        }

        void UnregisterMenu()
        {
            if (mGlMenu != null)
                mGlMenu.Dispose();

            if (mHotkeyIds != null && mHotkeyIds.Any())
                foreach (var key in mHotkeyIds)
                    HotKeyManager.UnregisterHotKey(key);

            mHotkeyIds = null;
        }

        public void Dispose()
        {
            UnregisterMenu();
        }
    }
}
