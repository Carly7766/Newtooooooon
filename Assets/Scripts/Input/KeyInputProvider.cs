using System.Threading;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;

public class KeyInputProvider : IInputProvider
{
	public async UniTask<float> GetXAxisAsync(CancellationToken token)
	{
			await UniTask.WaitUntil(() => Input.GetButton("Horizontal"), PlayerLoopTiming.Update, token);
			return Input.GetAxis("Horizontal");
	}
}