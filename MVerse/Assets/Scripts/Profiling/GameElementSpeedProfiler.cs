#if(UNITY_EDITOR)

using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using Unity.Profiling.Editor;
using UnityEngine;


namespace MVerse.Profiling
{
    public enum StatCounter
    {
        COUNTER_TARGET_SPEED,
        COUNTER_ACTUAL_SPEED,
        COUNTER_TARGET_ANGLE,
        COUNTER_MIN_DISTANCE,
        COUNTER_STUCK,
        COUNTER_SUPER_STUCK,

        COUNTER_TOTAL
    }
    public static class GameStats
    {
        public static readonly ProfilerCategory MovementSpeeds = new ProfilerCategory("Movement Speeds", ProfilerCategoryColor.Physics);

        public static readonly string[] CounterNames =
        {
            "Target Speed",
            "Actual Speed",
            "Target Angle",
            "Min Distance",
            "Stuck",
            "Super Stuck"
        };

        private static float[] PrecachedValues = new float[]
        {
            0,
            0,
            0,
            0,
            0,
            0
        };

        public static ProfilerCounterValue<float>[] CounterArray =
        {
            new ProfilerCounterValue<float>(MovementSpeeds, CounterNames[0], ProfilerMarkerDataUnit.Count,
            ProfilerCounterOptions.FlushOnEndOfFrame | ProfilerCounterOptions.ResetToZeroOnFlush),
            new ProfilerCounterValue<float>(MovementSpeeds, CounterNames[1], ProfilerMarkerDataUnit.Count,
            ProfilerCounterOptions.FlushOnEndOfFrame | ProfilerCounterOptions.ResetToZeroOnFlush),
            new ProfilerCounterValue<float>(MovementSpeeds, CounterNames[2], ProfilerMarkerDataUnit.Count,
            ProfilerCounterOptions.FlushOnEndOfFrame | ProfilerCounterOptions.ResetToZeroOnFlush),
            new ProfilerCounterValue<float>(MovementSpeeds, CounterNames[3], ProfilerMarkerDataUnit.Count,
            ProfilerCounterOptions.FlushOnEndOfFrame | ProfilerCounterOptions.ResetToZeroOnFlush),
            new ProfilerCounterValue<float>(MovementSpeeds, CounterNames[4], ProfilerMarkerDataUnit.Count,
            ProfilerCounterOptions.FlushOnEndOfFrame | ProfilerCounterOptions.ResetToZeroOnFlush),
            new ProfilerCounterValue<float>(MovementSpeeds, CounterNames[5], ProfilerMarkerDataUnit.Count,
            ProfilerCounterOptions.FlushOnEndOfFrame | ProfilerCounterOptions.ResetToZeroOnFlush)
        };
        


        public static void LoadPrecachedValue(StatCounter counter, float value)
        {
            PrecachedValues[(int)counter] = value;
        }

        public static void SetPrecachedValueAsBool(StatCounter counter, bool value)
        {
            PrecachedValues[(int)counter] = value ? 1f : 0f;
        }

        public static void GameStatsTick()
        {
            for(int i=0;i<(int)StatCounter.COUNTER_TOTAL;i++)
            {
                CounterArray[i].Value = PrecachedValues[i];
            }
        }
    }



    [ProfilerModuleMetadata("GameElementSpeeds")]
    public class GameElementSpeedProfiler : ProfilerModule
    {
        private static ProfilerCounterDescriptor[] k_Counters = new ProfilerCounterDescriptor[]
        {
            new ProfilerCounterDescriptor(GameStats.CounterNames[0], GameStats.MovementSpeeds),
            new ProfilerCounterDescriptor(GameStats.CounterNames[1], GameStats.MovementSpeeds),
            new ProfilerCounterDescriptor(GameStats.CounterNames[2], GameStats.MovementSpeeds),
            new ProfilerCounterDescriptor(GameStats.CounterNames[3], GameStats.MovementSpeeds),
            new ProfilerCounterDescriptor(GameStats.CounterNames[4], GameStats.MovementSpeeds),
            new ProfilerCounterDescriptor(GameStats.CounterNames[5], GameStats.MovementSpeeds)
        };




        public GameElementSpeedProfiler() : base(k_Counters)
        { 
        }

    }
}

#endif

