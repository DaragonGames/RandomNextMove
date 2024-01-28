using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkbenchDrawer : InteractableObject
{
    public DrawerPuzzle drawerPuzzle;
    public int drawerID;
    protected override void TryInteraction(InteractableObject obj) {}
    protected override void TryUsage() {
        drawerPuzzle.InteractWithDrawer(drawerID);
    }
}
