using System;
using helper;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

namespace inventory.ui.grid.test_helper
{
	public class Helper_spawn_item: chibi.Chibi_ui
	{
		public GameObject item;
		public inventory.ui.grid.item.Item_ui_grid item_ui;
    }
}
