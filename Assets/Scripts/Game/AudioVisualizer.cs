﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioVisualizer : MonoBehaviour{

    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];

    void Start(){
        _audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }

    void GetSpectrumAudioSource(){
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
    void MakeFrequencyBands(){
        // 20 - 60 hertz
        // 60 - 250 hertz
        // 250 - 500 hertz
        // 500 - 2000 hertz
        // 2000 - 4000 hertz
        // 4000 - 6000 hertz
        // 6000 - 20000 hertz

        /* 0 - 2   = 86    hertz
         * 1 - 4   = 172   hertz 87-258
         * 2 - 8   = 344   hertz 259-602
         * 3 - 16  = 688   hertz 603-1290
         * 4 - 32  = 1376  hertz 1291-2666
         * 5 - 64  = 2752  hertz 2667-5418
         * 6 - 128 = 5504  hertz 5419-10922
         * 7 - 256 = 11008 hertz 10923-21930
         * 510
         */

        int count = 0;
        for(int i = 0; i < 8; i++){
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i)*2;

            if (i == 7){
                sampleCount += 2;
            }
            for(int j = 0; j < sampleCount; j++){
                average += _samples[count] *(count + 1);
                count++;
            }
            average /= count;
            _freqBand[i] = average * 10;
        }
    }
}
