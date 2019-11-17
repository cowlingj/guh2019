using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMenu : MonoBehaviour
{
    public SubMenu subMenu;
    public void ActivateSubMenu() {
        subMenu.Activate();
    }
}
