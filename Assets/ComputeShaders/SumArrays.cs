using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumArrays : MonoBehaviour {
    public ComputeShader shader;

    public void Execute() {
        Debug.Log("Executing SumArrays...");

        int kernel = shader.FindKernel("SumArrays");

        ComputeBuffer input0Buffer = new ComputeBuffer(10, sizeof(float));
        ComputeBuffer input1Buffer = new ComputeBuffer(10, sizeof(float));
        ComputeBuffer outputBuffer = new ComputeBuffer(10, sizeof(float));

        var input0 = new float[10];
        var input1 = new float[10];
        var output = new float[10];
        for (int i = 0; i < 10; i++) {
            input0[i] = 1;
            input1[i] = i;
        }

        input0Buffer.SetData(input0);
        input1Buffer.SetData(input1);

        shader.SetBuffer(kernel, "input0Buffer", input0Buffer);
        shader.SetBuffer(kernel, "input1Buffer", input1Buffer);
        shader.SetBuffer(kernel, "outputBuffer", outputBuffer);

        shader.Dispatch(kernel, 64, 1, 1);
        outputBuffer.GetData(output);

        Debug.Log($"output: {string.Join(", ", output)}");

        input0Buffer.Release();
        input1Buffer.Release();
        outputBuffer.Release();
    }
}
