using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;
using Task = UnityEditor.VersionControl.Task;

public interface ISaveData{
    public Guid ID{ get; }

    public void TryLoadData();
    public void Save();
}
