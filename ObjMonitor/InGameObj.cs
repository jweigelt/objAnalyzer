using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class InGameObj
    {
        //Object Ptrs
        public static readonly int[] CHARACTER_OBJ_OFFSET = { 0X30C };
        public static readonly int[] SOLDIER_CLASS_OFFSET = { 0X8 };

        public static readonly int[] HEALTH_OFFSET =        { 0x144 };
        public static readonly int[] MAX_HEALTH_OFFSET =    { 0x148 };
        public static readonly int[] ANIM_VALUE_OFFSET =    { 0x744 };
        public static readonly int[] X_OFFSET =             { 0x120 };
        public static readonly int[] Y_OFFSET =             { 0x124 };
        public static readonly int[] Z_OFFSET =             { 0x128 };

        public readonly int[] TARGETED_OBJECT_OFFSET =      { 0x378 }; //Address will be populated by ptr to object base address when aimed at/targeted
        public readonly int[] OBJ_IN_CURSOR_OFFSET =        { 0x3A4 }; // ^^

        public readonly int[] X_CONTROL_OFFSET =            { 0xF8 };
        public readonly int[] Z_CONTROL_OFFSET =            { 0xF0 };
        public readonly int[] X_CAMERA_OFFSET =             { 0x110 }; //Opposite sign of Control_X
        public readonly int[] Y_CAMERA_OFFSET =             { 0x4E8 };
        public readonly int[] Z_CAMERA_OFFSET =             { 0x118 };  //Same value as Control_Z

        public IntPtr baseAddr;
        public ProcessMemoryReader reader;
        public InGameObj(IntPtr basePtr, ProcessMemoryReader reader)
        {
            this.reader = reader;
            baseAddr = basePtr;
        }
        public virtual bool Exists
        {
            get
            {
                return !baseAddr.Equals(IntPtr.Zero);
            }
        }
        //TODO: IsPlayer
        public bool IsPlayer
        {
            get
            {
                int[] teams = { 1, 2 };
                return Character.Index > -1 && teams.Contains(Character.TeamID);
            }
        }
        public InGameCharacterObject Character
        {
            get
            {
                return new InGameCharacterObject(reader.ReadPtr(reader.GetOffsetIntPtr(baseAddr, CHARACTER_OBJ_OFFSET)), reader);
            }
        }
        public InGameSoldierClassObj SoldierClass
        {
            get
            {
                return new InGameSoldierClassObj(reader.ReadPtr(reader.GetOffsetIntPtr(baseAddr, SOLDIER_CLASS_OFFSET)), reader);
            }
        }
        public int AnimValue 
        {
            get
            {
                //TODO
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, ANIM_VALUE_OFFSET));
            }
        }
        public float MaxHealth
        {
            get
            {
                return reader.ReadFloat(reader.GetOffsetIntPtr(baseAddr, MAX_HEALTH_OFFSET));
            }
        }
        public IntPtr HealthAddr
        {
            get
            {
                return reader.GetOffsetIntPtr(baseAddr, HEALTH_OFFSET);
            }
        }
        public float Health
        {
            get
            {
                return reader.ReadFloat(HealthAddr);
            }
        }
        public float X
        {
            get
            {
                return reader.ReadFloat(reader.GetOffsetIntPtr(baseAddr, X_OFFSET));
            }
        }
        public float Y
        {
            get
            {
                return reader.ReadFloat(reader.GetOffsetIntPtr(baseAddr, Y_OFFSET));
            }
        }
        public float Z
        {
            get
            {
                return reader.ReadFloat(reader.GetOffsetIntPtr(baseAddr, Z_OFFSET));
            }
        }
        public IntPtr xCameraAddr
        {
            get
            {
                return reader.GetOffsetIntPtr(baseAddr, X_CAMERA_OFFSET);
            }
        }
        public IntPtr yCameraAddr
        {
            get
            {
                return reader.GetOffsetIntPtr(baseAddr, Y_CAMERA_OFFSET);
            }
        }
        public IntPtr zCameraAddr
        {
            get
            {
                return reader.GetOffsetIntPtr(baseAddr, Z_CAMERA_OFFSET);
            }
        }
        public float xCamera
        {
            get
            {
                return reader.ReadFloat(xCameraAddr);
            }
        }
        public float yCamera
        {
            get
            {
                return reader.ReadFloat(yCameraAddr);
            }
        }
        public float zCamera
        {
            get
            {
                return reader.ReadFloat(zCameraAddr);
            }
        }
        public IntPtr xControllerAddr
        {
            get
            {
                return reader.GetOffsetIntPtr(baseAddr, X_CONTROL_OFFSET);
            }
        }
        public IntPtr zControllerAddr
        {
            get
            {
                return reader.GetOffsetIntPtr(baseAddr, Z_CONTROL_OFFSET);
            }
        }
        public float xController
        {
            get
            {
                return reader.ReadFloat(xControllerAddr);
            }
        }
        public float zController
        {
            get
            {
                return reader.ReadFloat(zControllerAddr);
            }
        }
        public InGameObj targetObject
        {
            get
            {
                return new InGameObj(reader.ReadPtr(reader.GetOffsetIntPtr(baseAddr, TARGETED_OBJECT_OFFSET)), reader);
            }
        }
        //TODO
        public float xAimingAt { get; }
        public float yAimingAt { get; }
        public float zAimingAt { get; }
    }
}
