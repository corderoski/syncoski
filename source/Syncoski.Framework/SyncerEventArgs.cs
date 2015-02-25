﻿using System;

namespace Syncoski.Framework
{
    public class SyncerEventArgs : EventArgs
    {
        public SyncerWatcherAction ActionType { get; set; }
        public String Item { get; set; }
        public String OldItem { get; set; }

    }

    public enum SyncerWatcherAction
    {
        // Summary:
        //     The creation of a file or folder.
        Created = 1,
        //
        // Summary:
        //     The deletion of a file or folder.
        Deleted = 2,
        //
        // Summary:
        //     The change of a file or folder. The types of changes include: changes to
        //     size, attributes, security settings, last write, and last access time.
        Changed = 4,
        //
        // Summary:
        //     The renaming of a file or folder.
        Renamed = 8,
    }
}