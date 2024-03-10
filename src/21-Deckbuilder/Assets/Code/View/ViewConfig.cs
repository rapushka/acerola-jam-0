using UnityEngine;

namespace Code
{
	[CreateAssetMenu(fileName = "ViewConfig", menuName = "+375/ViewConfig", order = -98)]
	public class ViewConfig : ScriptableObject
	{
		[field: Header("Common")]
		[field: SerializeField] public float CommonMovementSpeed { get; private set; }

		[field: SerializeField] public float CommonRotationSpeed { get; private set; }

		[field: Header("Cards")]
		[field: SerializeField] public float DistanceBetweenCards { get; private set; }

		[field: Header("Magnifying glass")]
		[field: SerializeField] public float LensMoveToCandidateDelay { get; private set; }

		[field: SerializeField] public float MagnifyingGlassSpecificSpeed { get; private set; }

		[field: Header("Burning")]
		[field: SerializeField] public float BurningDuration { get; private set; }

		[field: SerializeField] public float BurnedCardFlipMovementSpeed { get; private set; }

		[field: Header("Scoring")]
		[field: SerializeField] public float ScoringDuration { get; private set; }

		[field: SerializeField] public float OnScoringDistance { get; private set; }
	}
}