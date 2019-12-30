using System.Threading;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;

public interface IInputProvider
{
	UniTask<float> GetXAxisAsync(CancellationToken token);
}