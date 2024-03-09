using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class TabsSystem : MonoBehaviour
	{
		[SerializeField] private List<Tab> _tabs;

		private readonly List<GameObject> _pages = new();

		private void Start()
		{
			foreach (var tab in _tabs)
			{
				_pages.Add(tab.Page);
				tab.Button.onClick.AddListener(() => OpenPage(tab.Page));
			}
		}

		private void OpenPage(GameObject target)
		{
			foreach (var page in _pages)
				page.SetActive(false);

			target.SetActive(true);
		}

		private void OnDestroy()
		{
			foreach (var tab in _tabs)
				tab.Button.onClick.RemoveListener(() => OpenPage(tab.Page));

			_pages.Clear();
		}

		[Serializable]
		private class Tab
		{
			[field: SerializeField] public Button     Button { get; private set; }
			[field: SerializeField] public GameObject Page   { get; private set; }
		}
	}
}