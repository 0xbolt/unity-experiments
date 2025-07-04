using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class SumArrayMain : MonoBehaviour {
    public void SumArray() {
        Debug.Log("Executing SumArray...");

        var input = new NativeArray<float>(10, Allocator.Persistent);
        var output = new NativeArray<float>(1, Allocator.Persistent);
        for (int i = 0; i < input.Length; i++) {
            input[i] = 1.0f * i;
        }

        var job = new SumArrayJob { Input = input, Output = output };
        job.Schedule().Complete();

        Debug.Log($"Input: {string.Join(", ", input)}");
        Debug.Log($"Output: {output[0]}");

        input.Dispose();
        output.Dispose();
    }

    [BurstCompile(CompileSynchronously = true)]
    private struct SumArrayJob : IJob {
        [ReadOnly]
        public NativeArray<float> Input;

        [WriteOnly]
        public NativeArray<float> Output;

        public void Execute() {
            float result = 0.0f;
            for (int i = 0; i < Input.Length; i++) {
                result += Input[i];
            }
            Output[0] = result;
        }
    }
}
