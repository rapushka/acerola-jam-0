using System;
using System.Linq;
using UnityEngine;

namespace Code
{
	public class HoldersProvider : MonoBehaviour
	{
		[field: SerializeField] public Transform Deck        { get; private set; }
		[field: SerializeField] public Transform DefaultLens { get; private set; }
		[field: SerializeField] public Transform BurnCard    { get; private set; }
		[field: SerializeField] public Transform BurnLoupe   { get; private set; }
		[field: SerializeField] public Transform BurnedCard  { get; private set; }

		[SerializeField] private SideHolders[] _sides;

		public SideHolders this[Side side] => _sides.Single((sh) => sh.Side == side);

		[Serializable]
		public class SideHolders
		{
			[field: SerializeField] public Side      Side            { get; private set; }
			[field: SerializeField] public Transform Hand            { get; private set; }
			[field: SerializeField] public Transform CandidateCard   { get; private set; }
			[field: SerializeField] public Transform CandidateLense  { get; private set; }
			[field: SerializeField] public Transform ShadowCardSpawn { get; private set; }
		}
	}
}