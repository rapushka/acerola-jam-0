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

		[field: SerializeField] public CameraHolders Camera { get; private set; }

		[field: SerializeField] public LampHolders Lamp { get; private set; }

		[field: SerializeField] public Transform Bank { get; private set; }

		public SideHolders this[Side side] => _sides.Single((sh) => sh.Side == side);

		[Serializable]
		public class SideHolders
		{
			[field: SerializeField] public Side      Side            { get; private set; }
			[field: SerializeField] public Transform Hand            { get; private set; }
			[field: SerializeField] public Transform CandidateCard   { get; private set; }
			[field: SerializeField] public Transform CandidateLense  { get; private set; }
			[field: SerializeField] public Transform ShadowCardSpawn { get; private set; }
			[field: SerializeField] public Transform CardScoring     { get; private set; }
			[field: SerializeField] public Transform Money           { get; private set; }
		}

		[Serializable]
		public class CameraHolders
		{
			[field: SerializeField] public Transform PlayerSitting { get; private set; }
			[field: SerializeField] public Transform CardsScoring  { get; private set; }
			[field: SerializeField] public Transform Burning       { get; private set; }
		}

		[Serializable]
		public class LampHolders
		{
			[field: SerializeField] public Transform Default    { get; private set; }
			[field: SerializeField] public Transform AtPlayer   { get; private set; }
			[field: SerializeField] public Transform AtOpponent { get; private set; }
		}
	}
}