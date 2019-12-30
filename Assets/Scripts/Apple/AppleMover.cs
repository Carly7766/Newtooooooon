using System.Threading;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using Zenject;

public class AppleMover : MonoBehaviour
{
	[Inject]
	private IInputProvider inputProvider;
	private Rigidbody rigidbody;


	private void Awake() {
		rigidbody = GetComponent<Rigidbody>();

		var token = this.GetCancellationTokenOnDestroy();
		_ = Move(token);
	}

	private async UniTaskVoid Move(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			float x = await inputProvider.GetXAxisAsync(token);
			await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
			transform.position = new Vector3(x, 0, 0);
		}
	}
}
