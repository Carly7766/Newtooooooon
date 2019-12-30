using System.Threading;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;

public class TouchInputProvider : IInputProvider
{
	private Camera mainCamera;
	private float distance;

	public TouchInputProvider()
	{
		mainCamera = Camera.main;
		distance = Mathf.Abs(mainCamera.transform.position.z);
	}

	public async UniTask<float> GetXAxisAsync(CancellationToken token)
	{
			await UniTask.WaitUntil(() => 0 < Input.touchCount, PlayerLoopTiming.Update, token);
			Vector3 touchPos = Input.GetTouch(0).position;
			touchPos.z = distance;

			return mainCamera.ScreenToWorldPoint(touchPos).x;
	}
}