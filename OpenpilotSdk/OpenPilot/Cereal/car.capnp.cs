using Capnp;
using Capnp.Rpc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cereal
{
    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9b1657f34caf3ad3UL)]
    public class CarEvent : ICapnpSerializable
    {
        public const UInt64 typeId = 0x9b1657f34caf3ad3UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Name = reader.Name;
            Enable = reader.Enable;
            NoEntry = reader.NoEntry;
            Warning = reader.Warning;
            UserDisable = reader.UserDisable;
            SoftDisable = reader.SoftDisable;
            ImmediateDisable = reader.ImmediateDisable;
            PreEnable = reader.PreEnable;
            Permanent = reader.Permanent;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Name = Name;
            writer.Enable = Enable;
            writer.NoEntry = NoEntry;
            writer.Warning = Warning;
            writer.UserDisable = UserDisable;
            writer.SoftDisable = SoftDisable;
            writer.ImmediateDisable = ImmediateDisable;
            writer.PreEnable = PreEnable;
            writer.Permanent = Permanent;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public Cereal.CarEvent.EventName Name
        {
            get;
            set;
        }

        public bool Enable
        {
            get;
            set;
        }

        public bool NoEntry
        {
            get;
            set;
        }

        public bool Warning
        {
            get;
            set;
        }

        public bool UserDisable
        {
            get;
            set;
        }

        public bool SoftDisable
        {
            get;
            set;
        }

        public bool ImmediateDisable
        {
            get;
            set;
        }

        public bool PreEnable
        {
            get;
            set;
        }

        public bool Permanent
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public Cereal.CarEvent.EventName Name => (Cereal.CarEvent.EventName)ctx.ReadDataUShort(0UL, (ushort)0);
            public bool Enable => ctx.ReadDataBool(16UL, false);
            public bool NoEntry => ctx.ReadDataBool(17UL, false);
            public bool Warning => ctx.ReadDataBool(18UL, false);
            public bool UserDisable => ctx.ReadDataBool(19UL, false);
            public bool SoftDisable => ctx.ReadDataBool(20UL, false);
            public bool ImmediateDisable => ctx.ReadDataBool(21UL, false);
            public bool PreEnable => ctx.ReadDataBool(22UL, false);
            public bool Permanent => ctx.ReadDataBool(23UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public Cereal.CarEvent.EventName Name
            {
                get => (Cereal.CarEvent.EventName)this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, (ushort)value, (ushort)0);
            }

            public bool Enable
            {
                get => this.ReadDataBool(16UL, false);
                set => this.WriteData(16UL, value, false);
            }

            public bool NoEntry
            {
                get => this.ReadDataBool(17UL, false);
                set => this.WriteData(17UL, value, false);
            }

            public bool Warning
            {
                get => this.ReadDataBool(18UL, false);
                set => this.WriteData(18UL, value, false);
            }

            public bool UserDisable
            {
                get => this.ReadDataBool(19UL, false);
                set => this.WriteData(19UL, value, false);
            }

            public bool SoftDisable
            {
                get => this.ReadDataBool(20UL, false);
                set => this.WriteData(20UL, value, false);
            }

            public bool ImmediateDisable
            {
                get => this.ReadDataBool(21UL, false);
                set => this.WriteData(21UL, value, false);
            }

            public bool PreEnable
            {
                get => this.ReadDataBool(22UL, false);
                set => this.WriteData(22UL, value, false);
            }

            public bool Permanent
            {
                get => this.ReadDataBool(23UL, false);
                set => this.WriteData(23UL, value, false);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbaa8c5d505f727deUL)]
        public enum EventName : ushort
        {
            canError,
            steerUnavailable,
            brakeUnavailable,
            wrongGear,
            doorOpen,
            seatbeltNotLatched,
            espDisabled,
            wrongCarMode,
            steerTempUnavailable,
            reverseGear,
            buttonCancel,
            buttonEnable,
            pedalPressed,
            cruiseDisabled,
            speedTooLow,
            outOfSpace,
            overheat,
            calibrationIncomplete,
            calibrationInvalid,
            controlsMismatch,
            pcmEnable,
            pcmDisable,
            noTarget,
            radarFault,
            brakeHold,
            parkBrake,
            manualRestart,
            lowSpeedLockout,
            plannerError,
            joystickDebug,
            steerTempUnavailableSilent,
            resumeRequired,
            preDriverDistracted,
            promptDriverDistracted,
            driverDistracted,
            preDriverUnresponsive,
            promptDriverUnresponsive,
            driverUnresponsive,
            belowSteerSpeed,
            lowBattery,
            vehicleModelInvalid,
            accFaulted,
            sensorDataInvalid,
            commIssue,
            tooDistracted,
            posenetInvalid,
            soundsUnavailable,
            preLaneChangeLeft,
            preLaneChangeRight,
            laneChange,
            lowMemory,
            stockAeb,
            ldw,
            carUnrecognized,
            invalidLkasSetting,
            speedTooHigh,
            laneChangeBlocked,
            relayMalfunction,
            gasPressed,
            stockFcw,
            startup,
            startupNoCar,
            startupNoControl,
            startupMaster,
            startupNoFw,
            fcw,
            steerSaturated,
            belowEngageSpeed,
            noGps,
            wrongCruiseMode,
            modeldLagging,
            deviceFalling,
            fanMalfunction,
            cameraMalfunction,
            gpsMalfunction,
            processNotRunning,
            dashcamMode,
            controlsInitializing,
            usbError,
            roadCameraError,
            driverCameraError,
            wideRoadCameraError,
            localizerMalfunction,
            highCpuUsage,
            cruiseMismatch,
            lkasDisabled,
            manualSteeringRequired,
            manualLongitudinalRequired,
            silentPedalPressed,
            silentButtonEnable,
            silentBrakeHold,
            silentWrongGear,
            radarCanErrorDEPRECATED,
            communityFeatureDisallowedDEPRECATED,
            radarCommIssueDEPRECATED,
            driverMonitorLowAccDEPRECATED,
            gasUnavailableDEPRECATED,
            dataNeededDEPRECATED,
            modelCommIssueDEPRECATED,
            ipasOverrideDEPRECATED,
            geofenceDEPRECATED,
            driverMonitorOnDEPRECATED,
            driverMonitorOffDEPRECATED,
            calibrationProgressDEPRECATED,
            invalidGiraffeHondaDEPRECATED,
            invalidGiraffeToyotaDEPRECATED,
            internetConnectivityNeededDEPRECATED,
            whitePandaUnsupportedDEPRECATED,
            commIssueWarningDEPRECATED,
            focusRecoverActiveDEPRECATED,
            neosUpdateRequiredDEPRECATED,
            modelLagWarningDEPRECATED,
            startupOneplusDEPRECATED,
            startupFuzzyFingerprintDEPRECATED
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9da4fa09e052903cUL)]
    public class CarState : ICapnpSerializable
    {
        public const UInt64 typeId = 0x9da4fa09e052903cUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            ErrorsDEPRECATED = reader.ErrorsDEPRECATED;
            VEgo = reader.VEgo;
            TheWheelSpeeds = CapnpSerializable.Create<Cereal.CarState.WheelSpeeds>(reader.TheWheelSpeeds);
            Gas = reader.Gas;
            GasPressed = reader.GasPressed;
            Brake = reader.Brake;
            BrakePressed = reader.BrakePressed;
            SteeringAngleDeg = reader.SteeringAngleDeg;
            SteeringTorque = reader.SteeringTorque;
            SteeringPressed = reader.SteeringPressed;
            TheCruiseState = CapnpSerializable.Create<Cereal.CarState.CruiseState>(reader.TheCruiseState);
            ButtonEvents = reader.ButtonEvents?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CarState.ButtonEvent>(_));
            CanMonoTimes = reader.CanMonoTimes;
            Events = reader.Events?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CarEvent>(_));
            TheGearShifter = reader.TheGearShifter;
            SteeringRateDeg = reader.SteeringRateDeg;
            AEgo = reader.AEgo;
            VEgoRaw = reader.VEgoRaw;
            Standstill = reader.Standstill;
            BrakeLightsDEPRECATED = reader.BrakeLightsDEPRECATED;
            LeftBlinker = reader.LeftBlinker;
            RightBlinker = reader.RightBlinker;
            YawRate = reader.YawRate;
            GenericToggle = reader.GenericToggle;
            DoorOpen = reader.DoorOpen;
            SeatbeltUnlatched = reader.SeatbeltUnlatched;
            CanValid = reader.CanValid;
            SteeringTorqueEps = reader.SteeringTorqueEps;
            ClutchPressed = reader.ClutchPressed;
            SteeringRateLimited = reader.SteeringRateLimited;
            StockAeb = reader.StockAeb;
            StockFcw = reader.StockFcw;
            EspDisabled = reader.EspDisabled;
            LeftBlindspot = reader.LeftBlindspot;
            RightBlindspot = reader.RightBlindspot;
            SteerWarning = reader.SteerWarning;
            SteerError = reader.SteerError;
            SteeringAngleOffsetDeg = reader.SteeringAngleOffsetDeg;
            BrakeHoldActive = reader.BrakeHoldActive;
            LkasEnabled = reader.LkasEnabled;
            LeftBlinkerOn = reader.LeftBlinkerOn;
            RightBlinkerOn = reader.RightBlinkerOn;
            DisengageByBrake = reader.DisengageByBrake;
            AutomaticLaneChange = reader.AutomaticLaneChange;
            BelowLaneChangeSpeed = reader.BelowLaneChangeSpeed;
            AccEnabled = reader.AccEnabled;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.ErrorsDEPRECATED.Init(ErrorsDEPRECATED);
            writer.VEgo = VEgo;
            TheWheelSpeeds?.serialize(writer.TheWheelSpeeds);
            writer.Gas = Gas;
            writer.GasPressed = GasPressed;
            writer.Brake = Brake;
            writer.BrakePressed = BrakePressed;
            writer.SteeringAngleDeg = SteeringAngleDeg;
            writer.SteeringTorque = SteeringTorque;
            writer.SteeringPressed = SteeringPressed;
            TheCruiseState?.serialize(writer.TheCruiseState);
            writer.ButtonEvents.Init(ButtonEvents, (_s1, _v1) => _v1?.serialize(_s1));
            writer.CanMonoTimes.Init(CanMonoTimes);
            writer.Events.Init(Events, (_s1, _v1) => _v1?.serialize(_s1));
            writer.TheGearShifter = TheGearShifter;
            writer.SteeringRateDeg = SteeringRateDeg;
            writer.AEgo = AEgo;
            writer.VEgoRaw = VEgoRaw;
            writer.Standstill = Standstill;
            writer.BrakeLightsDEPRECATED = BrakeLightsDEPRECATED;
            writer.LeftBlinker = LeftBlinker;
            writer.RightBlinker = RightBlinker;
            writer.YawRate = YawRate;
            writer.GenericToggle = GenericToggle;
            writer.DoorOpen = DoorOpen;
            writer.SeatbeltUnlatched = SeatbeltUnlatched;
            writer.CanValid = CanValid;
            writer.SteeringTorqueEps = SteeringTorqueEps;
            writer.ClutchPressed = ClutchPressed;
            writer.SteeringRateLimited = SteeringRateLimited;
            writer.StockAeb = StockAeb;
            writer.StockFcw = StockFcw;
            writer.EspDisabled = EspDisabled;
            writer.LeftBlindspot = LeftBlindspot;
            writer.RightBlindspot = RightBlindspot;
            writer.SteerWarning = SteerWarning;
            writer.SteerError = SteerError;
            writer.SteeringAngleOffsetDeg = SteeringAngleOffsetDeg;
            writer.BrakeHoldActive = BrakeHoldActive;
            writer.LkasEnabled = LkasEnabled;
            writer.LeftBlinkerOn = LeftBlinkerOn;
            writer.RightBlinkerOn = RightBlinkerOn;
            writer.DisengageByBrake = DisengageByBrake;
            writer.AutomaticLaneChange = AutomaticLaneChange;
            writer.BelowLaneChangeSpeed = BelowLaneChangeSpeed;
            writer.AccEnabled = AccEnabled;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<Cereal.CarEvent.EventName> ErrorsDEPRECATED
        {
            get;
            set;
        }

        public float VEgo
        {
            get;
            set;
        }

        public Cereal.CarState.WheelSpeeds TheWheelSpeeds
        {
            get;
            set;
        }

        public float Gas
        {
            get;
            set;
        }

        public bool GasPressed
        {
            get;
            set;
        }

        public float Brake
        {
            get;
            set;
        }

        public bool BrakePressed
        {
            get;
            set;
        }

        public float SteeringAngleDeg
        {
            get;
            set;
        }

        public float SteeringTorque
        {
            get;
            set;
        }

        public bool SteeringPressed
        {
            get;
            set;
        }

        public Cereal.CarState.CruiseState TheCruiseState
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.CarState.ButtonEvent> ButtonEvents
        {
            get;
            set;
        }

        public IReadOnlyList<ulong> CanMonoTimes
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.CarEvent> Events
        {
            get;
            set;
        }

        public Cereal.CarState.GearShifter TheGearShifter
        {
            get;
            set;
        }

        public float SteeringRateDeg
        {
            get;
            set;
        }

        public float AEgo
        {
            get;
            set;
        }

        public float VEgoRaw
        {
            get;
            set;
        }

        public bool Standstill
        {
            get;
            set;
        }

        public bool BrakeLightsDEPRECATED
        {
            get;
            set;
        }

        public bool LeftBlinker
        {
            get;
            set;
        }

        public bool RightBlinker
        {
            get;
            set;
        }

        public float YawRate
        {
            get;
            set;
        }

        public bool GenericToggle
        {
            get;
            set;
        }

        public bool DoorOpen
        {
            get;
            set;
        }

        public bool SeatbeltUnlatched
        {
            get;
            set;
        }

        public bool CanValid
        {
            get;
            set;
        }

        public float SteeringTorqueEps
        {
            get;
            set;
        }

        public bool ClutchPressed
        {
            get;
            set;
        }

        public bool SteeringRateLimited
        {
            get;
            set;
        }

        public bool StockAeb
        {
            get;
            set;
        }

        public bool StockFcw
        {
            get;
            set;
        }

        public bool EspDisabled
        {
            get;
            set;
        }

        public bool LeftBlindspot
        {
            get;
            set;
        }

        public bool RightBlindspot
        {
            get;
            set;
        }

        public bool SteerWarning
        {
            get;
            set;
        }

        public bool SteerError
        {
            get;
            set;
        }

        public float SteeringAngleOffsetDeg
        {
            get;
            set;
        }

        public bool BrakeHoldActive
        {
            get;
            set;
        }

        public bool LkasEnabled
        {
            get;
            set;
        }

        public bool LeftBlinkerOn
        {
            get;
            set;
        }

        public bool RightBlinkerOn
        {
            get;
            set;
        }

        public bool DisengageByBrake
        {
            get;
            set;
        }

        public bool AutomaticLaneChange
        {
            get;
            set;
        }

        public bool BelowLaneChangeSpeed
        {
            get;
            set;
        }

        public bool AccEnabled
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public IReadOnlyList<Cereal.CarEvent.EventName> ErrorsDEPRECATED => ctx.ReadList(0).CastEnums(_0 => (Cereal.CarEvent.EventName)_0);
            public float VEgo => ctx.ReadDataFloat(0UL, 0F);
            public Cereal.CarState.WheelSpeeds.READER TheWheelSpeeds => ctx.ReadStruct(1, Cereal.CarState.WheelSpeeds.READER.create);
            public float Gas => ctx.ReadDataFloat(32UL, 0F);
            public bool GasPressed => ctx.ReadDataBool(64UL, false);
            public float Brake => ctx.ReadDataFloat(96UL, 0F);
            public bool BrakePressed => ctx.ReadDataBool(65UL, false);
            public float SteeringAngleDeg => ctx.ReadDataFloat(128UL, 0F);
            public float SteeringTorque => ctx.ReadDataFloat(160UL, 0F);
            public bool SteeringPressed => ctx.ReadDataBool(66UL, false);
            public Cereal.CarState.CruiseState.READER TheCruiseState => ctx.ReadStruct(2, Cereal.CarState.CruiseState.READER.create);
            public IReadOnlyList<Cereal.CarState.ButtonEvent.READER> ButtonEvents => ctx.ReadList(3).Cast(Cereal.CarState.ButtonEvent.READER.create);
            public IReadOnlyList<ulong> CanMonoTimes => ctx.ReadList(4).CastULong();
            public IReadOnlyList<Cereal.CarEvent.READER> Events => ctx.ReadList(5).Cast(Cereal.CarEvent.READER.create);
            public Cereal.CarState.GearShifter TheGearShifter => (Cereal.CarState.GearShifter)ctx.ReadDataUShort(80UL, (ushort)0);
            public float SteeringRateDeg => ctx.ReadDataFloat(192UL, 0F);
            public float AEgo => ctx.ReadDataFloat(224UL, 0F);
            public float VEgoRaw => ctx.ReadDataFloat(256UL, 0F);
            public bool Standstill => ctx.ReadDataBool(67UL, false);
            public bool BrakeLightsDEPRECATED => ctx.ReadDataBool(68UL, false);
            public bool LeftBlinker => ctx.ReadDataBool(69UL, false);
            public bool RightBlinker => ctx.ReadDataBool(70UL, false);
            public float YawRate => ctx.ReadDataFloat(288UL, 0F);
            public bool GenericToggle => ctx.ReadDataBool(71UL, false);
            public bool DoorOpen => ctx.ReadDataBool(72UL, false);
            public bool SeatbeltUnlatched => ctx.ReadDataBool(73UL, false);
            public bool CanValid => ctx.ReadDataBool(74UL, false);
            public float SteeringTorqueEps => ctx.ReadDataFloat(320UL, 0F);
            public bool ClutchPressed => ctx.ReadDataBool(75UL, false);
            public bool SteeringRateLimited => ctx.ReadDataBool(76UL, false);
            public bool StockAeb => ctx.ReadDataBool(77UL, false);
            public bool StockFcw => ctx.ReadDataBool(78UL, false);
            public bool EspDisabled => ctx.ReadDataBool(79UL, false);
            public bool LeftBlindspot => ctx.ReadDataBool(352UL, false);
            public bool RightBlindspot => ctx.ReadDataBool(353UL, false);
            public bool SteerWarning => ctx.ReadDataBool(354UL, false);
            public bool SteerError => ctx.ReadDataBool(355UL, false);
            public float SteeringAngleOffsetDeg => ctx.ReadDataFloat(384UL, 0F);
            public bool BrakeHoldActive => ctx.ReadDataBool(356UL, false);
            public bool LkasEnabled => ctx.ReadDataBool(357UL, false);
            public bool LeftBlinkerOn => ctx.ReadDataBool(358UL, false);
            public bool RightBlinkerOn => ctx.ReadDataBool(359UL, false);
            public bool DisengageByBrake => ctx.ReadDataBool(360UL, false);
            public bool AutomaticLaneChange => ctx.ReadDataBool(361UL, false);
            public bool BelowLaneChangeSpeed => ctx.ReadDataBool(362UL, false);
            public bool AccEnabled => ctx.ReadDataBool(363UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(7, 6);
            }

            public ListOfPrimitivesSerializer<Cereal.CarEvent.EventName> ErrorsDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<Cereal.CarEvent.EventName>>(0);
                set => Link(0, value);
            }

            public float VEgo
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }

            public Cereal.CarState.WheelSpeeds.WRITER TheWheelSpeeds
            {
                get => BuildPointer<Cereal.CarState.WheelSpeeds.WRITER>(1);
                set => Link(1, value);
            }

            public float Gas
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public bool GasPressed
            {
                get => this.ReadDataBool(64UL, false);
                set => this.WriteData(64UL, value, false);
            }

            public float Brake
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public bool BrakePressed
            {
                get => this.ReadDataBool(65UL, false);
                set => this.WriteData(65UL, value, false);
            }

            public float SteeringAngleDeg
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float SteeringTorque
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public bool SteeringPressed
            {
                get => this.ReadDataBool(66UL, false);
                set => this.WriteData(66UL, value, false);
            }

            public Cereal.CarState.CruiseState.WRITER TheCruiseState
            {
                get => BuildPointer<Cereal.CarState.CruiseState.WRITER>(2);
                set => Link(2, value);
            }

            public ListOfStructsSerializer<Cereal.CarState.ButtonEvent.WRITER> ButtonEvents
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.CarState.ButtonEvent.WRITER>>(3);
                set => Link(3, value);
            }

            public ListOfPrimitivesSerializer<ulong> CanMonoTimes
            {
                get => BuildPointer<ListOfPrimitivesSerializer<ulong>>(4);
                set => Link(4, value);
            }

            public ListOfStructsSerializer<Cereal.CarEvent.WRITER> Events
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.CarEvent.WRITER>>(5);
                set => Link(5, value);
            }

            public Cereal.CarState.GearShifter TheGearShifter
            {
                get => (Cereal.CarState.GearShifter)this.ReadDataUShort(80UL, (ushort)0);
                set => this.WriteData(80UL, (ushort)value, (ushort)0);
            }

            public float SteeringRateDeg
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public float AEgo
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public float VEgoRaw
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }

            public bool Standstill
            {
                get => this.ReadDataBool(67UL, false);
                set => this.WriteData(67UL, value, false);
            }

            public bool BrakeLightsDEPRECATED
            {
                get => this.ReadDataBool(68UL, false);
                set => this.WriteData(68UL, value, false);
            }

            public bool LeftBlinker
            {
                get => this.ReadDataBool(69UL, false);
                set => this.WriteData(69UL, value, false);
            }

            public bool RightBlinker
            {
                get => this.ReadDataBool(70UL, false);
                set => this.WriteData(70UL, value, false);
            }

            public float YawRate
            {
                get => this.ReadDataFloat(288UL, 0F);
                set => this.WriteData(288UL, value, 0F);
            }

            public bool GenericToggle
            {
                get => this.ReadDataBool(71UL, false);
                set => this.WriteData(71UL, value, false);
            }

            public bool DoorOpen
            {
                get => this.ReadDataBool(72UL, false);
                set => this.WriteData(72UL, value, false);
            }

            public bool SeatbeltUnlatched
            {
                get => this.ReadDataBool(73UL, false);
                set => this.WriteData(73UL, value, false);
            }

            public bool CanValid
            {
                get => this.ReadDataBool(74UL, false);
                set => this.WriteData(74UL, value, false);
            }

            public float SteeringTorqueEps
            {
                get => this.ReadDataFloat(320UL, 0F);
                set => this.WriteData(320UL, value, 0F);
            }

            public bool ClutchPressed
            {
                get => this.ReadDataBool(75UL, false);
                set => this.WriteData(75UL, value, false);
            }

            public bool SteeringRateLimited
            {
                get => this.ReadDataBool(76UL, false);
                set => this.WriteData(76UL, value, false);
            }

            public bool StockAeb
            {
                get => this.ReadDataBool(77UL, false);
                set => this.WriteData(77UL, value, false);
            }

            public bool StockFcw
            {
                get => this.ReadDataBool(78UL, false);
                set => this.WriteData(78UL, value, false);
            }

            public bool EspDisabled
            {
                get => this.ReadDataBool(79UL, false);
                set => this.WriteData(79UL, value, false);
            }

            public bool LeftBlindspot
            {
                get => this.ReadDataBool(352UL, false);
                set => this.WriteData(352UL, value, false);
            }

            public bool RightBlindspot
            {
                get => this.ReadDataBool(353UL, false);
                set => this.WriteData(353UL, value, false);
            }

            public bool SteerWarning
            {
                get => this.ReadDataBool(354UL, false);
                set => this.WriteData(354UL, value, false);
            }

            public bool SteerError
            {
                get => this.ReadDataBool(355UL, false);
                set => this.WriteData(355UL, value, false);
            }

            public float SteeringAngleOffsetDeg
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }

            public bool BrakeHoldActive
            {
                get => this.ReadDataBool(356UL, false);
                set => this.WriteData(356UL, value, false);
            }

            public bool LkasEnabled
            {
                get => this.ReadDataBool(357UL, false);
                set => this.WriteData(357UL, value, false);
            }

            public bool LeftBlinkerOn
            {
                get => this.ReadDataBool(358UL, false);
                set => this.WriteData(358UL, value, false);
            }

            public bool RightBlinkerOn
            {
                get => this.ReadDataBool(359UL, false);
                set => this.WriteData(359UL, value, false);
            }

            public bool DisengageByBrake
            {
                get => this.ReadDataBool(360UL, false);
                set => this.WriteData(360UL, value, false);
            }

            public bool AutomaticLaneChange
            {
                get => this.ReadDataBool(361UL, false);
                set => this.WriteData(361UL, value, false);
            }

            public bool BelowLaneChangeSpeed
            {
                get => this.ReadDataBool(362UL, false);
                set => this.WriteData(362UL, value, false);
            }

            public bool AccEnabled
            {
                get => this.ReadDataBool(363UL, false);
                set => this.WriteData(363UL, value, false);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x991a37a6155935a3UL)]
        public class WheelSpeeds : ICapnpSerializable
        {
            public const UInt64 typeId = 0x991a37a6155935a3UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Fl = reader.Fl;
                Fr = reader.Fr;
                Rl = reader.Rl;
                Rr = reader.Rr;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Fl = Fl;
                writer.Fr = Fr;
                writer.Rl = Rl;
                writer.Rr = Rr;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float Fl
            {
                get;
                set;
            }

            public float Fr
            {
                get;
                set;
            }

            public float Rl
            {
                get;
                set;
            }

            public float Rr
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public float Fl => ctx.ReadDataFloat(0UL, 0F);
                public float Fr => ctx.ReadDataFloat(32UL, 0F);
                public float Rl => ctx.ReadDataFloat(64UL, 0F);
                public float Rr => ctx.ReadDataFloat(96UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public float Fl
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float Fr
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float Rl
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float Rr
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe64e81478e6e60afUL)]
        public class CruiseState : ICapnpSerializable
        {
            public const UInt64 typeId = 0xe64e81478e6e60afUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Enabled = reader.Enabled;
                Speed = reader.Speed;
                Available = reader.Available;
                SpeedOffset = reader.SpeedOffset;
                Standstill = reader.Standstill;
                NonAdaptive = reader.NonAdaptive;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Enabled = Enabled;
                writer.Speed = Speed;
                writer.Available = Available;
                writer.SpeedOffset = SpeedOffset;
                writer.Standstill = Standstill;
                writer.NonAdaptive = NonAdaptive;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool Enabled
            {
                get;
                set;
            }

            public float Speed
            {
                get;
                set;
            }

            public bool Available
            {
                get;
                set;
            }

            public float SpeedOffset
            {
                get;
                set;
            }

            public bool Standstill
            {
                get;
                set;
            }

            public bool NonAdaptive
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public bool Enabled => ctx.ReadDataBool(0UL, false);
                public float Speed => ctx.ReadDataFloat(32UL, 0F);
                public bool Available => ctx.ReadDataBool(1UL, false);
                public float SpeedOffset => ctx.ReadDataFloat(64UL, 0F);
                public bool Standstill => ctx.ReadDataBool(2UL, false);
                public bool NonAdaptive => ctx.ReadDataBool(3UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public bool Enabled
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public float Speed
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public bool Available
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public float SpeedOffset
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public bool Standstill
                {
                    get => this.ReadDataBool(2UL, false);
                    set => this.WriteData(2UL, value, false);
                }

                public bool NonAdaptive
                {
                    get => this.ReadDataBool(3UL, false);
                    set => this.WriteData(3UL, value, false);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe004ca45136f6a89UL)]
        public enum GearShifter : ushort
        {
            unknown,
            park,
            drive,
            neutral,
            reverse,
            sport,
            low,
            brake,
            eco,
            manumatic
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xff5ca6835b4acef6UL)]
        public class ButtonEvent : ICapnpSerializable
        {
            public const UInt64 typeId = 0xff5ca6835b4acef6UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Pressed = reader.Pressed;
                TheType = reader.TheType;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Pressed = Pressed;
                writer.TheType = TheType;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool Pressed
            {
                get;
                set;
            }

            public Cereal.CarState.ButtonEvent.Type TheType
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public bool Pressed => ctx.ReadDataBool(0UL, false);
                public Cereal.CarState.ButtonEvent.Type TheType => (Cereal.CarState.ButtonEvent.Type)ctx.ReadDataUShort(16UL, (ushort)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 0);
                }

                public bool Pressed
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public Cereal.CarState.ButtonEvent.Type TheType
                {
                    get => (Cereal.CarState.ButtonEvent.Type)this.ReadDataUShort(16UL, (ushort)0);
                    set => this.WriteData(16UL, (ushort)value, (ushort)0);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe16100205414717cUL)]
            public enum Type : ushort
            {
                unknown,
                leftBlinker,
                rightBlinker,
                accelCruise,
                decelCruise,
                cancel,
                altButton1,
                altButton2,
                altButton3,
                setCruise,
                resumeCruise,
                gapAdjustCruise
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x888ad6581cf0aacbUL)]
    public class RadarData : ICapnpSerializable
    {
        public const UInt64 typeId = 0x888ad6581cf0aacbUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Errors = reader.Errors;
            Points = reader.Points?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.RadarData.RadarPoint>(_));
            CanMonoTimes = reader.CanMonoTimes;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Errors.Init(Errors);
            writer.Points.Init(Points, (_s1, _v1) => _v1?.serialize(_s1));
            writer.CanMonoTimes.Init(CanMonoTimes);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<Cereal.RadarData.Error> Errors
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.RadarData.RadarPoint> Points
        {
            get;
            set;
        }

        public IReadOnlyList<ulong> CanMonoTimes
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public IReadOnlyList<Cereal.RadarData.Error> Errors => ctx.ReadList(0).CastEnums(_0 => (Cereal.RadarData.Error)_0);
            public IReadOnlyList<Cereal.RadarData.RadarPoint.READER> Points => ctx.ReadList(1).Cast(Cereal.RadarData.RadarPoint.READER.create);
            public IReadOnlyList<ulong> CanMonoTimes => ctx.ReadList(2).CastULong();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 3);
            }

            public ListOfPrimitivesSerializer<Cereal.RadarData.Error> Errors
            {
                get => BuildPointer<ListOfPrimitivesSerializer<Cereal.RadarData.Error>>(0);
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.RadarData.RadarPoint.WRITER> Points
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.RadarData.RadarPoint.WRITER>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<ulong> CanMonoTimes
            {
                get => BuildPointer<ListOfPrimitivesSerializer<ulong>>(2);
                set => Link(2, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe8a86679ebba76adUL)]
        public enum Error : ushort
        {
            canError,
            fault,
            wrongConfig
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8ff333ebac1fdf36UL)]
        public class RadarPoint : ICapnpSerializable
        {
            public const UInt64 typeId = 0x8ff333ebac1fdf36UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                TrackId = reader.TrackId;
                DRel = reader.DRel;
                YRel = reader.YRel;
                VRel = reader.VRel;
                ARel = reader.ARel;
                YvRel = reader.YvRel;
                Measured = reader.Measured;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.TrackId = TrackId;
                writer.DRel = DRel;
                writer.YRel = YRel;
                writer.VRel = VRel;
                writer.ARel = ARel;
                writer.YvRel = YvRel;
                writer.Measured = Measured;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public ulong TrackId
            {
                get;
                set;
            }

            public float DRel
            {
                get;
                set;
            }

            public float YRel
            {
                get;
                set;
            }

            public float VRel
            {
                get;
                set;
            }

            public float ARel
            {
                get;
                set;
            }

            public float YvRel
            {
                get;
                set;
            }

            public bool Measured
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public ulong TrackId => ctx.ReadDataULong(0UL, 0UL);
                public float DRel => ctx.ReadDataFloat(64UL, 0F);
                public float YRel => ctx.ReadDataFloat(96UL, 0F);
                public float VRel => ctx.ReadDataFloat(128UL, 0F);
                public float ARel => ctx.ReadDataFloat(160UL, 0F);
                public float YvRel => ctx.ReadDataFloat(192UL, 0F);
                public bool Measured => ctx.ReadDataBool(224UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(4, 0);
                }

                public ulong TrackId
                {
                    get => this.ReadDataULong(0UL, 0UL);
                    set => this.WriteData(0UL, value, 0UL);
                }

                public float DRel
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float YRel
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float VRel
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float ARel
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float YvRel
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public bool Measured
                {
                    get => this.ReadDataBool(224UL, false);
                    set => this.WriteData(224UL, value, false);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf78829049ab814afUL)]
    public class CarControl : ICapnpSerializable
    {
        public const UInt64 typeId = 0xf78829049ab814afUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Enabled = reader.Enabled;
            GasDEPRECATED = reader.GasDEPRECATED;
            BrakeDEPRECATED = reader.BrakeDEPRECATED;
            SteeringTorqueDEPRECATED = reader.SteeringTorqueDEPRECATED;
            TheCruiseControl = CapnpSerializable.Create<Cereal.CarControl.CruiseControl>(reader.TheCruiseControl);
            HudControl = CapnpSerializable.Create<Cereal.CarControl.HUDControl>(reader.HudControl);
            TheActuators = CapnpSerializable.Create<Cereal.CarControl.Actuators>(reader.TheActuators);
            Active = reader.Active;
            Roll = reader.Roll;
            Pitch = reader.Pitch;
            ActuatorsOutput = CapnpSerializable.Create<Cereal.CarControl.Actuators>(reader.ActuatorsOutput);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Enabled = Enabled;
            writer.GasDEPRECATED = GasDEPRECATED;
            writer.BrakeDEPRECATED = BrakeDEPRECATED;
            writer.SteeringTorqueDEPRECATED = SteeringTorqueDEPRECATED;
            TheCruiseControl?.serialize(writer.TheCruiseControl);
            HudControl?.serialize(writer.HudControl);
            TheActuators?.serialize(writer.TheActuators);
            writer.Active = Active;
            writer.Roll = Roll;
            writer.Pitch = Pitch;
            ActuatorsOutput?.serialize(writer.ActuatorsOutput);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Enabled
        {
            get;
            set;
        }

        public float GasDEPRECATED
        {
            get;
            set;
        }

        public float BrakeDEPRECATED
        {
            get;
            set;
        }

        public float SteeringTorqueDEPRECATED
        {
            get;
            set;
        }

        public Cereal.CarControl.CruiseControl TheCruiseControl
        {
            get;
            set;
        }

        public Cereal.CarControl.HUDControl HudControl
        {
            get;
            set;
        }

        public Cereal.CarControl.Actuators TheActuators
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public float Roll
        {
            get;
            set;
        }

        public float Pitch
        {
            get;
            set;
        }

        public Cereal.CarControl.Actuators ActuatorsOutput
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public bool Enabled => ctx.ReadDataBool(0UL, false);
            public float GasDEPRECATED => ctx.ReadDataFloat(32UL, 0F);
            public float BrakeDEPRECATED => ctx.ReadDataFloat(64UL, 0F);
            public float SteeringTorqueDEPRECATED => ctx.ReadDataFloat(96UL, 0F);
            public Cereal.CarControl.CruiseControl.READER TheCruiseControl => ctx.ReadStruct(0, Cereal.CarControl.CruiseControl.READER.create);
            public Cereal.CarControl.HUDControl.READER HudControl => ctx.ReadStruct(1, Cereal.CarControl.HUDControl.READER.create);
            public Cereal.CarControl.Actuators.READER TheActuators => ctx.ReadStruct(2, Cereal.CarControl.Actuators.READER.create);
            public bool Active => ctx.ReadDataBool(1UL, false);
            public float Roll => ctx.ReadDataFloat(128UL, 0F);
            public float Pitch => ctx.ReadDataFloat(160UL, 0F);
            public Cereal.CarControl.Actuators.READER ActuatorsOutput => ctx.ReadStruct(3, Cereal.CarControl.Actuators.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(3, 4);
            }

            public bool Enabled
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public float GasDEPRECATED
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float BrakeDEPRECATED
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public float SteeringTorqueDEPRECATED
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public Cereal.CarControl.CruiseControl.WRITER TheCruiseControl
            {
                get => BuildPointer<Cereal.CarControl.CruiseControl.WRITER>(0);
                set => Link(0, value);
            }

            public Cereal.CarControl.HUDControl.WRITER HudControl
            {
                get => BuildPointer<Cereal.CarControl.HUDControl.WRITER>(1);
                set => Link(1, value);
            }

            public Cereal.CarControl.Actuators.WRITER TheActuators
            {
                get => BuildPointer<Cereal.CarControl.Actuators.WRITER>(2);
                set => Link(2, value);
            }

            public bool Active
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public float Roll
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float Pitch
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public Cereal.CarControl.Actuators.WRITER ActuatorsOutput
            {
                get => BuildPointer<Cereal.CarControl.Actuators.WRITER>(3);
                set => Link(3, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe97275a919432828UL)]
        public class Actuators : ICapnpSerializable
        {
            public const UInt64 typeId = 0xe97275a919432828UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Gas = reader.Gas;
                Brake = reader.Brake;
                Steer = reader.Steer;
                SteeringAngleDeg = reader.SteeringAngleDeg;
                Accel = reader.Accel;
                TheLongControlState = reader.TheLongControlState;
                Speed = reader.Speed;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Gas = Gas;
                writer.Brake = Brake;
                writer.Steer = Steer;
                writer.SteeringAngleDeg = SteeringAngleDeg;
                writer.Accel = Accel;
                writer.TheLongControlState = TheLongControlState;
                writer.Speed = Speed;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float Gas
            {
                get;
                set;
            }

            public float Brake
            {
                get;
                set;
            }

            public float Steer
            {
                get;
                set;
            }

            public float SteeringAngleDeg
            {
                get;
                set;
            }

            public float Accel
            {
                get;
                set;
            }

            public Cereal.CarControl.Actuators.LongControlState TheLongControlState
            {
                get;
                set;
            }

            public float Speed
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public float Gas => ctx.ReadDataFloat(0UL, 0F);
                public float Brake => ctx.ReadDataFloat(32UL, 0F);
                public float Steer => ctx.ReadDataFloat(64UL, 0F);
                public float SteeringAngleDeg => ctx.ReadDataFloat(96UL, 0F);
                public float Accel => ctx.ReadDataFloat(128UL, 0F);
                public Cereal.CarControl.Actuators.LongControlState TheLongControlState => (Cereal.CarControl.Actuators.LongControlState)ctx.ReadDataUShort(160UL, (ushort)0);
                public float Speed => ctx.ReadDataFloat(192UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(4, 0);
                }

                public float Gas
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float Brake
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float Steer
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float SteeringAngleDeg
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float Accel
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public Cereal.CarControl.Actuators.LongControlState TheLongControlState
                {
                    get => (Cereal.CarControl.Actuators.LongControlState)this.ReadDataUShort(160UL, (ushort)0);
                    set => this.WriteData(160UL, (ushort)value, (ushort)0);
                }

                public float Speed
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe40f3a917d908282UL)]
            public enum LongControlState : ushort
            {
                off,
                pid,
                stopping,
                startingDEPRECATED
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb20e386e0e0ba8d3UL)]
        public class CruiseControl : ICapnpSerializable
        {
            public const UInt64 typeId = 0xb20e386e0e0ba8d3UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Cancel = reader.Cancel;
                Override = reader.Override;
                SpeedOverride = reader.SpeedOverride;
                AccelOverride = reader.AccelOverride;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Cancel = Cancel;
                writer.Override = Override;
                writer.SpeedOverride = SpeedOverride;
                writer.AccelOverride = AccelOverride;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool Cancel
            {
                get;
                set;
            }

            public bool Override
            {
                get;
                set;
            }

            public float SpeedOverride
            {
                get;
                set;
            }

            public float AccelOverride
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public bool Cancel => ctx.ReadDataBool(0UL, false);
                public bool Override => ctx.ReadDataBool(1UL, false);
                public float SpeedOverride => ctx.ReadDataFloat(32UL, 0F);
                public float AccelOverride => ctx.ReadDataFloat(64UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public bool Cancel
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public bool Override
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public float SpeedOverride
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float AccelOverride
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd895c87c4eb03a38UL)]
        public class HUDControl : ICapnpSerializable
        {
            public const UInt64 typeId = 0xd895c87c4eb03a38UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                SpeedVisible = reader.SpeedVisible;
                SetSpeed = reader.SetSpeed;
                LanesVisible = reader.LanesVisible;
                LeadVisible = reader.LeadVisible;
                TheVisualAlert = reader.TheVisualAlert;
                TheAudibleAlert = reader.TheAudibleAlert;
                RightLaneVisible = reader.RightLaneVisible;
                LeftLaneVisible = reader.LeftLaneVisible;
                RightLaneDepart = reader.RightLaneDepart;
                LeftLaneDepart = reader.LeftLaneDepart;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.SpeedVisible = SpeedVisible;
                writer.SetSpeed = SetSpeed;
                writer.LanesVisible = LanesVisible;
                writer.LeadVisible = LeadVisible;
                writer.TheVisualAlert = TheVisualAlert;
                writer.TheAudibleAlert = TheAudibleAlert;
                writer.RightLaneVisible = RightLaneVisible;
                writer.LeftLaneVisible = LeftLaneVisible;
                writer.RightLaneDepart = RightLaneDepart;
                writer.LeftLaneDepart = LeftLaneDepart;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool SpeedVisible
            {
                get;
                set;
            }

            public float SetSpeed
            {
                get;
                set;
            }

            public bool LanesVisible
            {
                get;
                set;
            }

            public bool LeadVisible
            {
                get;
                set;
            }

            public Cereal.CarControl.HUDControl.VisualAlert TheVisualAlert
            {
                get;
                set;
            }

            public Cereal.CarControl.HUDControl.AudibleAlert TheAudibleAlert
            {
                get;
                set;
            }

            public bool RightLaneVisible
            {
                get;
                set;
            }

            public bool LeftLaneVisible
            {
                get;
                set;
            }

            public bool RightLaneDepart
            {
                get;
                set;
            }

            public bool LeftLaneDepart
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public bool SpeedVisible => ctx.ReadDataBool(0UL, false);
                public float SetSpeed => ctx.ReadDataFloat(32UL, 0F);
                public bool LanesVisible => ctx.ReadDataBool(1UL, false);
                public bool LeadVisible => ctx.ReadDataBool(2UL, false);
                public Cereal.CarControl.HUDControl.VisualAlert TheVisualAlert => (Cereal.CarControl.HUDControl.VisualAlert)ctx.ReadDataUShort(16UL, (ushort)0);
                public Cereal.CarControl.HUDControl.AudibleAlert TheAudibleAlert => (Cereal.CarControl.HUDControl.AudibleAlert)ctx.ReadDataUShort(64UL, (ushort)0);
                public bool RightLaneVisible => ctx.ReadDataBool(3UL, false);
                public bool LeftLaneVisible => ctx.ReadDataBool(4UL, false);
                public bool RightLaneDepart => ctx.ReadDataBool(5UL, false);
                public bool LeftLaneDepart => ctx.ReadDataBool(6UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public bool SpeedVisible
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public float SetSpeed
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public bool LanesVisible
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public bool LeadVisible
                {
                    get => this.ReadDataBool(2UL, false);
                    set => this.WriteData(2UL, value, false);
                }

                public Cereal.CarControl.HUDControl.VisualAlert TheVisualAlert
                {
                    get => (Cereal.CarControl.HUDControl.VisualAlert)this.ReadDataUShort(16UL, (ushort)0);
                    set => this.WriteData(16UL, (ushort)value, (ushort)0);
                }

                public Cereal.CarControl.HUDControl.AudibleAlert TheAudibleAlert
                {
                    get => (Cereal.CarControl.HUDControl.AudibleAlert)this.ReadDataUShort(64UL, (ushort)0);
                    set => this.WriteData(64UL, (ushort)value, (ushort)0);
                }

                public bool RightLaneVisible
                {
                    get => this.ReadDataBool(3UL, false);
                    set => this.WriteData(3UL, value, false);
                }

                public bool LeftLaneVisible
                {
                    get => this.ReadDataBool(4UL, false);
                    set => this.WriteData(4UL, value, false);
                }

                public bool RightLaneDepart
                {
                    get => this.ReadDataBool(5UL, false);
                    set => this.WriteData(5UL, value, false);
                }

                public bool LeftLaneDepart
                {
                    get => this.ReadDataBool(6UL, false);
                    set => this.WriteData(6UL, value, false);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x90d78e84616e17d4UL)]
            public enum VisualAlert : ushort
            {
                none,
                fcw,
                steerRequired,
                brakePressed,
                wrongGear,
                seatbeltUnbuckled,
                speedTooHigh,
                ldw
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf5a5e26c954e339eUL)]
            public enum AudibleAlert : ushort
            {
                none,
                engage,
                disengage,
                refuse,
                warningSoft,
                warningImmediate,
                prompt,
                promptRepeat,
                promptDistracted
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8c69372490aaa9daUL)]
    public class CarParams : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8c69372490aaa9daUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            CarName = reader.CarName;
            CarFingerprint = reader.CarFingerprint;
            EnableGasInterceptor = reader.EnableGasInterceptor;
            PcmCruise = reader.PcmCruise;
            EnableCameraDEPRECATED = reader.EnableCameraDEPRECATED;
            EnableDsu = reader.EnableDsu;
            EnableApgs = reader.EnableApgs;
            MinEnableSpeed = reader.MinEnableSpeed;
            MinSteerSpeed = reader.MinSteerSpeed;
            SafetyModelDEPRECATED = reader.SafetyModelDEPRECATED;
            SafetyParamDEPRECATED = reader.SafetyParamDEPRECATED;
            SteerMaxBP = reader.SteerMaxBP;
            SteerMaxV = reader.SteerMaxV;
            GasMaxBPDEPRECATED = reader.GasMaxBPDEPRECATED;
            GasMaxVDEPRECATED = reader.GasMaxVDEPRECATED;
            BrakeMaxBPDEPRECATED = reader.BrakeMaxBPDEPRECATED;
            BrakeMaxVDEPRECATED = reader.BrakeMaxVDEPRECATED;
            Mass = reader.Mass;
            Wheelbase = reader.Wheelbase;
            CenterToFront = reader.CenterToFront;
            SteerRatio = reader.SteerRatio;
            SteerRatioRear = reader.SteerRatioRear;
            RotationalInertia = reader.RotationalInertia;
            TireStiffnessFront = reader.TireStiffnessFront;
            TireStiffnessRear = reader.TireStiffnessRear;
            LongitudinalTuning = CapnpSerializable.Create<Cereal.CarParams.LongitudinalPIDTuning>(reader.LongitudinalTuning);
            LateralTuning = CapnpSerializable.Create<Cereal.CarParams.lateralTuning>(reader.LateralTuning);
            SteerLimitAlert = reader.SteerLimitAlert;
            VEgoStopping = reader.VEgoStopping;
            DirectAccelControl = reader.DirectAccelControl;
            StoppingControl = reader.StoppingControl;
            StartAccelDEPRECATED = reader.StartAccelDEPRECATED;
            SteerRateCost = reader.SteerRateCost;
            TheSteerControlType = reader.TheSteerControlType;
            RadarOffCan = reader.RadarOffCan;
            SteerActuatorDelay = reader.SteerActuatorDelay;
            OpenpilotLongitudinalControl = reader.OpenpilotLongitudinalControl;
            CarVin = reader.CarVin;
            IsPandaBlackDEPRECATED = reader.IsPandaBlackDEPRECATED;
            DashcamOnly = reader.DashcamOnly;
            SafetyModelPassiveDEPRECATED = reader.SafetyModelPassiveDEPRECATED;
            TheTransmissionType = reader.TheTransmissionType;
            TheCarFw = reader.TheCarFw?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CarParams.CarFw>(_));
            RadarTimeStep = reader.RadarTimeStep;
            CommunityFeatureDEPRECATED = reader.CommunityFeatureDEPRECATED;
            SteerLimitTimer = reader.SteerLimitTimer;
            TheLateralParams = CapnpSerializable.Create<Cereal.CarParams.LateralParams>(reader.TheLateralParams);
            TheFingerprintSource = reader.TheFingerprintSource;
            TheNetworkLocation = reader.TheNetworkLocation;
            MinSpeedCanDEPRECATED = reader.MinSpeedCanDEPRECATED;
            StoppingDecelRate = reader.StoppingDecelRate;
            StartingAccelRateDEPRECATED = reader.StartingAccelRateDEPRECATED;
            MaxSteeringAngleDeg = reader.MaxSteeringAngleDeg;
            FuzzyFingerprint = reader.FuzzyFingerprint;
            EnableBsm = reader.EnableBsm;
            HasStockCameraDEPRECATED = reader.HasStockCameraDEPRECATED;
            LongitudinalActuatorDelayUpperBound = reader.LongitudinalActuatorDelayUpperBound;
            VEgoStarting = reader.VEgoStarting;
            StopAccel = reader.StopAccel;
            LongitudinalActuatorDelayLowerBound = reader.LongitudinalActuatorDelayLowerBound;
            SafetyConfigs = reader.SafetyConfigs?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CarParams.SafetyConfig>(_));
            WheelSpeedFactor = reader.WheelSpeedFactor;
            Flags = reader.Flags;
            UnsafeMode = reader.UnsafeMode;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.CarName = CarName;
            writer.CarFingerprint = CarFingerprint;
            writer.EnableGasInterceptor = EnableGasInterceptor;
            writer.PcmCruise = PcmCruise;
            writer.EnableCameraDEPRECATED = EnableCameraDEPRECATED;
            writer.EnableDsu = EnableDsu;
            writer.EnableApgs = EnableApgs;
            writer.MinEnableSpeed = MinEnableSpeed;
            writer.MinSteerSpeed = MinSteerSpeed;
            writer.SafetyModelDEPRECATED = SafetyModelDEPRECATED;
            writer.SafetyParamDEPRECATED = SafetyParamDEPRECATED;
            writer.SteerMaxBP.Init(SteerMaxBP);
            writer.SteerMaxV.Init(SteerMaxV);
            writer.GasMaxBPDEPRECATED.Init(GasMaxBPDEPRECATED);
            writer.GasMaxVDEPRECATED.Init(GasMaxVDEPRECATED);
            writer.BrakeMaxBPDEPRECATED.Init(BrakeMaxBPDEPRECATED);
            writer.BrakeMaxVDEPRECATED.Init(BrakeMaxVDEPRECATED);
            writer.Mass = Mass;
            writer.Wheelbase = Wheelbase;
            writer.CenterToFront = CenterToFront;
            writer.SteerRatio = SteerRatio;
            writer.SteerRatioRear = SteerRatioRear;
            writer.RotationalInertia = RotationalInertia;
            writer.TireStiffnessFront = TireStiffnessFront;
            writer.TireStiffnessRear = TireStiffnessRear;
            LongitudinalTuning?.serialize(writer.LongitudinalTuning);
            LateralTuning?.serialize(writer.LateralTuning);
            writer.SteerLimitAlert = SteerLimitAlert;
            writer.VEgoStopping = VEgoStopping;
            writer.DirectAccelControl = DirectAccelControl;
            writer.StoppingControl = StoppingControl;
            writer.StartAccelDEPRECATED = StartAccelDEPRECATED;
            writer.SteerRateCost = SteerRateCost;
            writer.TheSteerControlType = TheSteerControlType;
            writer.RadarOffCan = RadarOffCan;
            writer.SteerActuatorDelay = SteerActuatorDelay;
            writer.OpenpilotLongitudinalControl = OpenpilotLongitudinalControl;
            writer.CarVin = CarVin;
            writer.IsPandaBlackDEPRECATED = IsPandaBlackDEPRECATED;
            writer.DashcamOnly = DashcamOnly;
            writer.SafetyModelPassiveDEPRECATED = SafetyModelPassiveDEPRECATED;
            writer.TheTransmissionType = TheTransmissionType;
            writer.TheCarFw.Init(TheCarFw, (_s1, _v1) => _v1?.serialize(_s1));
            writer.RadarTimeStep = RadarTimeStep;
            writer.CommunityFeatureDEPRECATED = CommunityFeatureDEPRECATED;
            writer.SteerLimitTimer = SteerLimitTimer;
            TheLateralParams?.serialize(writer.TheLateralParams);
            writer.TheFingerprintSource = TheFingerprintSource;
            writer.TheNetworkLocation = TheNetworkLocation;
            writer.MinSpeedCanDEPRECATED = MinSpeedCanDEPRECATED;
            writer.StoppingDecelRate = StoppingDecelRate;
            writer.StartingAccelRateDEPRECATED = StartingAccelRateDEPRECATED;
            writer.MaxSteeringAngleDeg = MaxSteeringAngleDeg;
            writer.FuzzyFingerprint = FuzzyFingerprint;
            writer.EnableBsm = EnableBsm;
            writer.HasStockCameraDEPRECATED = HasStockCameraDEPRECATED;
            writer.LongitudinalActuatorDelayUpperBound = LongitudinalActuatorDelayUpperBound;
            writer.VEgoStarting = VEgoStarting;
            writer.StopAccel = StopAccel;
            writer.LongitudinalActuatorDelayLowerBound = LongitudinalActuatorDelayLowerBound;
            writer.SafetyConfigs.Init(SafetyConfigs, (_s1, _v1) => _v1?.serialize(_s1));
            writer.WheelSpeedFactor = WheelSpeedFactor;
            writer.Flags = Flags;
            writer.UnsafeMode = UnsafeMode;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string CarName
        {
            get;
            set;
        }

        public string CarFingerprint
        {
            get;
            set;
        }

        public bool EnableGasInterceptor
        {
            get;
            set;
        }

        public bool PcmCruise
        {
            get;
            set;
        }

        public bool EnableCameraDEPRECATED
        {
            get;
            set;
        }

        public bool EnableDsu
        {
            get;
            set;
        }

        public bool EnableApgs
        {
            get;
            set;
        }

        public float MinEnableSpeed
        {
            get;
            set;
        }

        public float MinSteerSpeed
        {
            get;
            set;
        }

        public Cereal.CarParams.SafetyModel SafetyModelDEPRECATED
        {
            get;
            set;
        }

        public short SafetyParamDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> SteerMaxBP
        {
            get;
            set;
        }

        public IReadOnlyList<float> SteerMaxV
        {
            get;
            set;
        }

        public IReadOnlyList<float> GasMaxBPDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> GasMaxVDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> BrakeMaxBPDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> BrakeMaxVDEPRECATED
        {
            get;
            set;
        }

        public float Mass
        {
            get;
            set;
        }

        public float Wheelbase
        {
            get;
            set;
        }

        public float CenterToFront
        {
            get;
            set;
        }

        public float SteerRatio
        {
            get;
            set;
        }

        public float SteerRatioRear
        {
            get;
            set;
        }

        public float RotationalInertia
        {
            get;
            set;
        }

        public float TireStiffnessFront
        {
            get;
            set;
        }

        public float TireStiffnessRear
        {
            get;
            set;
        }

        public Cereal.CarParams.LongitudinalPIDTuning LongitudinalTuning
        {
            get;
            set;
        }

        public Cereal.CarParams.lateralTuning LateralTuning
        {
            get;
            set;
        }

        public bool SteerLimitAlert
        {
            get;
            set;
        }

        public float VEgoStopping
        {
            get;
            set;
        }

        public bool DirectAccelControl
        {
            get;
            set;
        }

        public bool StoppingControl
        {
            get;
            set;
        }

        public float StartAccelDEPRECATED
        {
            get;
            set;
        }

        public float SteerRateCost
        {
            get;
            set;
        }

        public Cereal.CarParams.SteerControlType TheSteerControlType
        {
            get;
            set;
        }

        public bool RadarOffCan
        {
            get;
            set;
        }

        public float SteerActuatorDelay
        {
            get;
            set;
        }

        public bool OpenpilotLongitudinalControl
        {
            get;
            set;
        }

        public string CarVin
        {
            get;
            set;
        }

        public bool IsPandaBlackDEPRECATED
        {
            get;
            set;
        }

        public bool DashcamOnly
        {
            get;
            set;
        }

        public Cereal.CarParams.SafetyModel SafetyModelPassiveDEPRECATED
        {
            get;
            set;
        }

        = Cereal.CarParams.SafetyModel.silent;
        public Cereal.CarParams.TransmissionType TheTransmissionType
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.CarParams.CarFw> TheCarFw
        {
            get;
            set;
        }

        public float RadarTimeStep
        {
            get;
            set;
        }

        = 0.05F;
        public bool CommunityFeatureDEPRECATED
        {
            get;
            set;
        }

        public float SteerLimitTimer
        {
            get;
            set;
        }

        public Cereal.CarParams.LateralParams TheLateralParams
        {
            get;
            set;
        }

        public Cereal.CarParams.FingerprintSource TheFingerprintSource
        {
            get;
            set;
        }

        public Cereal.CarParams.NetworkLocation TheNetworkLocation
        {
            get;
            set;
        }

        public float MinSpeedCanDEPRECATED
        {
            get;
            set;
        }

        public float StoppingDecelRate
        {
            get;
            set;
        }

        public float StartingAccelRateDEPRECATED
        {
            get;
            set;
        }

        public float MaxSteeringAngleDeg
        {
            get;
            set;
        }

        public bool FuzzyFingerprint
        {
            get;
            set;
        }

        public bool EnableBsm
        {
            get;
            set;
        }

        public bool HasStockCameraDEPRECATED
        {
            get;
            set;
        }

        public float LongitudinalActuatorDelayUpperBound
        {
            get;
            set;
        }

        public float VEgoStarting
        {
            get;
            set;
        }

        public float StopAccel
        {
            get;
            set;
        }

        public float LongitudinalActuatorDelayLowerBound
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.CarParams.SafetyConfig> SafetyConfigs
        {
            get;
            set;
        }

        public float WheelSpeedFactor
        {
            get;
            set;
        }

        public uint Flags
        {
            get;
            set;
        }

        public short UnsafeMode
        {
            get;
            set;
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
            public string CarName => ctx.ReadText(0, null);
            public string CarFingerprint => ctx.ReadText(1, null);
            public bool EnableGasInterceptor => ctx.ReadDataBool(0UL, false);
            public bool PcmCruise => ctx.ReadDataBool(1UL, false);
            public bool EnableCameraDEPRECATED => ctx.ReadDataBool(2UL, false);
            public bool EnableDsu => ctx.ReadDataBool(3UL, false);
            public bool EnableApgs => ctx.ReadDataBool(4UL, false);
            public float MinEnableSpeed => ctx.ReadDataFloat(32UL, 0F);
            public float MinSteerSpeed => ctx.ReadDataFloat(64UL, 0F);
            public Cereal.CarParams.SafetyModel SafetyModelDEPRECATED => (Cereal.CarParams.SafetyModel)ctx.ReadDataUShort(16UL, (ushort)0);
            public short SafetyParamDEPRECATED => ctx.ReadDataShort(96UL, (short)0);
            public IReadOnlyList<float> SteerMaxBP => ctx.ReadList(2).CastFloat();
            public IReadOnlyList<float> SteerMaxV => ctx.ReadList(3).CastFloat();
            public IReadOnlyList<float> GasMaxBPDEPRECATED => ctx.ReadList(4).CastFloat();
            public IReadOnlyList<float> GasMaxVDEPRECATED => ctx.ReadList(5).CastFloat();
            public IReadOnlyList<float> BrakeMaxBPDEPRECATED => ctx.ReadList(6).CastFloat();
            public IReadOnlyList<float> BrakeMaxVDEPRECATED => ctx.ReadList(7).CastFloat();
            public float Mass => ctx.ReadDataFloat(128UL, 0F);
            public float Wheelbase => ctx.ReadDataFloat(160UL, 0F);
            public float CenterToFront => ctx.ReadDataFloat(192UL, 0F);
            public float SteerRatio => ctx.ReadDataFloat(224UL, 0F);
            public float SteerRatioRear => ctx.ReadDataFloat(256UL, 0F);
            public float RotationalInertia => ctx.ReadDataFloat(288UL, 0F);
            public float TireStiffnessFront => ctx.ReadDataFloat(320UL, 0F);
            public float TireStiffnessRear => ctx.ReadDataFloat(352UL, 0F);
            public Cereal.CarParams.LongitudinalPIDTuning.READER LongitudinalTuning => ctx.ReadStruct(8, Cereal.CarParams.LongitudinalPIDTuning.READER.create);
            public lateralTuning.READER LateralTuning => new lateralTuning.READER(ctx);
            public bool SteerLimitAlert => ctx.ReadDataBool(5UL, false);
            public float VEgoStopping => ctx.ReadDataFloat(384UL, 0F);
            public bool DirectAccelControl => ctx.ReadDataBool(6UL, false);
            public bool StoppingControl => ctx.ReadDataBool(7UL, false);
            public float StartAccelDEPRECATED => ctx.ReadDataFloat(416UL, 0F);
            public float SteerRateCost => ctx.ReadDataFloat(448UL, 0F);
            public Cereal.CarParams.SteerControlType TheSteerControlType => (Cereal.CarParams.SteerControlType)ctx.ReadDataUShort(480UL, (ushort)0);
            public bool RadarOffCan => ctx.ReadDataBool(8UL, false);
            public float SteerActuatorDelay => ctx.ReadDataFloat(512UL, 0F);
            public bool OpenpilotLongitudinalControl => ctx.ReadDataBool(9UL, false);
            public string CarVin => ctx.ReadText(10, null);
            public bool IsPandaBlackDEPRECATED => ctx.ReadDataBool(10UL, false);
            public bool DashcamOnly => ctx.ReadDataBool(11UL, false);
            public Cereal.CarParams.SafetyModel SafetyModelPassiveDEPRECATED => (Cereal.CarParams.SafetyModel)ctx.ReadDataUShort(496UL, (ushort)0);
            public Cereal.CarParams.TransmissionType TheTransmissionType => (Cereal.CarParams.TransmissionType)ctx.ReadDataUShort(544UL, (ushort)0);
            public IReadOnlyList<Cereal.CarParams.CarFw.READER> TheCarFw => ctx.ReadList(11).Cast(Cereal.CarParams.CarFw.READER.create);
            public float RadarTimeStep => ctx.ReadDataFloat(576UL, 0.05F);
            public bool CommunityFeatureDEPRECATED => ctx.ReadDataBool(12UL, false);
            public float SteerLimitTimer => ctx.ReadDataFloat(608UL, 0F);
            public Cereal.CarParams.LateralParams.READER TheLateralParams => ctx.ReadStruct(12, Cereal.CarParams.LateralParams.READER.create);
            public Cereal.CarParams.FingerprintSource TheFingerprintSource => (Cereal.CarParams.FingerprintSource)ctx.ReadDataUShort(560UL, (ushort)0);
            public Cereal.CarParams.NetworkLocation TheNetworkLocation => (Cereal.CarParams.NetworkLocation)ctx.ReadDataUShort(640UL, (ushort)0);
            public float MinSpeedCanDEPRECATED => ctx.ReadDataFloat(672UL, 0F);
            public float StoppingDecelRate => ctx.ReadDataFloat(704UL, 0F);
            public float StartingAccelRateDEPRECATED => ctx.ReadDataFloat(736UL, 0F);
            public float MaxSteeringAngleDeg => ctx.ReadDataFloat(768UL, 0F);
            public bool FuzzyFingerprint => ctx.ReadDataBool(13UL, false);
            public bool EnableBsm => ctx.ReadDataBool(14UL, false);
            public bool HasStockCameraDEPRECATED => ctx.ReadDataBool(15UL, false);
            public float LongitudinalActuatorDelayUpperBound => ctx.ReadDataFloat(800UL, 0F);
            public float VEgoStarting => ctx.ReadDataFloat(832UL, 0F);
            public float StopAccel => ctx.ReadDataFloat(864UL, 0F);
            public float LongitudinalActuatorDelayLowerBound => ctx.ReadDataFloat(896UL, 0F);
            public IReadOnlyList<Cereal.CarParams.SafetyConfig.READER> SafetyConfigs => ctx.ReadList(13).Cast(Cereal.CarParams.SafetyConfig.READER.create);
            public float WheelSpeedFactor => ctx.ReadDataFloat(928UL, 0F);
            public uint Flags => ctx.ReadDataUInt(960UL, 0U);
            public short UnsafeMode => ctx.ReadDataShort(656UL, (short)0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(16, 14);
            }

            public string CarName
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string CarFingerprint
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public bool EnableGasInterceptor
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public bool PcmCruise
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public bool EnableCameraDEPRECATED
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }

            public bool EnableDsu
            {
                get => this.ReadDataBool(3UL, false);
                set => this.WriteData(3UL, value, false);
            }

            public bool EnableApgs
            {
                get => this.ReadDataBool(4UL, false);
                set => this.WriteData(4UL, value, false);
            }

            public float MinEnableSpeed
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float MinSteerSpeed
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public Cereal.CarParams.SafetyModel SafetyModelDEPRECATED
            {
                get => (Cereal.CarParams.SafetyModel)this.ReadDataUShort(16UL, (ushort)0);
                set => this.WriteData(16UL, (ushort)value, (ushort)0);
            }

            public short SafetyParamDEPRECATED
            {
                get => this.ReadDataShort(96UL, (short)0);
                set => this.WriteData(96UL, value, (short)0);
            }

            public ListOfPrimitivesSerializer<float> SteerMaxBP
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public ListOfPrimitivesSerializer<float> SteerMaxV
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public ListOfPrimitivesSerializer<float> GasMaxBPDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<float> GasMaxVDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public ListOfPrimitivesSerializer<float> BrakeMaxBPDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(6);
                set => Link(6, value);
            }

            public ListOfPrimitivesSerializer<float> BrakeMaxVDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(7);
                set => Link(7, value);
            }

            public float Mass
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float Wheelbase
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public float CenterToFront
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public float SteerRatio
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public float SteerRatioRear
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }

            public float RotationalInertia
            {
                get => this.ReadDataFloat(288UL, 0F);
                set => this.WriteData(288UL, value, 0F);
            }

            public float TireStiffnessFront
            {
                get => this.ReadDataFloat(320UL, 0F);
                set => this.WriteData(320UL, value, 0F);
            }

            public float TireStiffnessRear
            {
                get => this.ReadDataFloat(352UL, 0F);
                set => this.WriteData(352UL, value, 0F);
            }

            public Cereal.CarParams.LongitudinalPIDTuning.WRITER LongitudinalTuning
            {
                get => BuildPointer<Cereal.CarParams.LongitudinalPIDTuning.WRITER>(8);
                set => Link(8, value);
            }

            public lateralTuning.WRITER LateralTuning
            {
                get => Rewrap<lateralTuning.WRITER>();
            }

            public bool SteerLimitAlert
            {
                get => this.ReadDataBool(5UL, false);
                set => this.WriteData(5UL, value, false);
            }

            public float VEgoStopping
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }

            public bool DirectAccelControl
            {
                get => this.ReadDataBool(6UL, false);
                set => this.WriteData(6UL, value, false);
            }

            public bool StoppingControl
            {
                get => this.ReadDataBool(7UL, false);
                set => this.WriteData(7UL, value, false);
            }

            public float StartAccelDEPRECATED
            {
                get => this.ReadDataFloat(416UL, 0F);
                set => this.WriteData(416UL, value, 0F);
            }

            public float SteerRateCost
            {
                get => this.ReadDataFloat(448UL, 0F);
                set => this.WriteData(448UL, value, 0F);
            }

            public Cereal.CarParams.SteerControlType TheSteerControlType
            {
                get => (Cereal.CarParams.SteerControlType)this.ReadDataUShort(480UL, (ushort)0);
                set => this.WriteData(480UL, (ushort)value, (ushort)0);
            }

            public bool RadarOffCan
            {
                get => this.ReadDataBool(8UL, false);
                set => this.WriteData(8UL, value, false);
            }

            public float SteerActuatorDelay
            {
                get => this.ReadDataFloat(512UL, 0F);
                set => this.WriteData(512UL, value, 0F);
            }

            public bool OpenpilotLongitudinalControl
            {
                get => this.ReadDataBool(9UL, false);
                set => this.WriteData(9UL, value, false);
            }

            public string CarVin
            {
                get => this.ReadText(10, null);
                set => this.WriteText(10, value, null);
            }

            public bool IsPandaBlackDEPRECATED
            {
                get => this.ReadDataBool(10UL, false);
                set => this.WriteData(10UL, value, false);
            }

            public bool DashcamOnly
            {
                get => this.ReadDataBool(11UL, false);
                set => this.WriteData(11UL, value, false);
            }

            public Cereal.CarParams.SafetyModel SafetyModelPassiveDEPRECATED
            {
                get => (Cereal.CarParams.SafetyModel)this.ReadDataUShort(496UL, (ushort)0);
                set => this.WriteData(496UL, (ushort)value, (ushort)0);
            }

            public Cereal.CarParams.TransmissionType TheTransmissionType
            {
                get => (Cereal.CarParams.TransmissionType)this.ReadDataUShort(544UL, (ushort)0);
                set => this.WriteData(544UL, (ushort)value, (ushort)0);
            }

            public ListOfStructsSerializer<Cereal.CarParams.CarFw.WRITER> TheCarFw
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.CarParams.CarFw.WRITER>>(11);
                set => Link(11, value);
            }

            public float RadarTimeStep
            {
                get => this.ReadDataFloat(576UL, 0.05F);
                set => this.WriteData(576UL, value, 0.05F);
            }

            public bool CommunityFeatureDEPRECATED
            {
                get => this.ReadDataBool(12UL, false);
                set => this.WriteData(12UL, value, false);
            }

            public float SteerLimitTimer
            {
                get => this.ReadDataFloat(608UL, 0F);
                set => this.WriteData(608UL, value, 0F);
            }

            public Cereal.CarParams.LateralParams.WRITER TheLateralParams
            {
                get => BuildPointer<Cereal.CarParams.LateralParams.WRITER>(12);
                set => Link(12, value);
            }

            public Cereal.CarParams.FingerprintSource TheFingerprintSource
            {
                get => (Cereal.CarParams.FingerprintSource)this.ReadDataUShort(560UL, (ushort)0);
                set => this.WriteData(560UL, (ushort)value, (ushort)0);
            }

            public Cereal.CarParams.NetworkLocation TheNetworkLocation
            {
                get => (Cereal.CarParams.NetworkLocation)this.ReadDataUShort(640UL, (ushort)0);
                set => this.WriteData(640UL, (ushort)value, (ushort)0);
            }

            public float MinSpeedCanDEPRECATED
            {
                get => this.ReadDataFloat(672UL, 0F);
                set => this.WriteData(672UL, value, 0F);
            }

            public float StoppingDecelRate
            {
                get => this.ReadDataFloat(704UL, 0F);
                set => this.WriteData(704UL, value, 0F);
            }

            public float StartingAccelRateDEPRECATED
            {
                get => this.ReadDataFloat(736UL, 0F);
                set => this.WriteData(736UL, value, 0F);
            }

            public float MaxSteeringAngleDeg
            {
                get => this.ReadDataFloat(768UL, 0F);
                set => this.WriteData(768UL, value, 0F);
            }

            public bool FuzzyFingerprint
            {
                get => this.ReadDataBool(13UL, false);
                set => this.WriteData(13UL, value, false);
            }

            public bool EnableBsm
            {
                get => this.ReadDataBool(14UL, false);
                set => this.WriteData(14UL, value, false);
            }

            public bool HasStockCameraDEPRECATED
            {
                get => this.ReadDataBool(15UL, false);
                set => this.WriteData(15UL, value, false);
            }

            public float LongitudinalActuatorDelayUpperBound
            {
                get => this.ReadDataFloat(800UL, 0F);
                set => this.WriteData(800UL, value, 0F);
            }

            public float VEgoStarting
            {
                get => this.ReadDataFloat(832UL, 0F);
                set => this.WriteData(832UL, value, 0F);
            }

            public float StopAccel
            {
                get => this.ReadDataFloat(864UL, 0F);
                set => this.WriteData(864UL, value, 0F);
            }

            public float LongitudinalActuatorDelayLowerBound
            {
                get => this.ReadDataFloat(896UL, 0F);
                set => this.WriteData(896UL, value, 0F);
            }

            public ListOfStructsSerializer<Cereal.CarParams.SafetyConfig.WRITER> SafetyConfigs
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.CarParams.SafetyConfig.WRITER>>(13);
                set => Link(13, value);
            }

            public float WheelSpeedFactor
            {
                get => this.ReadDataFloat(928UL, 0F);
                set => this.WriteData(928UL, value, 0F);
            }

            public uint Flags
            {
                get => this.ReadDataUInt(960UL, 0U);
                set => this.WriteData(960UL, value, 0U);
            }

            public short UnsafeMode
            {
                get => this.ReadDataShort(656UL, (short)0);
                set => this.WriteData(656UL, value, (short)0);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x93fc580a35339568UL)]
        public class lateralTuning : ICapnpSerializable
        {
            public const UInt64 typeId = 0x93fc580a35339568UL;
            public enum WHICH : ushort
            {
                Pid = 0,
                Indi = 1,
                Lqr = 2,
                undefined = 65535
            }

            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                switch (reader.which)
                {
                    case WHICH.Pid:
                        Pid = CapnpSerializable.Create<Cereal.CarParams.LateralPIDTuning>(reader.Pid);
                        break;
                    case WHICH.Indi:
                        Indi = CapnpSerializable.Create<Cereal.CarParams.LateralINDITuning>(reader.Indi);
                        break;
                    case WHICH.Lqr:
                        Lqr = CapnpSerializable.Create<Cereal.CarParams.LateralLQRTuning>(reader.Lqr);
                        break;
                }

                applyDefaults();
            }

            private WHICH _which = WHICH.undefined;
            private object _content;
            public WHICH which
            {
                get => _which;
                set
                {
                    if (value == _which)
                        return;
                    _which = value;
                    switch (value)
                    {
                        case WHICH.Pid:
                            _content = null;
                            break;
                        case WHICH.Indi:
                            _content = null;
                            break;
                        case WHICH.Lqr:
                            _content = null;
                            break;
                    }
                }
            }

            public void serialize(WRITER writer)
            {
                writer.which = which;
                switch (which)
                {
                    case WHICH.Pid:
                        Pid?.serialize(writer.Pid);
                        break;
                    case WHICH.Indi:
                        Indi?.serialize(writer.Indi);
                        break;
                    case WHICH.Lqr:
                        Lqr?.serialize(writer.Lqr);
                        break;
                }
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public Cereal.CarParams.LateralPIDTuning Pid
            {
                get => _which == WHICH.Pid ? (Cereal.CarParams.LateralPIDTuning)_content : null;
                set
                {
                    _which = WHICH.Pid;
                    _content = value;
                }
            }

            public Cereal.CarParams.LateralINDITuning Indi
            {
                get => _which == WHICH.Indi ? (Cereal.CarParams.LateralINDITuning)_content : null;
                set
                {
                    _which = WHICH.Indi;
                    _content = value;
                }
            }

            public Cereal.CarParams.LateralLQRTuning Lqr
            {
                get => _which == WHICH.Lqr ? (Cereal.CarParams.LateralLQRTuning)_content : null;
                set
                {
                    _which = WHICH.Lqr;
                    _content = value;
                }
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public WHICH which => (WHICH)ctx.ReadDataUShort(112U, (ushort)0);
                public Cereal.CarParams.LateralPIDTuning.READER Pid => which == WHICH.Pid ? ctx.ReadStruct(9, Cereal.CarParams.LateralPIDTuning.READER.create) : default;
                public Cereal.CarParams.LateralINDITuning.READER Indi => which == WHICH.Indi ? ctx.ReadStruct(9, Cereal.CarParams.LateralINDITuning.READER.create) : default;
                public Cereal.CarParams.LateralLQRTuning.READER Lqr => which == WHICH.Lqr ? ctx.ReadStruct(9, Cereal.CarParams.LateralLQRTuning.READER.create) : default;
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                }

                public WHICH which
                {
                    get => (WHICH)this.ReadDataUShort(112U, (ushort)0);
                    set => this.WriteData(112U, (ushort)value, (ushort)0);
                }

                public Cereal.CarParams.LateralPIDTuning.WRITER Pid
                {
                    get => which == WHICH.Pid ? BuildPointer<Cereal.CarParams.LateralPIDTuning.WRITER>(9) : default;
                    set => Link(9, value);
                }

                public Cereal.CarParams.LateralINDITuning.WRITER Indi
                {
                    get => which == WHICH.Indi ? BuildPointer<Cereal.CarParams.LateralINDITuning.WRITER>(9) : default;
                    set => Link(9, value);
                }

                public Cereal.CarParams.LateralLQRTuning.WRITER Lqr
                {
                    get => which == WHICH.Lqr ? BuildPointer<Cereal.CarParams.LateralLQRTuning.WRITER>(9) : default;
                    set => Link(9, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe836349c6056b0c9UL)]
        public class SafetyConfig : ICapnpSerializable
        {
            public const UInt64 typeId = 0xe836349c6056b0c9UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                SafetyModel = reader.SafetyModel;
                SafetyParam = reader.SafetyParam;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.SafetyModel = SafetyModel;
                writer.SafetyParam = SafetyParam;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public Cereal.CarParams.SafetyModel SafetyModel
            {
                get;
                set;
            }

            public short SafetyParam
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public Cereal.CarParams.SafetyModel SafetyModel => (Cereal.CarParams.SafetyModel)ctx.ReadDataUShort(0UL, (ushort)0);
                public short SafetyParam => ctx.ReadDataShort(16UL, (short)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 0);
                }

                public Cereal.CarParams.SafetyModel SafetyModel
                {
                    get => (Cereal.CarParams.SafetyModel)this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, (ushort)value, (ushort)0);
                }

                public short SafetyParam
                {
                    get => this.ReadDataShort(16UL, (short)0);
                    set => this.WriteData(16UL, value, (short)0);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb581b23b1c89dda3UL)]
        public class LateralParams : ICapnpSerializable
        {
            public const UInt64 typeId = 0xb581b23b1c89dda3UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                TorqueBP = reader.TorqueBP;
                TorqueV = reader.TorqueV;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.TorqueBP.Init(TorqueBP);
                writer.TorqueV.Init(TorqueV);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<int> TorqueBP
            {
                get;
                set;
            }

            public IReadOnlyList<int> TorqueV
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public IReadOnlyList<int> TorqueBP => ctx.ReadList(0).CastInt();
                public IReadOnlyList<int> TorqueV => ctx.ReadList(1).CastInt();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 2);
                }

                public ListOfPrimitivesSerializer<int> TorqueBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<int>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<int> TorqueV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<int>>(1);
                    set => Link(1, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9622723fcbd14c2eUL)]
        public class LateralPIDTuning : ICapnpSerializable
        {
            public const UInt64 typeId = 0x9622723fcbd14c2eUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                KpBP = reader.KpBP;
                KpV = reader.KpV;
                KiBP = reader.KiBP;
                KiV = reader.KiV;
                Kf = reader.Kf;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.KpBP.Init(KpBP);
                writer.KpV.Init(KpV);
                writer.KiBP.Init(KiBP);
                writer.KiV.Init(KiV);
                writer.Kf = Kf;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> KpBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> KpV
            {
                get;
                set;
            }

            public IReadOnlyList<float> KiBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> KiV
            {
                get;
                set;
            }

            public float Kf
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public IReadOnlyList<float> KpBP => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> KpV => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> KiBP => ctx.ReadList(2).CastFloat();
                public IReadOnlyList<float> KiV => ctx.ReadList(3).CastFloat();
                public float Kf => ctx.ReadDataFloat(0UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 4);
                }

                public ListOfPrimitivesSerializer<float> KpBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> KpV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> KiBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public ListOfPrimitivesSerializer<float> KiV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                    set => Link(3, value);
                }

                public float Kf
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc342cefc303e9b8eUL)]
        public class LongitudinalPIDTuning : ICapnpSerializable
        {
            public const UInt64 typeId = 0xc342cefc303e9b8eUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                KpBP = reader.KpBP;
                KpV = reader.KpV;
                KiBP = reader.KiBP;
                KiV = reader.KiV;
                DeadzoneBP = reader.DeadzoneBP;
                DeadzoneV = reader.DeadzoneV;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.KpBP.Init(KpBP);
                writer.KpV.Init(KpV);
                writer.KiBP.Init(KiBP);
                writer.KiV.Init(KiV);
                writer.DeadzoneBP.Init(DeadzoneBP);
                writer.DeadzoneV.Init(DeadzoneV);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> KpBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> KpV
            {
                get;
                set;
            }

            public IReadOnlyList<float> KiBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> KiV
            {
                get;
                set;
            }

            public IReadOnlyList<float> DeadzoneBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> DeadzoneV
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public IReadOnlyList<float> KpBP => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> KpV => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> KiBP => ctx.ReadList(2).CastFloat();
                public IReadOnlyList<float> KiV => ctx.ReadList(3).CastFloat();
                public IReadOnlyList<float> DeadzoneBP => ctx.ReadList(4).CastFloat();
                public IReadOnlyList<float> DeadzoneV => ctx.ReadList(5).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 6);
                }

                public ListOfPrimitivesSerializer<float> KpBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> KpV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> KiBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public ListOfPrimitivesSerializer<float> KiV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                    set => Link(3, value);
                }

                public ListOfPrimitivesSerializer<float> DeadzoneBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                    set => Link(4, value);
                }

                public ListOfPrimitivesSerializer<float> DeadzoneV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                    set => Link(5, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa334472e045533b3UL)]
        public class LateralINDITuning : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa334472e045533b3UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                OuterLoopGainDEPRECATED = reader.OuterLoopGainDEPRECATED;
                InnerLoopGainDEPRECATED = reader.InnerLoopGainDEPRECATED;
                TimeConstantDEPRECATED = reader.TimeConstantDEPRECATED;
                ActuatorEffectivenessDEPRECATED = reader.ActuatorEffectivenessDEPRECATED;
                OuterLoopGainBP = reader.OuterLoopGainBP;
                OuterLoopGainV = reader.OuterLoopGainV;
                InnerLoopGainBP = reader.InnerLoopGainBP;
                InnerLoopGainV = reader.InnerLoopGainV;
                TimeConstantBP = reader.TimeConstantBP;
                TimeConstantV = reader.TimeConstantV;
                ActuatorEffectivenessBP = reader.ActuatorEffectivenessBP;
                ActuatorEffectivenessV = reader.ActuatorEffectivenessV;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.OuterLoopGainDEPRECATED = OuterLoopGainDEPRECATED;
                writer.InnerLoopGainDEPRECATED = InnerLoopGainDEPRECATED;
                writer.TimeConstantDEPRECATED = TimeConstantDEPRECATED;
                writer.ActuatorEffectivenessDEPRECATED = ActuatorEffectivenessDEPRECATED;
                writer.OuterLoopGainBP.Init(OuterLoopGainBP);
                writer.OuterLoopGainV.Init(OuterLoopGainV);
                writer.InnerLoopGainBP.Init(InnerLoopGainBP);
                writer.InnerLoopGainV.Init(InnerLoopGainV);
                writer.TimeConstantBP.Init(TimeConstantBP);
                writer.TimeConstantV.Init(TimeConstantV);
                writer.ActuatorEffectivenessBP.Init(ActuatorEffectivenessBP);
                writer.ActuatorEffectivenessV.Init(ActuatorEffectivenessV);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float OuterLoopGainDEPRECATED
            {
                get;
                set;
            }

            public float InnerLoopGainDEPRECATED
            {
                get;
                set;
            }

            public float TimeConstantDEPRECATED
            {
                get;
                set;
            }

            public float ActuatorEffectivenessDEPRECATED
            {
                get;
                set;
            }

            public IReadOnlyList<float> OuterLoopGainBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> OuterLoopGainV
            {
                get;
                set;
            }

            public IReadOnlyList<float> InnerLoopGainBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> InnerLoopGainV
            {
                get;
                set;
            }

            public IReadOnlyList<float> TimeConstantBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> TimeConstantV
            {
                get;
                set;
            }

            public IReadOnlyList<float> ActuatorEffectivenessBP
            {
                get;
                set;
            }

            public IReadOnlyList<float> ActuatorEffectivenessV
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public float OuterLoopGainDEPRECATED => ctx.ReadDataFloat(0UL, 0F);
                public float InnerLoopGainDEPRECATED => ctx.ReadDataFloat(32UL, 0F);
                public float TimeConstantDEPRECATED => ctx.ReadDataFloat(64UL, 0F);
                public float ActuatorEffectivenessDEPRECATED => ctx.ReadDataFloat(96UL, 0F);
                public IReadOnlyList<float> OuterLoopGainBP => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> OuterLoopGainV => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> InnerLoopGainBP => ctx.ReadList(2).CastFloat();
                public IReadOnlyList<float> InnerLoopGainV => ctx.ReadList(3).CastFloat();
                public IReadOnlyList<float> TimeConstantBP => ctx.ReadList(4).CastFloat();
                public IReadOnlyList<float> TimeConstantV => ctx.ReadList(5).CastFloat();
                public IReadOnlyList<float> ActuatorEffectivenessBP => ctx.ReadList(6).CastFloat();
                public IReadOnlyList<float> ActuatorEffectivenessV => ctx.ReadList(7).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 8);
                }

                public float OuterLoopGainDEPRECATED
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float InnerLoopGainDEPRECATED
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float TimeConstantDEPRECATED
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float ActuatorEffectivenessDEPRECATED
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<float> OuterLoopGainBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> OuterLoopGainV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> InnerLoopGainBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public ListOfPrimitivesSerializer<float> InnerLoopGainV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                    set => Link(3, value);
                }

                public ListOfPrimitivesSerializer<float> TimeConstantBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                    set => Link(4, value);
                }

                public ListOfPrimitivesSerializer<float> TimeConstantV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                    set => Link(5, value);
                }

                public ListOfPrimitivesSerializer<float> ActuatorEffectivenessBP
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(6);
                    set => Link(6, value);
                }

                public ListOfPrimitivesSerializer<float> ActuatorEffectivenessV
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(7);
                    set => Link(7, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9d151e3f28616a12UL)]
        public class LateralLQRTuning : ICapnpSerializable
        {
            public const UInt64 typeId = 0x9d151e3f28616a12UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Scale = reader.Scale;
                Ki = reader.Ki;
                DcGain = reader.DcGain;
                A = reader.A;
                B = reader.B;
                C = reader.C;
                K = reader.K;
                L = reader.L;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Scale = Scale;
                writer.Ki = Ki;
                writer.DcGain = DcGain;
                writer.A.Init(A);
                writer.B.Init(B);
                writer.C.Init(C);
                writer.K.Init(K);
                writer.L.Init(L);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float Scale
            {
                get;
                set;
            }

            public float Ki
            {
                get;
                set;
            }

            public float DcGain
            {
                get;
                set;
            }

            public IReadOnlyList<float> A
            {
                get;
                set;
            }

            public IReadOnlyList<float> B
            {
                get;
                set;
            }

            public IReadOnlyList<float> C
            {
                get;
                set;
            }

            public IReadOnlyList<float> K
            {
                get;
                set;
            }

            public IReadOnlyList<float> L
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public float Scale => ctx.ReadDataFloat(0UL, 0F);
                public float Ki => ctx.ReadDataFloat(32UL, 0F);
                public float DcGain => ctx.ReadDataFloat(64UL, 0F);
                public IReadOnlyList<float> A => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> B => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> C => ctx.ReadList(2).CastFloat();
                public IReadOnlyList<float> K => ctx.ReadList(3).CastFloat();
                public IReadOnlyList<float> L => ctx.ReadList(4).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 5);
                }

                public float Scale
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float Ki
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float DcGain
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<float> A
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> B
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> C
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public ListOfPrimitivesSerializer<float> K
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                    set => Link(3, value);
                }

                public ListOfPrimitivesSerializer<float> L
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                    set => Link(4, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x95551e5b1edaf451UL)]
        public enum SafetyModel : ushort
        {
            silent,
            hondaNidec,
            toyota,
            elm327,
            gm,
            hondaBoschGiraffe,
            ford,
            cadillac,
            hyundai,
            chrysler,
            tesla,
            subaru,
            gmPassive,
            mazda,
            nissan,
            volkswagen,
            toyotaIpas,
            allOutput,
            gmAscm,
            noOutput,
            hondaBosch,
            volkswagenPq,
            subaruLegacy,
            hyundaiLegacy,
            hyundaiCommunity,
            stellantis
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd661512be2def77fUL)]
        public enum SteerControlType : ushort
        {
            torque,
            angle
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8f162eeb14bfc0ecUL)]
        public enum TransmissionType : ushort
        {
            unknown,
            automatic,
            manual,
            direct,
            cvt
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x962b56180c9359ceUL)]
        public class CarFw : ICapnpSerializable
        {
            public const UInt64 typeId = 0x962b56180c9359ceUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Ecu = reader.Ecu;
                FwVersion = reader.FwVersion;
                Address = reader.Address;
                SubAddress = reader.SubAddress;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Ecu = Ecu;
                writer.FwVersion.Init(FwVersion);
                writer.Address = Address;
                writer.SubAddress = SubAddress;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public Cereal.CarParams.Ecu Ecu
            {
                get;
                set;
            }

            public IReadOnlyList<byte> FwVersion
            {
                get;
                set;
            }

            public uint Address
            {
                get;
                set;
            }

            public byte SubAddress
            {
                get;
                set;
            }

            public struct READER
            {
                readonly DeserializerState ctx;
                public READER(DeserializerState ctx)
                {
                    this.ctx = ctx;
                }

                public static READER create(DeserializerState ctx) => new READER(ctx);
                public static implicit operator DeserializerState(READER reader) => reader.ctx;
                public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                public Cereal.CarParams.Ecu Ecu => (Cereal.CarParams.Ecu)ctx.ReadDataUShort(0UL, (ushort)0);
                public IReadOnlyList<byte> FwVersion => ctx.ReadList(0).CastByte();
                public uint Address => ctx.ReadDataUInt(32UL, 0U);
                public byte SubAddress => ctx.ReadDataByte(16UL, (byte)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 1);
                }

                public Cereal.CarParams.Ecu Ecu
                {
                    get => (Cereal.CarParams.Ecu)this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, (ushort)value, (ushort)0);
                }

                public ListOfPrimitivesSerializer<byte> FwVersion
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<byte>>(0);
                    set => Link(0, value);
                }

                public uint Address
                {
                    get => this.ReadDataUInt(32UL, 0U);
                    set => this.WriteData(32UL, value, 0U);
                }

                public byte SubAddress
                {
                    get => this.ReadDataByte(16UL, (byte)0);
                    set => this.WriteData(16UL, value, (byte)0);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf7119bb759d1d691UL)]
        public enum Ecu : ushort
        {
            eps,
            esp,
            fwdRadar,
            fwdCamera,
            engine,
            unknown,
            transmission,
            srs,
            gateway,
            hud,
            combinationMeter,
            dsu,
            apgs,
            vsa,
            programmedFuelInjection,
            electricBrakeBooster,
            shiftByWire
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9fd95523d8dc40ceUL)]
        public enum FingerprintSource : ushort
        {
            can,
            fw,
            @fixed
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xff99e3682a833c51UL)]
        public enum NetworkLocation : ushort
        {
            fwdCamera,
            gateway
        }
    }
}