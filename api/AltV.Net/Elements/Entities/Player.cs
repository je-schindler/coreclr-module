using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        public static ushort GetId(IntPtr playerPointer) => AltNative.Player.Player_GetID(playerPointer);

        public override uint Model
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetModel(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetModel(NativePointer, value);
            }
        }

        public override Position Position
        {
            get
            {
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Player.Player_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetPosition(NativePointer, value);
            }
        }

        public override Rotation Rotation
        {
            get
            {
                CheckIfEntityExists();
                var rotation = Rotation.Zero;
                AltNative.Player.Player_GetRotation(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetRotation(NativePointer, value);
            }
        }

        public override short Dimension
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetDimension(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetDimension(NativePointer, value);
            }
        }

        public uint Ping
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetPing(NativePointer);
            }
        }

        public override void GetMetaData(string key, ref MValue value) =>
            AltNative.Player.Player_GetMetaData(NativePointer, key, ref value);

        public override void SetMetaData(string key, ref MValue value) =>
            AltNative.Player.Player_SetMetaData(NativePointer, key, ref value);

        public override void SetSyncedMetaData(string key, ref MValue value) =>
            AltNative.Player.Player_SetSyncedMetaData(NativePointer, key, ref value);

        public override void GetSyncedMetaData(string key, ref MValue value) =>
            AltNative.Player.Player_GetSyncedMetaData(NativePointer, key, ref value);

        public bool IsConnected
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsConnected(NativePointer);
            }
        }

        public string Name
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Player.Player_GetName(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
            set
            {
                CheckIfEntityExists();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                AltNative.Player.Player_SetName(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public ushort Health
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetHealth(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetHealth(NativePointer, value);
            }
        }

        public bool IsDead
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsDead(NativePointer);
            }
        }

        public bool IsJumping
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsJumping(NativePointer);
            }
        }

        public bool IsInRagdoll
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsInRagdoll(NativePointer);
            }
        }

        public bool IsAiming
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsAiming(NativePointer);
            }
        }

        public bool IsShooting
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsShooting(NativePointer);
            }
        }

        public bool IsReloading
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsReloading(NativePointer);
            }
        }

        public ushort Armor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetArmor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Player.Player_SetArmor(NativePointer, value);
            }
        }

        public float MoveSpeed
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetMoveSpeed(NativePointer);
            }
        }

        public uint Weapon
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetWeapon(NativePointer);
            }
        }

        public ushort Ammo
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetAmmo(NativePointer);
            }
        }

        public Position AimPosition
        {
            get
            {
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Player.Player_GetAimPos(NativePointer, ref position);
                return position;
            }
        }

        public Rotation HeadRotation
        {
            get
            {
                CheckIfEntityExists();
                var rotation = Rotation.Zero;
                AltNative.Player.Player_GetHeadRotation(NativePointer, ref rotation);
                return rotation;
            }
        }

        public bool IsInVehicle
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_IsInVehicle(NativePointer);
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                CheckIfEntityExists();
                var entityPointer = AltNative.Player.Player_GetVehicle(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.VehiclePool.GetOrCreate(entityPointer, out var vehicle) ? vehicle : null;
            }
        }

        public byte Seat
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Player.Player_GetSeat(NativePointer);
            }
        }

        public Player(IntPtr nativePointer, ushort id) : base(nativePointer, BaseObjectType.Player, id)
        {
        }

        public void Spawn(Position position, uint delayMs)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_Spawn(NativePointer, position, delayMs);
        }

        public void Despawn()
        {
            CheckIfEntityExists();
            AltNative.Player.Player_Despawn(NativePointer);
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_SetDateTime(NativePointer, day, month, year, hour, minute, second);
        }

        public void SetWeather(uint weather)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_SetWeather(NativePointer, weather);
        }

        public void GiveWeapon(uint weapon, int ammo, bool selectWeapon)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_GiveWeapon(NativePointer, weapon, ammo, selectWeapon);
        }

        public void RemoveWeapon(uint weapon)
        {
            CheckIfEntityExists();
            AltNative.Player.Player_RemoveWeapon(NativePointer, weapon);
        }

        public void RemoveAllWeapons()
        {
            CheckIfEntityExists();
            AltNative.Player.Player_RemoveAllWeapons(NativePointer);
        }

        public void Kick(string reason)
        {
            CheckIfEntityExists();
            var reasonPtr = AltNative.StringUtils.StringToHGlobalUtf8(reason);
            AltNative.Player.Player_Kick(NativePointer, reasonPtr);
            Marshal.FreeHGlobal(reasonPtr);
        }

        public void Emit(string eventName, params object[] args)
        {
            CheckIfEntityExists();
            Alt.Server.TriggerClientEvent(this, eventName, args);
        }

        public ReadOnlyPlayer Copy()
        {
            CheckIfEntityExists();
            var readOnlyPlayer = ReadOnlyPlayer.Empty;
            AltNative.Player.Player_Copy(NativePointer, ref readOnlyPlayer);
            return readOnlyPlayer;
        }
    }
}