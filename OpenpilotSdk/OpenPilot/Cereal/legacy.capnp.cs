using Capnp;
using Capnp.Rpc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cereal
{
    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9811e1f38f62f2d1UL)]
    public class LogRotate : ICapnpSerializable
    {
        public const UInt64 typeId = 0x9811e1f38f62f2d1UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            SegmentNum = reader.SegmentNum;
            Path = reader.Path;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.SegmentNum = SegmentNum;
            writer.Path = Path;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public int SegmentNum
        {
            get;
            set;
        }

        public string Path
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
            public int SegmentNum => ctx.ReadDataInt(0UL, 0);
            public string Path => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public int SegmentNum
            {
                get => this.ReadDataInt(0UL, 0);
                set => this.WriteData(0UL, value, 0);
            }

            public string Path
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc08240f996aefcedUL)]
    public class LiveUI : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc08240f996aefcedUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            RearViewCam = reader.RearViewCam;
            AlertText1 = reader.AlertText1;
            AlertText2 = reader.AlertText2;
            AwarenessStatus = reader.AwarenessStatus;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.RearViewCam = RearViewCam;
            writer.AlertText1 = AlertText1;
            writer.AlertText2 = AlertText2;
            writer.AwarenessStatus = AwarenessStatus;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool RearViewCam
        {
            get;
            set;
        }

        public string AlertText1
        {
            get;
            set;
        }

        public string AlertText2
        {
            get;
            set;
        }

        public float AwarenessStatus
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
            public bool RearViewCam => ctx.ReadDataBool(0UL, false);
            public string AlertText1 => ctx.ReadText(0, null);
            public string AlertText2 => ctx.ReadText(1, null);
            public float AwarenessStatus => ctx.ReadDataFloat(32UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 2);
            }

            public bool RearViewCam
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string AlertText1
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string AlertText2
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public float AwarenessStatus
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x88dcce08ad29dda0UL)]
    public class UiLayoutState : ICapnpSerializable
    {
        public const UInt64 typeId = 0x88dcce08ad29dda0UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            ActiveApp = reader.ActiveApp;
            SidebarCollapsed = reader.SidebarCollapsed;
            MapEnabled = reader.MapEnabled;
            MockEngaged = reader.MockEngaged;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.ActiveApp = ActiveApp;
            writer.SidebarCollapsed = SidebarCollapsed;
            writer.MapEnabled = MapEnabled;
            writer.MockEngaged = MockEngaged;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public Cereal.UiLayoutState.App ActiveApp
        {
            get;
            set;
        }

        public bool SidebarCollapsed
        {
            get;
            set;
        }

        public bool MapEnabled
        {
            get;
            set;
        }

        public bool MockEngaged
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
            public Cereal.UiLayoutState.App ActiveApp => (Cereal.UiLayoutState.App)ctx.ReadDataUShort(0UL, (ushort)0);
            public bool SidebarCollapsed => ctx.ReadDataBool(16UL, false);
            public bool MapEnabled => ctx.ReadDataBool(17UL, false);
            public bool MockEngaged => ctx.ReadDataBool(18UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public Cereal.UiLayoutState.App ActiveApp
            {
                get => (Cereal.UiLayoutState.App)this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, (ushort)value, (ushort)0);
            }

            public bool SidebarCollapsed
            {
                get => this.ReadDataBool(16UL, false);
                set => this.WriteData(16UL, value, false);
            }

            public bool MapEnabled
            {
                get => this.ReadDataBool(17UL, false);
                set => this.WriteData(17UL, value, false);
            }

            public bool MockEngaged
            {
                get => this.ReadDataBool(18UL, false);
                set => this.WriteData(18UL, value, false);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9917470acf94d285UL)]
        public enum App : ushort
        {
            home,
            music,
            nav,
            settings,
            none
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8afd33dc9b35e1aaUL)]
    public class OrbslamCorrection : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8afd33dc9b35e1aaUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            CorrectionMonoTime = reader.CorrectionMonoTime;
            PrePositionECEF = reader.PrePositionECEF;
            PostPositionECEF = reader.PostPositionECEF;
            PrePoseQuatECEF = reader.PrePoseQuatECEF;
            PostPoseQuatECEF = reader.PostPoseQuatECEF;
            NumInliers = reader.NumInliers;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.CorrectionMonoTime = CorrectionMonoTime;
            writer.PrePositionECEF.Init(PrePositionECEF);
            writer.PostPositionECEF.Init(PostPositionECEF);
            writer.PrePoseQuatECEF.Init(PrePoseQuatECEF);
            writer.PostPoseQuatECEF.Init(PostPoseQuatECEF);
            writer.NumInliers = NumInliers;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong CorrectionMonoTime
        {
            get;
            set;
        }

        public IReadOnlyList<double> PrePositionECEF
        {
            get;
            set;
        }

        public IReadOnlyList<double> PostPositionECEF
        {
            get;
            set;
        }

        public IReadOnlyList<float> PrePoseQuatECEF
        {
            get;
            set;
        }

        public IReadOnlyList<float> PostPoseQuatECEF
        {
            get;
            set;
        }

        public uint NumInliers
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
            public ulong CorrectionMonoTime => ctx.ReadDataULong(0UL, 0UL);
            public IReadOnlyList<double> PrePositionECEF => ctx.ReadList(0).CastDouble();
            public IReadOnlyList<double> PostPositionECEF => ctx.ReadList(1).CastDouble();
            public IReadOnlyList<float> PrePoseQuatECEF => ctx.ReadList(2).CastFloat();
            public IReadOnlyList<float> PostPoseQuatECEF => ctx.ReadList(3).CastFloat();
            public uint NumInliers => ctx.ReadDataUInt(64UL, 0U);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 4);
            }

            public ulong CorrectionMonoTime
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<double> PrePositionECEF
            {
                get => BuildPointer<ListOfPrimitivesSerializer<double>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<double> PostPositionECEF
            {
                get => BuildPointer<ListOfPrimitivesSerializer<double>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> PrePoseQuatECEF
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public ListOfPrimitivesSerializer<float> PostPoseQuatECEF
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public uint NumInliers
            {
                get => this.ReadDataUInt(64UL, 0U);
                set => this.WriteData(64UL, value, 0U);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa99a9d5b33cf5859UL)]
    public class EthernetPacket : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa99a9d5b33cf5859UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Pkt = reader.Pkt;
            Ts = reader.Ts;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Pkt.Init(Pkt);
            writer.Ts = Ts;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<byte> Pkt
        {
            get;
            set;
        }

        public float Ts
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
            public IReadOnlyList<byte> Pkt => ctx.ReadList(0).CastByte();
            public float Ts => ctx.ReadDataFloat(0UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public ListOfPrimitivesSerializer<byte> Pkt
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(0);
                set => Link(0, value);
            }

            public float Ts
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xcff7566681c277ceUL)]
    public class CellInfo : ICapnpSerializable
    {
        public const UInt64 typeId = 0xcff7566681c277ceUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Timestamp = reader.Timestamp;
            Repr = reader.Repr;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Timestamp = Timestamp;
            writer.Repr = Repr;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong Timestamp
        {
            get;
            set;
        }

        public string Repr
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
            public ulong Timestamp => ctx.ReadDataULong(0UL, 0UL);
            public string Repr => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public ulong Timestamp
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public string Repr
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd4df5a192382ba0bUL)]
    public class WifiScan : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd4df5a192382ba0bUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Bssid = reader.Bssid;
            Ssid = reader.Ssid;
            Capabilities = reader.Capabilities;
            Frequency = reader.Frequency;
            Level = reader.Level;
            Timestamp = reader.Timestamp;
            CenterFreq0 = reader.CenterFreq0;
            CenterFreq1 = reader.CenterFreq1;
            TheChannelWidth = reader.TheChannelWidth;
            OperatorFriendlyName = reader.OperatorFriendlyName;
            VenueName = reader.VenueName;
            Is80211mcResponder = reader.Is80211mcResponder;
            Passpoint = reader.Passpoint;
            DistanceCm = reader.DistanceCm;
            DistanceSdCm = reader.DistanceSdCm;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Bssid = Bssid;
            writer.Ssid = Ssid;
            writer.Capabilities = Capabilities;
            writer.Frequency = Frequency;
            writer.Level = Level;
            writer.Timestamp = Timestamp;
            writer.CenterFreq0 = CenterFreq0;
            writer.CenterFreq1 = CenterFreq1;
            writer.TheChannelWidth = TheChannelWidth;
            writer.OperatorFriendlyName = OperatorFriendlyName;
            writer.VenueName = VenueName;
            writer.Is80211mcResponder = Is80211mcResponder;
            writer.Passpoint = Passpoint;
            writer.DistanceCm = DistanceCm;
            writer.DistanceSdCm = DistanceSdCm;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Bssid
        {
            get;
            set;
        }

        public string Ssid
        {
            get;
            set;
        }

        public string Capabilities
        {
            get;
            set;
        }

        public int Frequency
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

        public long Timestamp
        {
            get;
            set;
        }

        public int CenterFreq0
        {
            get;
            set;
        }

        public int CenterFreq1
        {
            get;
            set;
        }

        public Cereal.WifiScan.ChannelWidth TheChannelWidth
        {
            get;
            set;
        }

        public string OperatorFriendlyName
        {
            get;
            set;
        }

        public string VenueName
        {
            get;
            set;
        }

        public bool Is80211mcResponder
        {
            get;
            set;
        }

        public bool Passpoint
        {
            get;
            set;
        }

        public int DistanceCm
        {
            get;
            set;
        }

        public int DistanceSdCm
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
            public string Bssid => ctx.ReadText(0, null);
            public string Ssid => ctx.ReadText(1, null);
            public string Capabilities => ctx.ReadText(2, null);
            public int Frequency => ctx.ReadDataInt(0UL, 0);
            public int Level => ctx.ReadDataInt(32UL, 0);
            public long Timestamp => ctx.ReadDataLong(64UL, 0L);
            public int CenterFreq0 => ctx.ReadDataInt(128UL, 0);
            public int CenterFreq1 => ctx.ReadDataInt(160UL, 0);
            public Cereal.WifiScan.ChannelWidth TheChannelWidth => (Cereal.WifiScan.ChannelWidth)ctx.ReadDataUShort(192UL, (ushort)0);
            public string OperatorFriendlyName => ctx.ReadText(3, null);
            public string VenueName => ctx.ReadText(4, null);
            public bool Is80211mcResponder => ctx.ReadDataBool(208UL, false);
            public bool Passpoint => ctx.ReadDataBool(209UL, false);
            public int DistanceCm => ctx.ReadDataInt(224UL, 0);
            public int DistanceSdCm => ctx.ReadDataInt(256UL, 0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(5, 5);
            }

            public string Bssid
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string Ssid
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string Capabilities
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public int Frequency
            {
                get => this.ReadDataInt(0UL, 0);
                set => this.WriteData(0UL, value, 0);
            }

            public int Level
            {
                get => this.ReadDataInt(32UL, 0);
                set => this.WriteData(32UL, value, 0);
            }

            public long Timestamp
            {
                get => this.ReadDataLong(64UL, 0L);
                set => this.WriteData(64UL, value, 0L);
            }

            public int CenterFreq0
            {
                get => this.ReadDataInt(128UL, 0);
                set => this.WriteData(128UL, value, 0);
            }

            public int CenterFreq1
            {
                get => this.ReadDataInt(160UL, 0);
                set => this.WriteData(160UL, value, 0);
            }

            public Cereal.WifiScan.ChannelWidth TheChannelWidth
            {
                get => (Cereal.WifiScan.ChannelWidth)this.ReadDataUShort(192UL, (ushort)0);
                set => this.WriteData(192UL, (ushort)value, (ushort)0);
            }

            public string OperatorFriendlyName
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public string VenueName
            {
                get => this.ReadText(4, null);
                set => this.WriteText(4, value, null);
            }

            public bool Is80211mcResponder
            {
                get => this.ReadDataBool(208UL, false);
                set => this.WriteData(208UL, value, false);
            }

            public bool Passpoint
            {
                get => this.ReadDataBool(209UL, false);
                set => this.WriteData(209UL, value, false);
            }

            public int DistanceCm
            {
                get => this.ReadDataInt(224UL, 0);
                set => this.WriteData(224UL, value, 0);
            }

            public int DistanceSdCm
            {
                get => this.ReadDataInt(256UL, 0);
                set => this.WriteData(256UL, value, 0);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xcb6a279f015f6b51UL)]
        public enum ChannelWidth : ushort
        {
            w20Mhz,
            w40Mhz,
            w80Mhz,
            w160Mhz,
            w80Plus80Mhz
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x94b7baa90c5c321eUL)]
    public class LiveEventData : ICapnpSerializable
    {
        public const UInt64 typeId = 0x94b7baa90c5c321eUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Name = reader.Name;
            Value = reader.Value;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Name = Name;
            writer.Value = Value;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string Name
        {
            get;
            set;
        }

        public int Value
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
            public string Name => ctx.ReadText(0, null);
            public int Value => ctx.ReadDataInt(0UL, 0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public string Name
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public int Value
            {
                get => this.ReadDataInt(0UL, 0);
                set => this.WriteData(0UL, value, 0);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb8aad62cffef28a9UL)]
    public class ModelData : ICapnpSerializable
    {
        public const UInt64 typeId = 0xb8aad62cffef28a9UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            FrameId = reader.FrameId;
            Path = CapnpSerializable.Create<Cereal.ModelData.PathData>(reader.Path);
            LeftLane = CapnpSerializable.Create<Cereal.ModelData.PathData>(reader.LeftLane);
            RightLane = CapnpSerializable.Create<Cereal.ModelData.PathData>(reader.RightLane);
            Lead = CapnpSerializable.Create<Cereal.ModelData.LeadData>(reader.Lead);
            Settings = CapnpSerializable.Create<Cereal.ModelData.ModelSettings>(reader.Settings);
            FreePath = reader.FreePath;
            LeadFuture = CapnpSerializable.Create<Cereal.ModelData.LeadData>(reader.LeadFuture);
            Speed = reader.Speed;
            TimestampEof = reader.TimestampEof;
            Meta = CapnpSerializable.Create<Cereal.ModelData.MetaData>(reader.Meta);
            Longitudinal = CapnpSerializable.Create<Cereal.ModelData.LongitudinalData>(reader.Longitudinal);
            FrameAge = reader.FrameAge;
            FrameDropPerc = reader.FrameDropPerc;
            ModelExecutionTime = reader.ModelExecutionTime;
            RawPred = reader.RawPred;
            GpuExecutionTime = reader.GpuExecutionTime;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.FrameId = FrameId;
            Path?.serialize(writer.Path);
            LeftLane?.serialize(writer.LeftLane);
            RightLane?.serialize(writer.RightLane);
            Lead?.serialize(writer.Lead);
            Settings?.serialize(writer.Settings);
            writer.FreePath.Init(FreePath);
            LeadFuture?.serialize(writer.LeadFuture);
            writer.Speed.Init(Speed);
            writer.TimestampEof = TimestampEof;
            Meta?.serialize(writer.Meta);
            Longitudinal?.serialize(writer.Longitudinal);
            writer.FrameAge = FrameAge;
            writer.FrameDropPerc = FrameDropPerc;
            writer.ModelExecutionTime = ModelExecutionTime;
            writer.RawPred.Init(RawPred);
            writer.GpuExecutionTime = GpuExecutionTime;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public uint FrameId
        {
            get;
            set;
        }

        public Cereal.ModelData.PathData Path
        {
            get;
            set;
        }

        public Cereal.ModelData.PathData LeftLane
        {
            get;
            set;
        }

        public Cereal.ModelData.PathData RightLane
        {
            get;
            set;
        }

        public Cereal.ModelData.LeadData Lead
        {
            get;
            set;
        }

        public Cereal.ModelData.ModelSettings Settings
        {
            get;
            set;
        }

        public IReadOnlyList<float> FreePath
        {
            get;
            set;
        }

        public Cereal.ModelData.LeadData LeadFuture
        {
            get;
            set;
        }

        public IReadOnlyList<float> Speed
        {
            get;
            set;
        }

        public ulong TimestampEof
        {
            get;
            set;
        }

        public Cereal.ModelData.MetaData Meta
        {
            get;
            set;
        }

        public Cereal.ModelData.LongitudinalData Longitudinal
        {
            get;
            set;
        }

        public uint FrameAge
        {
            get;
            set;
        }

        public float FrameDropPerc
        {
            get;
            set;
        }

        public float ModelExecutionTime
        {
            get;
            set;
        }

        public IReadOnlyList<byte> RawPred
        {
            get;
            set;
        }

        public float GpuExecutionTime
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
            public uint FrameId => ctx.ReadDataUInt(0UL, 0U);
            public Cereal.ModelData.PathData.READER Path => ctx.ReadStruct(0, Cereal.ModelData.PathData.READER.create);
            public Cereal.ModelData.PathData.READER LeftLane => ctx.ReadStruct(1, Cereal.ModelData.PathData.READER.create);
            public Cereal.ModelData.PathData.READER RightLane => ctx.ReadStruct(2, Cereal.ModelData.PathData.READER.create);
            public Cereal.ModelData.LeadData.READER Lead => ctx.ReadStruct(3, Cereal.ModelData.LeadData.READER.create);
            public Cereal.ModelData.ModelSettings.READER Settings => ctx.ReadStruct(4, Cereal.ModelData.ModelSettings.READER.create);
            public IReadOnlyList<float> FreePath => ctx.ReadList(5).CastFloat();
            public Cereal.ModelData.LeadData.READER LeadFuture => ctx.ReadStruct(6, Cereal.ModelData.LeadData.READER.create);
            public IReadOnlyList<float> Speed => ctx.ReadList(7).CastFloat();
            public ulong TimestampEof => ctx.ReadDataULong(64UL, 0UL);
            public Cereal.ModelData.MetaData.READER Meta => ctx.ReadStruct(8, Cereal.ModelData.MetaData.READER.create);
            public Cereal.ModelData.LongitudinalData.READER Longitudinal => ctx.ReadStruct(9, Cereal.ModelData.LongitudinalData.READER.create);
            public uint FrameAge => ctx.ReadDataUInt(32UL, 0U);
            public float FrameDropPerc => ctx.ReadDataFloat(128UL, 0F);
            public float ModelExecutionTime => ctx.ReadDataFloat(160UL, 0F);
            public IReadOnlyList<byte> RawPred => ctx.ReadList(10).CastByte();
            public float GpuExecutionTime => ctx.ReadDataFloat(192UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(4, 11);
            }

            public uint FrameId
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public Cereal.ModelData.PathData.WRITER Path
            {
                get => BuildPointer<Cereal.ModelData.PathData.WRITER>(0);
                set => Link(0, value);
            }

            public Cereal.ModelData.PathData.WRITER LeftLane
            {
                get => BuildPointer<Cereal.ModelData.PathData.WRITER>(1);
                set => Link(1, value);
            }

            public Cereal.ModelData.PathData.WRITER RightLane
            {
                get => BuildPointer<Cereal.ModelData.PathData.WRITER>(2);
                set => Link(2, value);
            }

            public Cereal.ModelData.LeadData.WRITER Lead
            {
                get => BuildPointer<Cereal.ModelData.LeadData.WRITER>(3);
                set => Link(3, value);
            }

            public Cereal.ModelData.ModelSettings.WRITER Settings
            {
                get => BuildPointer<Cereal.ModelData.ModelSettings.WRITER>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<float> FreePath
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public Cereal.ModelData.LeadData.WRITER LeadFuture
            {
                get => BuildPointer<Cereal.ModelData.LeadData.WRITER>(6);
                set => Link(6, value);
            }

            public ListOfPrimitivesSerializer<float> Speed
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(7);
                set => Link(7, value);
            }

            public ulong TimestampEof
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public Cereal.ModelData.MetaData.WRITER Meta
            {
                get => BuildPointer<Cereal.ModelData.MetaData.WRITER>(8);
                set => Link(8, value);
            }

            public Cereal.ModelData.LongitudinalData.WRITER Longitudinal
            {
                get => BuildPointer<Cereal.ModelData.LongitudinalData.WRITER>(9);
                set => Link(9, value);
            }

            public uint FrameAge
            {
                get => this.ReadDataUInt(32UL, 0U);
                set => this.WriteData(32UL, value, 0U);
            }

            public float FrameDropPerc
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float ModelExecutionTime
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<byte> RawPred
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(10);
                set => Link(10, value);
            }

            public float GpuExecutionTime
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8817eeea389e9f08UL)]
        public class PathData : ICapnpSerializable
        {
            public const UInt64 typeId = 0x8817eeea389e9f08UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Points = reader.Points;
                Prob = reader.Prob;
                Std = reader.Std;
                Stds = reader.Stds;
                Poly = reader.Poly;
                ValidLen = reader.ValidLen;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Points.Init(Points);
                writer.Prob = Prob;
                writer.Std = Std;
                writer.Stds.Init(Stds);
                writer.Poly.Init(Poly);
                writer.ValidLen = ValidLen;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> Points
            {
                get;
                set;
            }

            public float Prob
            {
                get;
                set;
            }

            public float Std
            {
                get;
                set;
            }

            public IReadOnlyList<float> Stds
            {
                get;
                set;
            }

            public IReadOnlyList<float> Poly
            {
                get;
                set;
            }

            public float ValidLen
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
                public IReadOnlyList<float> Points => ctx.ReadList(0).CastFloat();
                public float Prob => ctx.ReadDataFloat(0UL, 0F);
                public float Std => ctx.ReadDataFloat(32UL, 0F);
                public IReadOnlyList<float> Stds => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> Poly => ctx.ReadList(2).CastFloat();
                public float ValidLen => ctx.ReadDataFloat(64UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 3);
                }

                public ListOfPrimitivesSerializer<float> Points
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public float Prob
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float Std
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<float> Stds
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> Poly
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public float ValidLen
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd1c9bef96d26fa91UL)]
        public class LeadData : ICapnpSerializable
        {
            public const UInt64 typeId = 0xd1c9bef96d26fa91UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Dist = reader.Dist;
                Prob = reader.Prob;
                Std = reader.Std;
                RelVel = reader.RelVel;
                RelVelStd = reader.RelVelStd;
                RelY = reader.RelY;
                RelYStd = reader.RelYStd;
                RelA = reader.RelA;
                RelAStd = reader.RelAStd;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Dist = Dist;
                writer.Prob = Prob;
                writer.Std = Std;
                writer.RelVel = RelVel;
                writer.RelVelStd = RelVelStd;
                writer.RelY = RelY;
                writer.RelYStd = RelYStd;
                writer.RelA = RelA;
                writer.RelAStd = RelAStd;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float Dist
            {
                get;
                set;
            }

            public float Prob
            {
                get;
                set;
            }

            public float Std
            {
                get;
                set;
            }

            public float RelVel
            {
                get;
                set;
            }

            public float RelVelStd
            {
                get;
                set;
            }

            public float RelY
            {
                get;
                set;
            }

            public float RelYStd
            {
                get;
                set;
            }

            public float RelA
            {
                get;
                set;
            }

            public float RelAStd
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
                public float Dist => ctx.ReadDataFloat(0UL, 0F);
                public float Prob => ctx.ReadDataFloat(32UL, 0F);
                public float Std => ctx.ReadDataFloat(64UL, 0F);
                public float RelVel => ctx.ReadDataFloat(96UL, 0F);
                public float RelVelStd => ctx.ReadDataFloat(128UL, 0F);
                public float RelY => ctx.ReadDataFloat(160UL, 0F);
                public float RelYStd => ctx.ReadDataFloat(192UL, 0F);
                public float RelA => ctx.ReadDataFloat(224UL, 0F);
                public float RelAStd => ctx.ReadDataFloat(256UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(5, 0);
                }

                public float Dist
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float Prob
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float Std
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float RelVel
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float RelVelStd
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float RelY
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float RelYStd
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public float RelA
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public float RelAStd
                {
                    get => this.ReadDataFloat(256UL, 0F);
                    set => this.WriteData(256UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa26e3710efd3e914UL)]
        public class ModelSettings : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa26e3710efd3e914UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                BigBoxX = reader.BigBoxX;
                BigBoxY = reader.BigBoxY;
                BigBoxWidth = reader.BigBoxWidth;
                BigBoxHeight = reader.BigBoxHeight;
                BoxProjection = reader.BoxProjection;
                YuvCorrection = reader.YuvCorrection;
                InputTransform = reader.InputTransform;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.BigBoxX = BigBoxX;
                writer.BigBoxY = BigBoxY;
                writer.BigBoxWidth = BigBoxWidth;
                writer.BigBoxHeight = BigBoxHeight;
                writer.BoxProjection.Init(BoxProjection);
                writer.YuvCorrection.Init(YuvCorrection);
                writer.InputTransform.Init(InputTransform);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public ushort BigBoxX
            {
                get;
                set;
            }

            public ushort BigBoxY
            {
                get;
                set;
            }

            public ushort BigBoxWidth
            {
                get;
                set;
            }

            public ushort BigBoxHeight
            {
                get;
                set;
            }

            public IReadOnlyList<float> BoxProjection
            {
                get;
                set;
            }

            public IReadOnlyList<float> YuvCorrection
            {
                get;
                set;
            }

            public IReadOnlyList<float> InputTransform
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
                public ushort BigBoxX => ctx.ReadDataUShort(0UL, (ushort)0);
                public ushort BigBoxY => ctx.ReadDataUShort(16UL, (ushort)0);
                public ushort BigBoxWidth => ctx.ReadDataUShort(32UL, (ushort)0);
                public ushort BigBoxHeight => ctx.ReadDataUShort(48UL, (ushort)0);
                public IReadOnlyList<float> BoxProjection => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> YuvCorrection => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> InputTransform => ctx.ReadList(2).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 3);
                }

                public ushort BigBoxX
                {
                    get => this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, value, (ushort)0);
                }

                public ushort BigBoxY
                {
                    get => this.ReadDataUShort(16UL, (ushort)0);
                    set => this.WriteData(16UL, value, (ushort)0);
                }

                public ushort BigBoxWidth
                {
                    get => this.ReadDataUShort(32UL, (ushort)0);
                    set => this.WriteData(32UL, value, (ushort)0);
                }

                public ushort BigBoxHeight
                {
                    get => this.ReadDataUShort(48UL, (ushort)0);
                    set => this.WriteData(48UL, value, (ushort)0);
                }

                public ListOfPrimitivesSerializer<float> BoxProjection
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> YuvCorrection
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> InputTransform
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9744f25fb60f2bf8UL)]
        public class MetaData : ICapnpSerializable
        {
            public const UInt64 typeId = 0x9744f25fb60f2bf8UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                EngagedProb = reader.EngagedProb;
                DesirePrediction = reader.DesirePrediction;
                BrakeDisengageProb = reader.BrakeDisengageProb;
                GasDisengageProb = reader.GasDisengageProb;
                SteerOverrideProb = reader.SteerOverrideProb;
                DesireState = reader.DesireState;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.EngagedProb = EngagedProb;
                writer.DesirePrediction.Init(DesirePrediction);
                writer.BrakeDisengageProb = BrakeDisengageProb;
                writer.GasDisengageProb = GasDisengageProb;
                writer.SteerOverrideProb = SteerOverrideProb;
                writer.DesireState.Init(DesireState);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float EngagedProb
            {
                get;
                set;
            }

            public IReadOnlyList<float> DesirePrediction
            {
                get;
                set;
            }

            public float BrakeDisengageProb
            {
                get;
                set;
            }

            public float GasDisengageProb
            {
                get;
                set;
            }

            public float SteerOverrideProb
            {
                get;
                set;
            }

            public IReadOnlyList<float> DesireState
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
                public float EngagedProb => ctx.ReadDataFloat(0UL, 0F);
                public IReadOnlyList<float> DesirePrediction => ctx.ReadList(0).CastFloat();
                public float BrakeDisengageProb => ctx.ReadDataFloat(32UL, 0F);
                public float GasDisengageProb => ctx.ReadDataFloat(64UL, 0F);
                public float SteerOverrideProb => ctx.ReadDataFloat(96UL, 0F);
                public IReadOnlyList<float> DesireState => ctx.ReadList(1).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 2);
                }

                public float EngagedProb
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<float> DesirePrediction
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public float BrakeDisengageProb
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float GasDisengageProb
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float SteerOverrideProb
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<float> DesireState
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf98f999c6a071122UL)]
        public class LongitudinalData : ICapnpSerializable
        {
            public const UInt64 typeId = 0xf98f999c6a071122UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Speeds = reader.Speeds;
                Accelerations = reader.Accelerations;
                Distances = reader.Distances;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Speeds.Init(Speeds);
                writer.Accelerations.Init(Accelerations);
                writer.Distances.Init(Distances);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> Speeds
            {
                get;
                set;
            }

            public IReadOnlyList<float> Accelerations
            {
                get;
                set;
            }

            public IReadOnlyList<float> Distances
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
                public IReadOnlyList<float> Speeds => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> Accelerations => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> Distances => ctx.ReadList(2).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 3);
                }

                public ListOfPrimitivesSerializer<float> Speeds
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> Accelerations
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> Distances
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc25bbbd524983447UL)]
    public class ECEFPoint : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc25bbbd524983447UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            X = reader.X;
            Y = reader.Y;
            Z = reader.Z;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.X = X;
            writer.Y = Y;
            writer.Z = Z;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }

        public double Z
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
            public double X => ctx.ReadDataDouble(0UL, 0);
            public double Y => ctx.ReadDataDouble(64UL, 0);
            public double Z => ctx.ReadDataDouble(128UL, 0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(3, 0);
            }

            public double X
            {
                get => this.ReadDataDouble(0UL, 0);
                set => this.WriteData(0UL, value, 0);
            }

            public double Y
            {
                get => this.ReadDataDouble(64UL, 0);
                set => this.WriteData(64UL, value, 0);
            }

            public double Z
            {
                get => this.ReadDataDouble(128UL, 0);
                set => this.WriteData(128UL, value, 0);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe10e21168db0c7f7UL)]
    public class ECEFPointDEPRECATED : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe10e21168db0c7f7UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            X = reader.X;
            Y = reader.Y;
            Z = reader.Z;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.X = X;
            writer.Y = Y;
            writer.Z = Z;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

        public float Z
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
            public float X => ctx.ReadDataFloat(0UL, 0F);
            public float Y => ctx.ReadDataFloat(32UL, 0F);
            public float Z => ctx.ReadDataFloat(64UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 0);
            }

            public float X
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }

            public float Y
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float Z
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xab54c59699f8f9f3UL)]
    public class GPSPlannerPoints : ICapnpSerializable
    {
        public const UInt64 typeId = 0xab54c59699f8f9f3UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            CurPosDEPRECATED = CapnpSerializable.Create<Cereal.ECEFPointDEPRECATED>(reader.CurPosDEPRECATED);
            PointsDEPRECATED = reader.PointsDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ECEFPointDEPRECATED>(_));
            Valid = reader.Valid;
            TrackName = reader.TrackName;
            SpeedLimit = reader.SpeedLimit;
            AccelTarget = reader.AccelTarget;
            CurPos = CapnpSerializable.Create<Cereal.ECEFPoint>(reader.CurPos);
            Points = reader.Points?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ECEFPoint>(_));
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            CurPosDEPRECATED?.serialize(writer.CurPosDEPRECATED);
            writer.PointsDEPRECATED.Init(PointsDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
            writer.Valid = Valid;
            writer.TrackName = TrackName;
            writer.SpeedLimit = SpeedLimit;
            writer.AccelTarget = AccelTarget;
            CurPos?.serialize(writer.CurPos);
            writer.Points.Init(Points, (_s1, _v1) => _v1?.serialize(_s1));
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public Cereal.ECEFPointDEPRECATED CurPosDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ECEFPointDEPRECATED> PointsDEPRECATED
        {
            get;
            set;
        }

        public bool Valid
        {
            get;
            set;
        }

        public string TrackName
        {
            get;
            set;
        }

        public float SpeedLimit
        {
            get;
            set;
        }

        public float AccelTarget
        {
            get;
            set;
        }

        public Cereal.ECEFPoint CurPos
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ECEFPoint> Points
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
            public Cereal.ECEFPointDEPRECATED.READER CurPosDEPRECATED => ctx.ReadStruct(0, Cereal.ECEFPointDEPRECATED.READER.create);
            public IReadOnlyList<Cereal.ECEFPointDEPRECATED.READER> PointsDEPRECATED => ctx.ReadList(1).Cast(Cereal.ECEFPointDEPRECATED.READER.create);
            public bool Valid => ctx.ReadDataBool(0UL, false);
            public string TrackName => ctx.ReadText(2, null);
            public float SpeedLimit => ctx.ReadDataFloat(32UL, 0F);
            public float AccelTarget => ctx.ReadDataFloat(64UL, 0F);
            public Cereal.ECEFPoint.READER CurPos => ctx.ReadStruct(3, Cereal.ECEFPoint.READER.create);
            public IReadOnlyList<Cereal.ECEFPoint.READER> Points => ctx.ReadList(4).Cast(Cereal.ECEFPoint.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 5);
            }

            public Cereal.ECEFPointDEPRECATED.WRITER CurPosDEPRECATED
            {
                get => BuildPointer<Cereal.ECEFPointDEPRECATED.WRITER>(0);
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.ECEFPointDEPRECATED.WRITER> PointsDEPRECATED
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ECEFPointDEPRECATED.WRITER>>(1);
                set => Link(1, value);
            }

            public bool Valid
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public string TrackName
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public float SpeedLimit
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float AccelTarget
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public Cereal.ECEFPoint.WRITER CurPos
            {
                get => BuildPointer<Cereal.ECEFPoint.WRITER>(3);
                set => Link(3, value);
            }

            public ListOfStructsSerializer<Cereal.ECEFPoint.WRITER> Points
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ECEFPoint.WRITER>>(4);
                set => Link(4, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf5ad1d90cdc1dd6bUL)]
    public class GPSPlannerPlan : ICapnpSerializable
    {
        public const UInt64 typeId = 0xf5ad1d90cdc1dd6bUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Valid = reader.Valid;
            Poly = reader.Poly;
            TrackName = reader.TrackName;
            Speed = reader.Speed;
            Acceleration = reader.Acceleration;
            PointsDEPRECATED = reader.PointsDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ECEFPointDEPRECATED>(_));
            Points = reader.Points?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ECEFPoint>(_));
            XLookahead = reader.XLookahead;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Valid = Valid;
            writer.Poly.Init(Poly);
            writer.TrackName = TrackName;
            writer.Speed = Speed;
            writer.Acceleration = Acceleration;
            writer.PointsDEPRECATED.Init(PointsDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
            writer.Points.Init(Points, (_s1, _v1) => _v1?.serialize(_s1));
            writer.XLookahead = XLookahead;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool Valid
        {
            get;
            set;
        }

        public IReadOnlyList<float> Poly
        {
            get;
            set;
        }

        public string TrackName
        {
            get;
            set;
        }

        public float Speed
        {
            get;
            set;
        }

        public float Acceleration
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ECEFPointDEPRECATED> PointsDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ECEFPoint> Points
        {
            get;
            set;
        }

        public float XLookahead
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
            public bool Valid => ctx.ReadDataBool(0UL, false);
            public IReadOnlyList<float> Poly => ctx.ReadList(0).CastFloat();
            public string TrackName => ctx.ReadText(1, null);
            public float Speed => ctx.ReadDataFloat(32UL, 0F);
            public float Acceleration => ctx.ReadDataFloat(64UL, 0F);
            public IReadOnlyList<Cereal.ECEFPointDEPRECATED.READER> PointsDEPRECATED => ctx.ReadList(2).Cast(Cereal.ECEFPointDEPRECATED.READER.create);
            public IReadOnlyList<Cereal.ECEFPoint.READER> Points => ctx.ReadList(3).Cast(Cereal.ECEFPoint.READER.create);
            public float XLookahead => ctx.ReadDataFloat(96UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 4);
            }

            public bool Valid
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public ListOfPrimitivesSerializer<float> Poly
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public string TrackName
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public float Speed
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float Acceleration
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public ListOfStructsSerializer<Cereal.ECEFPointDEPRECATED.WRITER> PointsDEPRECATED
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ECEFPointDEPRECATED.WRITER>>(2);
                set => Link(2, value);
            }

            public ListOfStructsSerializer<Cereal.ECEFPoint.WRITER> Points
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ECEFPoint.WRITER>>(3);
                set => Link(3, value);
            }

            public float XLookahead
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x90c8426c3eaddd3bUL)]
    public class UiNavigationEvent : ICapnpSerializable
    {
        public const UInt64 typeId = 0x90c8426c3eaddd3bUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            TheType = reader.TheType;
            TheStatus = reader.TheStatus;
            DistanceTo = reader.DistanceTo;
            EndRoadPointDEPRECATED = CapnpSerializable.Create<Cereal.ECEFPointDEPRECATED>(reader.EndRoadPointDEPRECATED);
            EndRoadPoint = CapnpSerializable.Create<Cereal.ECEFPoint>(reader.EndRoadPoint);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.TheType = TheType;
            writer.TheStatus = TheStatus;
            writer.DistanceTo = DistanceTo;
            EndRoadPointDEPRECATED?.serialize(writer.EndRoadPointDEPRECATED);
            EndRoadPoint?.serialize(writer.EndRoadPoint);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public Cereal.UiNavigationEvent.Type TheType
        {
            get;
            set;
        }

        public Cereal.UiNavigationEvent.Status TheStatus
        {
            get;
            set;
        }

        public float DistanceTo
        {
            get;
            set;
        }

        public Cereal.ECEFPointDEPRECATED EndRoadPointDEPRECATED
        {
            get;
            set;
        }

        public Cereal.ECEFPoint EndRoadPoint
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
            public Cereal.UiNavigationEvent.Type TheType => (Cereal.UiNavigationEvent.Type)ctx.ReadDataUShort(0UL, (ushort)0);
            public Cereal.UiNavigationEvent.Status TheStatus => (Cereal.UiNavigationEvent.Status)ctx.ReadDataUShort(16UL, (ushort)0);
            public float DistanceTo => ctx.ReadDataFloat(32UL, 0F);
            public Cereal.ECEFPointDEPRECATED.READER EndRoadPointDEPRECATED => ctx.ReadStruct(0, Cereal.ECEFPointDEPRECATED.READER.create);
            public Cereal.ECEFPoint.READER EndRoadPoint => ctx.ReadStruct(1, Cereal.ECEFPoint.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 2);
            }

            public Cereal.UiNavigationEvent.Type TheType
            {
                get => (Cereal.UiNavigationEvent.Type)this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, (ushort)value, (ushort)0);
            }

            public Cereal.UiNavigationEvent.Status TheStatus
            {
                get => (Cereal.UiNavigationEvent.Status)this.ReadDataUShort(16UL, (ushort)0);
                set => this.WriteData(16UL, (ushort)value, (ushort)0);
            }

            public float DistanceTo
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public Cereal.ECEFPointDEPRECATED.WRITER EndRoadPointDEPRECATED
            {
                get => BuildPointer<Cereal.ECEFPointDEPRECATED.WRITER>(0);
                set => Link(0, value);
            }

            public Cereal.ECEFPoint.WRITER EndRoadPoint
            {
                get => BuildPointer<Cereal.ECEFPoint.WRITER>(1);
                set => Link(1, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe8db07dcf8fcea05UL)]
        public enum Type : ushort
        {
            none,
            laneChangeLeft,
            laneChangeRight,
            mergeLeft,
            mergeRight,
            turnLeft,
            turnRight
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb9aa88c75ef99a1fUL)]
        public enum Status : ushort
        {
            none,
            passive,
            approaching,
            active
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb99b2bc7a57e8128UL)]
    public class LiveLocationData : ICapnpSerializable
    {
        public const UInt64 typeId = 0xb99b2bc7a57e8128UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Status = reader.Status;
            Lat = reader.Lat;
            Lon = reader.Lon;
            Alt = reader.Alt;
            Speed = reader.Speed;
            VNED = reader.VNED;
            Roll = reader.Roll;
            Pitch = reader.Pitch;
            Heading = reader.Heading;
            WanderAngle = reader.WanderAngle;
            TrackAngle = reader.TrackAngle;
            Gyro = reader.Gyro;
            Accel = reader.Accel;
            TheAccuracy = CapnpSerializable.Create<Cereal.LiveLocationData.Accuracy>(reader.TheAccuracy);
            Source = reader.Source;
            FixMonoTime = reader.FixMonoTime;
            GpsWeek = reader.GpsWeek;
            TimeOfWeek = reader.TimeOfWeek;
            PositionECEF = reader.PositionECEF;
            PoseQuatECEF = reader.PoseQuatECEF;
            PitchCalibration = reader.PitchCalibration;
            YawCalibration = reader.YawCalibration;
            ImuFrame = reader.ImuFrame;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Status = Status;
            writer.Lat = Lat;
            writer.Lon = Lon;
            writer.Alt = Alt;
            writer.Speed = Speed;
            writer.VNED.Init(VNED);
            writer.Roll = Roll;
            writer.Pitch = Pitch;
            writer.Heading = Heading;
            writer.WanderAngle = WanderAngle;
            writer.TrackAngle = TrackAngle;
            writer.Gyro.Init(Gyro);
            writer.Accel.Init(Accel);
            TheAccuracy?.serialize(writer.TheAccuracy);
            writer.Source = Source;
            writer.FixMonoTime = FixMonoTime;
            writer.GpsWeek = GpsWeek;
            writer.TimeOfWeek = TimeOfWeek;
            writer.PositionECEF.Init(PositionECEF);
            writer.PoseQuatECEF.Init(PoseQuatECEF);
            writer.PitchCalibration = PitchCalibration;
            writer.YawCalibration = YawCalibration;
            writer.ImuFrame.Init(ImuFrame);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public byte Status
        {
            get;
            set;
        }

        public double Lat
        {
            get;
            set;
        }

        public double Lon
        {
            get;
            set;
        }

        public float Alt
        {
            get;
            set;
        }

        public float Speed
        {
            get;
            set;
        }

        public IReadOnlyList<float> VNED
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

        public float Heading
        {
            get;
            set;
        }

        public float WanderAngle
        {
            get;
            set;
        }

        public float TrackAngle
        {
            get;
            set;
        }

        public IReadOnlyList<float> Gyro
        {
            get;
            set;
        }

        public IReadOnlyList<float> Accel
        {
            get;
            set;
        }

        public Cereal.LiveLocationData.Accuracy TheAccuracy
        {
            get;
            set;
        }

        public Cereal.LiveLocationData.SensorSource Source
        {
            get;
            set;
        }

        public ulong FixMonoTime
        {
            get;
            set;
        }

        public int GpsWeek
        {
            get;
            set;
        }

        public double TimeOfWeek
        {
            get;
            set;
        }

        public IReadOnlyList<double> PositionECEF
        {
            get;
            set;
        }

        public IReadOnlyList<float> PoseQuatECEF
        {
            get;
            set;
        }

        public float PitchCalibration
        {
            get;
            set;
        }

        public float YawCalibration
        {
            get;
            set;
        }

        public IReadOnlyList<float> ImuFrame
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
            public byte Status => ctx.ReadDataByte(0UL, (byte)0);
            public double Lat => ctx.ReadDataDouble(64UL, 0);
            public double Lon => ctx.ReadDataDouble(128UL, 0);
            public float Alt => ctx.ReadDataFloat(32UL, 0F);
            public float Speed => ctx.ReadDataFloat(192UL, 0F);
            public IReadOnlyList<float> VNED => ctx.ReadList(0).CastFloat();
            public float Roll => ctx.ReadDataFloat(224UL, 0F);
            public float Pitch => ctx.ReadDataFloat(256UL, 0F);
            public float Heading => ctx.ReadDataFloat(288UL, 0F);
            public float WanderAngle => ctx.ReadDataFloat(320UL, 0F);
            public float TrackAngle => ctx.ReadDataFloat(352UL, 0F);
            public IReadOnlyList<float> Gyro => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<float> Accel => ctx.ReadList(2).CastFloat();
            public Cereal.LiveLocationData.Accuracy.READER TheAccuracy => ctx.ReadStruct(3, Cereal.LiveLocationData.Accuracy.READER.create);
            public Cereal.LiveLocationData.SensorSource Source => (Cereal.LiveLocationData.SensorSource)ctx.ReadDataUShort(16UL, (ushort)0);
            public ulong FixMonoTime => ctx.ReadDataULong(384UL, 0UL);
            public int GpsWeek => ctx.ReadDataInt(448UL, 0);
            public double TimeOfWeek => ctx.ReadDataDouble(512UL, 0);
            public IReadOnlyList<double> PositionECEF => ctx.ReadList(4).CastDouble();
            public IReadOnlyList<float> PoseQuatECEF => ctx.ReadList(5).CastFloat();
            public float PitchCalibration => ctx.ReadDataFloat(480UL, 0F);
            public float YawCalibration => ctx.ReadDataFloat(576UL, 0F);
            public IReadOnlyList<float> ImuFrame => ctx.ReadList(6).CastFloat();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(10, 7);
            }

            public byte Status
            {
                get => this.ReadDataByte(0UL, (byte)0);
                set => this.WriteData(0UL, value, (byte)0);
            }

            public double Lat
            {
                get => this.ReadDataDouble(64UL, 0);
                set => this.WriteData(64UL, value, 0);
            }

            public double Lon
            {
                get => this.ReadDataDouble(128UL, 0);
                set => this.WriteData(128UL, value, 0);
            }

            public float Alt
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float Speed
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> VNED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public float Roll
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public float Pitch
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }

            public float Heading
            {
                get => this.ReadDataFloat(288UL, 0F);
                set => this.WriteData(288UL, value, 0F);
            }

            public float WanderAngle
            {
                get => this.ReadDataFloat(320UL, 0F);
                set => this.WriteData(320UL, value, 0F);
            }

            public float TrackAngle
            {
                get => this.ReadDataFloat(352UL, 0F);
                set => this.WriteData(352UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> Gyro
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> Accel
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public Cereal.LiveLocationData.Accuracy.WRITER TheAccuracy
            {
                get => BuildPointer<Cereal.LiveLocationData.Accuracy.WRITER>(3);
                set => Link(3, value);
            }

            public Cereal.LiveLocationData.SensorSource Source
            {
                get => (Cereal.LiveLocationData.SensorSource)this.ReadDataUShort(16UL, (ushort)0);
                set => this.WriteData(16UL, (ushort)value, (ushort)0);
            }

            public ulong FixMonoTime
            {
                get => this.ReadDataULong(384UL, 0UL);
                set => this.WriteData(384UL, value, 0UL);
            }

            public int GpsWeek
            {
                get => this.ReadDataInt(448UL, 0);
                set => this.WriteData(448UL, value, 0);
            }

            public double TimeOfWeek
            {
                get => this.ReadDataDouble(512UL, 0);
                set => this.WriteData(512UL, value, 0);
            }

            public ListOfPrimitivesSerializer<double> PositionECEF
            {
                get => BuildPointer<ListOfPrimitivesSerializer<double>>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<float> PoseQuatECEF
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public float PitchCalibration
            {
                get => this.ReadDataFloat(480UL, 0F);
                set => this.WriteData(480UL, value, 0F);
            }

            public float YawCalibration
            {
                get => this.ReadDataFloat(576UL, 0F);
                set => this.WriteData(576UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> ImuFrame
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(6);
                set => Link(6, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x943dc4625473b03fUL)]
        public class Accuracy : ICapnpSerializable
        {
            public const UInt64 typeId = 0x943dc4625473b03fUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                PNEDError = reader.PNEDError;
                VNEDError = reader.VNEDError;
                RollError = reader.RollError;
                PitchError = reader.PitchError;
                HeadingError = reader.HeadingError;
                EllipsoidSemiMajorError = reader.EllipsoidSemiMajorError;
                EllipsoidSemiMinorError = reader.EllipsoidSemiMinorError;
                EllipsoidOrientationError = reader.EllipsoidOrientationError;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.PNEDError.Init(PNEDError);
                writer.VNEDError.Init(VNEDError);
                writer.RollError = RollError;
                writer.PitchError = PitchError;
                writer.HeadingError = HeadingError;
                writer.EllipsoidSemiMajorError = EllipsoidSemiMajorError;
                writer.EllipsoidSemiMinorError = EllipsoidSemiMinorError;
                writer.EllipsoidOrientationError = EllipsoidOrientationError;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> PNEDError
            {
                get;
                set;
            }

            public IReadOnlyList<float> VNEDError
            {
                get;
                set;
            }

            public float RollError
            {
                get;
                set;
            }

            public float PitchError
            {
                get;
                set;
            }

            public float HeadingError
            {
                get;
                set;
            }

            public float EllipsoidSemiMajorError
            {
                get;
                set;
            }

            public float EllipsoidSemiMinorError
            {
                get;
                set;
            }

            public float EllipsoidOrientationError
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
                public IReadOnlyList<float> PNEDError => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> VNEDError => ctx.ReadList(1).CastFloat();
                public float RollError => ctx.ReadDataFloat(0UL, 0F);
                public float PitchError => ctx.ReadDataFloat(32UL, 0F);
                public float HeadingError => ctx.ReadDataFloat(64UL, 0F);
                public float EllipsoidSemiMajorError => ctx.ReadDataFloat(96UL, 0F);
                public float EllipsoidSemiMinorError => ctx.ReadDataFloat(128UL, 0F);
                public float EllipsoidOrientationError => ctx.ReadDataFloat(160UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(3, 2);
                }

                public ListOfPrimitivesSerializer<float> PNEDError
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> VNEDError
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public float RollError
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float PitchError
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float HeadingError
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float EllipsoidSemiMajorError
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float EllipsoidSemiMinorError
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float EllipsoidOrientationError
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc871d3cc252af657UL)]
        public enum SensorSource : ushort
        {
            applanix,
            kalman,
            orbslam,
            timing,
            dummy
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd7700859ed1f5b76UL)]
    public class OrbOdometry : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd7700859ed1f5b76UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            StartMonoTime = reader.StartMonoTime;
            EndMonoTime = reader.EndMonoTime;
            F = reader.F;
            Err = reader.Err;
            Inliers = reader.Inliers;
            Matches = reader.Matches;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.StartMonoTime = StartMonoTime;
            writer.EndMonoTime = EndMonoTime;
            writer.F.Init(F);
            writer.Err = Err;
            writer.Inliers = Inliers;
            writer.Matches.Init(Matches);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong StartMonoTime
        {
            get;
            set;
        }

        public ulong EndMonoTime
        {
            get;
            set;
        }

        public IReadOnlyList<double> F
        {
            get;
            set;
        }

        public double Err
        {
            get;
            set;
        }

        public int Inliers
        {
            get;
            set;
        }

        public IReadOnlyList<short> Matches
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
            public ulong StartMonoTime => ctx.ReadDataULong(0UL, 0UL);
            public ulong EndMonoTime => ctx.ReadDataULong(64UL, 0UL);
            public IReadOnlyList<double> F => ctx.ReadList(0).CastDouble();
            public double Err => ctx.ReadDataDouble(128UL, 0);
            public int Inliers => ctx.ReadDataInt(192UL, 0);
            public IReadOnlyList<short> Matches => ctx.ReadList(1).CastShort();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(4, 2);
            }

            public ulong StartMonoTime
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public ulong EndMonoTime
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<double> F
            {
                get => BuildPointer<ListOfPrimitivesSerializer<double>>(0);
                set => Link(0, value);
            }

            public double Err
            {
                get => this.ReadDataDouble(128UL, 0);
                set => this.WriteData(128UL, value, 0);
            }

            public int Inliers
            {
                get => this.ReadDataInt(192UL, 0);
                set => this.WriteData(192UL, value, 0);
            }

            public ListOfPrimitivesSerializer<short> Matches
            {
                get => BuildPointer<ListOfPrimitivesSerializer<short>>(1);
                set => Link(1, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xcd60164a8a0159efUL)]
    public class OrbFeatures : ICapnpSerializable
    {
        public const UInt64 typeId = 0xcd60164a8a0159efUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            TimestampEof = reader.TimestampEof;
            Xs = reader.Xs;
            Ys = reader.Ys;
            Descriptors = reader.Descriptors;
            Octaves = reader.Octaves;
            TimestampLastEof = reader.TimestampLastEof;
            Matches = reader.Matches;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.TimestampEof = TimestampEof;
            writer.Xs.Init(Xs);
            writer.Ys.Init(Ys);
            writer.Descriptors.Init(Descriptors);
            writer.Octaves.Init(Octaves);
            writer.TimestampLastEof = TimestampLastEof;
            writer.Matches.Init(Matches);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong TimestampEof
        {
            get;
            set;
        }

        public IReadOnlyList<float> Xs
        {
            get;
            set;
        }

        public IReadOnlyList<float> Ys
        {
            get;
            set;
        }

        public IReadOnlyList<byte> Descriptors
        {
            get;
            set;
        }

        public IReadOnlyList<sbyte> Octaves
        {
            get;
            set;
        }

        public ulong TimestampLastEof
        {
            get;
            set;
        }

        public IReadOnlyList<short> Matches
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
            public ulong TimestampEof => ctx.ReadDataULong(0UL, 0UL);
            public IReadOnlyList<float> Xs => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<float> Ys => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<byte> Descriptors => ctx.ReadList(2).CastByte();
            public IReadOnlyList<sbyte> Octaves => ctx.ReadList(3).CastSByte();
            public ulong TimestampLastEof => ctx.ReadDataULong(64UL, 0UL);
            public IReadOnlyList<short> Matches => ctx.ReadList(4).CastShort();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 5);
            }

            public ulong TimestampEof
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<float> Xs
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<float> Ys
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<byte> Descriptors
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(2);
                set => Link(2, value);
            }

            public ListOfPrimitivesSerializer<sbyte> Octaves
            {
                get => BuildPointer<ListOfPrimitivesSerializer<sbyte>>(3);
                set => Link(3, value);
            }

            public ulong TimestampLastEof
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<short> Matches
            {
                get => BuildPointer<ListOfPrimitivesSerializer<short>>(4);
                set => Link(4, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd500d30c5803fa4fUL)]
    public class OrbFeaturesSummary : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd500d30c5803fa4fUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            TimestampEof = reader.TimestampEof;
            TimestampLastEof = reader.TimestampLastEof;
            FeatureCount = reader.FeatureCount;
            MatchCount = reader.MatchCount;
            ComputeNs = reader.ComputeNs;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.TimestampEof = TimestampEof;
            writer.TimestampLastEof = TimestampLastEof;
            writer.FeatureCount = FeatureCount;
            writer.MatchCount = MatchCount;
            writer.ComputeNs = ComputeNs;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong TimestampEof
        {
            get;
            set;
        }

        public ulong TimestampLastEof
        {
            get;
            set;
        }

        public ushort FeatureCount
        {
            get;
            set;
        }

        public ushort MatchCount
        {
            get;
            set;
        }

        public ulong ComputeNs
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
            public ulong TimestampEof => ctx.ReadDataULong(0UL, 0UL);
            public ulong TimestampLastEof => ctx.ReadDataULong(64UL, 0UL);
            public ushort FeatureCount => ctx.ReadDataUShort(128UL, (ushort)0);
            public ushort MatchCount => ctx.ReadDataUShort(144UL, (ushort)0);
            public ulong ComputeNs => ctx.ReadDataULong(192UL, 0UL);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(4, 0);
            }

            public ulong TimestampEof
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public ulong TimestampLastEof
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public ushort FeatureCount
            {
                get => this.ReadDataUShort(128UL, (ushort)0);
                set => this.WriteData(128UL, value, (ushort)0);
            }

            public ushort MatchCount
            {
                get => this.ReadDataUShort(144UL, (ushort)0);
                set => this.WriteData(144UL, value, (ushort)0);
            }

            public ulong ComputeNs
            {
                get => this.ReadDataULong(192UL, 0UL);
                set => this.WriteData(192UL, value, 0UL);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc8233c0345e27e24UL)]
    public class OrbKeyFrame : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc8233c0345e27e24UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Id = reader.Id;
            Pos = CapnpSerializable.Create<Cereal.ECEFPoint>(reader.Pos);
            Dpos = reader.Dpos?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ECEFPoint>(_));
            Descriptors = reader.Descriptors;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Id = Id;
            Pos?.serialize(writer.Pos);
            writer.Dpos.Init(Dpos, (_s1, _v1) => _v1?.serialize(_s1));
            writer.Descriptors.Init(Descriptors);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong Id
        {
            get;
            set;
        }

        public Cereal.ECEFPoint Pos
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ECEFPoint> Dpos
        {
            get;
            set;
        }

        public IReadOnlyList<byte> Descriptors
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
            public ulong Id => ctx.ReadDataULong(0UL, 0UL);
            public Cereal.ECEFPoint.READER Pos => ctx.ReadStruct(0, Cereal.ECEFPoint.READER.create);
            public IReadOnlyList<Cereal.ECEFPoint.READER> Dpos => ctx.ReadList(1).Cast(Cereal.ECEFPoint.READER.create);
            public IReadOnlyList<byte> Descriptors => ctx.ReadList(2).CastByte();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 3);
            }

            public ulong Id
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public Cereal.ECEFPoint.WRITER Pos
            {
                get => BuildPointer<Cereal.ECEFPoint.WRITER>(0);
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.ECEFPoint.WRITER> Dpos
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ECEFPoint.WRITER>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<byte> Descriptors
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(2);
                set => Link(2, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x92e21bb7ea38793aUL)]
    public class KalmanOdometry : ICapnpSerializable
    {
        public const UInt64 typeId = 0x92e21bb7ea38793aUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Trans = reader.Trans;
            Rot = reader.Rot;
            TransStd = reader.TransStd;
            RotStd = reader.RotStd;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Trans.Init(Trans);
            writer.Rot.Init(Rot);
            writer.TransStd.Init(TransStd);
            writer.RotStd.Init(RotStd);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<float> Trans
        {
            get;
            set;
        }

        public IReadOnlyList<float> Rot
        {
            get;
            set;
        }

        public IReadOnlyList<float> TransStd
        {
            get;
            set;
        }

        public IReadOnlyList<float> RotStd
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
            public IReadOnlyList<float> Trans => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<float> Rot => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<float> TransStd => ctx.ReadList(2).CastFloat();
            public IReadOnlyList<float> RotStd => ctx.ReadList(3).CastFloat();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 4);
            }

            public ListOfPrimitivesSerializer<float> Trans
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<float> Rot
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> TransStd
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public ListOfPrimitivesSerializer<float> RotStd
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9b326d4e436afec7UL)]
    public class OrbObservation : ICapnpSerializable
    {
        public const UInt64 typeId = 0x9b326d4e436afec7UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            ObservationMonoTime = reader.ObservationMonoTime;
            NormalizedCoordinates = reader.NormalizedCoordinates;
            LocationECEF = reader.LocationECEF;
            MatchDistance = reader.MatchDistance;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.ObservationMonoTime = ObservationMonoTime;
            writer.NormalizedCoordinates.Init(NormalizedCoordinates);
            writer.LocationECEF.Init(LocationECEF);
            writer.MatchDistance = MatchDistance;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong ObservationMonoTime
        {
            get;
            set;
        }

        public IReadOnlyList<float> NormalizedCoordinates
        {
            get;
            set;
        }

        public IReadOnlyList<double> LocationECEF
        {
            get;
            set;
        }

        public uint MatchDistance
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
            public ulong ObservationMonoTime => ctx.ReadDataULong(0UL, 0UL);
            public IReadOnlyList<float> NormalizedCoordinates => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<double> LocationECEF => ctx.ReadList(1).CastDouble();
            public uint MatchDistance => ctx.ReadDataUInt(64UL, 0U);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 2);
            }

            public ulong ObservationMonoTime
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<float> NormalizedCoordinates
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<double> LocationECEF
            {
                get => BuildPointer<ListOfPrimitivesSerializer<double>>(1);
                set => Link(1, value);
            }

            public uint MatchDistance
            {
                get => this.ReadDataUInt(64UL, 0U);
                set => this.WriteData(64UL, value, 0U);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8fdfadb254ea867aUL)]
    public class CalibrationFeatures : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8fdfadb254ea867aUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            FrameId = reader.FrameId;
            P0 = reader.P0;
            P1 = reader.P1;
            Status = reader.Status;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.FrameId = FrameId;
            writer.P0.Init(P0);
            writer.P1.Init(P1);
            writer.Status.Init(Status);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public uint FrameId
        {
            get;
            set;
        }

        public IReadOnlyList<float> P0
        {
            get;
            set;
        }

        public IReadOnlyList<float> P1
        {
            get;
            set;
        }

        public IReadOnlyList<sbyte> Status
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
            public uint FrameId => ctx.ReadDataUInt(0UL, 0U);
            public IReadOnlyList<float> P0 => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<float> P1 => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<sbyte> Status => ctx.ReadList(2).CastSByte();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 3);
            }

            public uint FrameId
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public ListOfPrimitivesSerializer<float> P0
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<float> P1
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<sbyte> Status
            {
                get => BuildPointer<ListOfPrimitivesSerializer<sbyte>>(2);
                set => Link(2, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbd8822120928120cUL)]
    public class NavStatus : ICapnpSerializable
    {
        public const UInt64 typeId = 0xbd8822120928120cUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            IsNavigating = reader.IsNavigating;
            CurrentAddress = CapnpSerializable.Create<Cereal.NavStatus.Address>(reader.CurrentAddress);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.IsNavigating = IsNavigating;
            CurrentAddress?.serialize(writer.CurrentAddress);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool IsNavigating
        {
            get;
            set;
        }

        public Cereal.NavStatus.Address CurrentAddress
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
            public bool IsNavigating => ctx.ReadDataBool(0UL, false);
            public Cereal.NavStatus.Address.READER CurrentAddress => ctx.ReadStruct(0, Cereal.NavStatus.Address.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public bool IsNavigating
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public Cereal.NavStatus.Address.WRITER CurrentAddress
            {
                get => BuildPointer<Cereal.NavStatus.Address.WRITER>(0);
                set => Link(0, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xce7cd672cacc7814UL)]
        public class Address : ICapnpSerializable
        {
            public const UInt64 typeId = 0xce7cd672cacc7814UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Title = reader.Title;
                Lat = reader.Lat;
                Lng = reader.Lng;
                House = reader.House;
                TheAddress = reader.TheAddress;
                Street = reader.Street;
                City = reader.City;
                State = reader.State;
                Country = reader.Country;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Title = Title;
                writer.Lat = Lat;
                writer.Lng = Lng;
                writer.House = House;
                writer.TheAddress = TheAddress;
                writer.Street = Street;
                writer.City = City;
                writer.State = State;
                writer.Country = Country;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public string Title
            {
                get;
                set;
            }

            public double Lat
            {
                get;
                set;
            }

            public double Lng
            {
                get;
                set;
            }

            public string House
            {
                get;
                set;
            }

            public string TheAddress
            {
                get;
                set;
            }

            public string Street
            {
                get;
                set;
            }

            public string City
            {
                get;
                set;
            }

            public string State
            {
                get;
                set;
            }

            public string Country
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
                public string Title => ctx.ReadText(0, null);
                public double Lat => ctx.ReadDataDouble(0UL, 0);
                public double Lng => ctx.ReadDataDouble(64UL, 0);
                public string House => ctx.ReadText(1, null);
                public string TheAddress => ctx.ReadText(2, null);
                public string Street => ctx.ReadText(3, null);
                public string City => ctx.ReadText(4, null);
                public string State => ctx.ReadText(5, null);
                public string Country => ctx.ReadText(6, null);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 7);
                }

                public string Title
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public double Lat
                {
                    get => this.ReadDataDouble(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public double Lng
                {
                    get => this.ReadDataDouble(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public string House
                {
                    get => this.ReadText(1, null);
                    set => this.WriteText(1, value, null);
                }

                public string TheAddress
                {
                    get => this.ReadText(2, null);
                    set => this.WriteText(2, value, null);
                }

                public string Street
                {
                    get => this.ReadText(3, null);
                    set => this.WriteText(3, value, null);
                }

                public string City
                {
                    get => this.ReadText(4, null);
                    set => this.WriteText(4, value, null);
                }

                public string State
                {
                    get => this.ReadText(5, null);
                    set => this.WriteText(5, value, null);
                }

                public string Country
                {
                    get => this.ReadText(6, null);
                    set => this.WriteText(6, value, null);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xdb98be6565516acbUL)]
    public class NavUpdate : ICapnpSerializable
    {
        public const UInt64 typeId = 0xdb98be6565516acbUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            IsNavigating = reader.IsNavigating;
            CurSegment = reader.CurSegment;
            Segments = reader.Segments?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.NavUpdate.Segment>(_));
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.IsNavigating = IsNavigating;
            writer.CurSegment = CurSegment;
            writer.Segments.Init(Segments, (_s1, _v1) => _v1?.serialize(_s1));
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool IsNavigating
        {
            get;
            set;
        }

        public int CurSegment
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.NavUpdate.Segment> Segments
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
            public bool IsNavigating => ctx.ReadDataBool(0UL, false);
            public int CurSegment => ctx.ReadDataInt(32UL, 0);
            public IReadOnlyList<Cereal.NavUpdate.Segment.READER> Segments => ctx.ReadList(0).Cast(Cereal.NavUpdate.Segment.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public bool IsNavigating
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public int CurSegment
            {
                get => this.ReadDataInt(32UL, 0);
                set => this.WriteData(32UL, value, 0);
            }

            public ListOfStructsSerializer<Cereal.NavUpdate.Segment.WRITER> Segments
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.NavUpdate.Segment.WRITER>>(0);
                set => Link(0, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9eaef9187cadbb9bUL)]
        public class LatLng : ICapnpSerializable
        {
            public const UInt64 typeId = 0x9eaef9187cadbb9bUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Lat = reader.Lat;
                Lng = reader.Lng;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Lat = Lat;
                writer.Lng = Lng;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public double Lat
            {
                get;
                set;
            }

            public double Lng
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
                public double Lat => ctx.ReadDataDouble(0UL, 0);
                public double Lng => ctx.ReadDataDouble(64UL, 0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public double Lat
                {
                    get => this.ReadDataDouble(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public double Lng
                {
                    get => this.ReadDataDouble(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa5b39b4fc4d7da3fUL)]
        public class Segment : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa5b39b4fc4d7da3fUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                From = CapnpSerializable.Create<Cereal.NavUpdate.LatLng>(reader.From);
                To = CapnpSerializable.Create<Cereal.NavUpdate.LatLng>(reader.To);
                UpdateTime = reader.UpdateTime;
                Distance = reader.Distance;
                CrossTime = reader.CrossTime;
                ExitNo = reader.ExitNo;
                TheInstruction = reader.TheInstruction;
                Parts = reader.Parts?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.NavUpdate.LatLng>(_));
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                From?.serialize(writer.From);
                To?.serialize(writer.To);
                writer.UpdateTime = UpdateTime;
                writer.Distance = Distance;
                writer.CrossTime = CrossTime;
                writer.ExitNo = ExitNo;
                writer.TheInstruction = TheInstruction;
                writer.Parts.Init(Parts, (_s1, _v1) => _v1?.serialize(_s1));
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public Cereal.NavUpdate.LatLng From
            {
                get;
                set;
            }

            public Cereal.NavUpdate.LatLng To
            {
                get;
                set;
            }

            public int UpdateTime
            {
                get;
                set;
            }

            public int Distance
            {
                get;
                set;
            }

            public int CrossTime
            {
                get;
                set;
            }

            public int ExitNo
            {
                get;
                set;
            }

            public Cereal.NavUpdate.Segment.Instruction TheInstruction
            {
                get;
                set;
            }

            public IReadOnlyList<Cereal.NavUpdate.LatLng> Parts
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
                public Cereal.NavUpdate.LatLng.READER From => ctx.ReadStruct(0, Cereal.NavUpdate.LatLng.READER.create);
                public Cereal.NavUpdate.LatLng.READER To => ctx.ReadStruct(1, Cereal.NavUpdate.LatLng.READER.create);
                public int UpdateTime => ctx.ReadDataInt(0UL, 0);
                public int Distance => ctx.ReadDataInt(32UL, 0);
                public int CrossTime => ctx.ReadDataInt(64UL, 0);
                public int ExitNo => ctx.ReadDataInt(96UL, 0);
                public Cereal.NavUpdate.Segment.Instruction TheInstruction => (Cereal.NavUpdate.Segment.Instruction)ctx.ReadDataUShort(128UL, (ushort)0);
                public IReadOnlyList<Cereal.NavUpdate.LatLng.READER> Parts => ctx.ReadList(2).Cast(Cereal.NavUpdate.LatLng.READER.create);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(3, 3);
                }

                public Cereal.NavUpdate.LatLng.WRITER From
                {
                    get => BuildPointer<Cereal.NavUpdate.LatLng.WRITER>(0);
                    set => Link(0, value);
                }

                public Cereal.NavUpdate.LatLng.WRITER To
                {
                    get => BuildPointer<Cereal.NavUpdate.LatLng.WRITER>(1);
                    set => Link(1, value);
                }

                public int UpdateTime
                {
                    get => this.ReadDataInt(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public int Distance
                {
                    get => this.ReadDataInt(32UL, 0);
                    set => this.WriteData(32UL, value, 0);
                }

                public int CrossTime
                {
                    get => this.ReadDataInt(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public int ExitNo
                {
                    get => this.ReadDataInt(96UL, 0);
                    set => this.WriteData(96UL, value, 0);
                }

                public Cereal.NavUpdate.Segment.Instruction TheInstruction
                {
                    get => (Cereal.NavUpdate.Segment.Instruction)this.ReadDataUShort(128UL, (ushort)0);
                    set => this.WriteData(128UL, (ushort)value, (ushort)0);
                }

                public ListOfStructsSerializer<Cereal.NavUpdate.LatLng.WRITER> Parts
                {
                    get => BuildPointer<ListOfStructsSerializer<Cereal.NavUpdate.LatLng.WRITER>>(2);
                    set => Link(2, value);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc5417a637451246fUL)]
            public enum Instruction : ushort
            {
                turnLeft,
                turnRight,
                keepLeft,
                keepRight,
                straight,
                roundaboutExitNumber,
                roundaboutExit,
                roundaboutTurnLeft,
                unkn8,
                roundaboutStraight,
                unkn10,
                roundaboutTurnRight,
                unkn12,
                roundaboutUturn,
                unkn14,
                arrive,
                exitLeft,
                exitRight,
                unkn18,
                uturn
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xacfa74a094e62626UL)]
    public class TrafficEvent : ICapnpSerializable
    {
        public const UInt64 typeId = 0xacfa74a094e62626UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            TheType = reader.TheType;
            Distance = reader.Distance;
            TheAction = reader.TheAction;
            Resuming = reader.Resuming;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.TheType = TheType;
            writer.Distance = Distance;
            writer.TheAction = TheAction;
            writer.Resuming = Resuming;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public Cereal.TrafficEvent.Type TheType
        {
            get;
            set;
        }

        public float Distance
        {
            get;
            set;
        }

        public Cereal.TrafficEvent.Action TheAction
        {
            get;
            set;
        }

        public bool Resuming
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
            public Cereal.TrafficEvent.Type TheType => (Cereal.TrafficEvent.Type)ctx.ReadDataUShort(0UL, (ushort)0);
            public float Distance => ctx.ReadDataFloat(32UL, 0F);
            public Cereal.TrafficEvent.Action TheAction => (Cereal.TrafficEvent.Action)ctx.ReadDataUShort(16UL, (ushort)0);
            public bool Resuming => ctx.ReadDataBool(64UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 0);
            }

            public Cereal.TrafficEvent.Type TheType
            {
                get => (Cereal.TrafficEvent.Type)this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, (ushort)value, (ushort)0);
            }

            public float Distance
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public Cereal.TrafficEvent.Action TheAction
            {
                get => (Cereal.TrafficEvent.Action)this.ReadDataUShort(16UL, (ushort)0);
                set => this.WriteData(16UL, (ushort)value, (ushort)0);
            }

            public bool Resuming
            {
                get => this.ReadDataBool(64UL, false);
                set => this.WriteData(64UL, value, false);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd85d75253435bf4bUL)]
        public enum Type : ushort
        {
            stopSign,
            lightRed,
            lightYellow,
            lightGreen,
            stopLight
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa6f6ce72165ccb49UL)]
        public enum Action : ushort
        {
            none,
            @yield,
            stop,
            resumeReady
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xdfdf30d03fc485bdUL)]
    public class AndroidGnss : ICapnpSerializable
    {
        public const UInt64 typeId = 0xdfdf30d03fc485bdUL;
        public enum WHICH : ushort
        {
            TheMeasurements = 0,
            TheNavigationMessage = 1,
            undefined = 65535
        }

        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            switch (reader.which)
            {
                case WHICH.TheMeasurements:
                    TheMeasurements = CapnpSerializable.Create<Cereal.AndroidGnss.Measurements>(reader.TheMeasurements);
                    break;
                case WHICH.TheNavigationMessage:
                    TheNavigationMessage = CapnpSerializable.Create<Cereal.AndroidGnss.NavigationMessage>(reader.TheNavigationMessage);
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
                    case WHICH.TheMeasurements:
                        _content = null;
                        break;
                    case WHICH.TheNavigationMessage:
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
                case WHICH.TheMeasurements:
                    TheMeasurements?.serialize(writer.TheMeasurements);
                    break;
                case WHICH.TheNavigationMessage:
                    TheNavigationMessage?.serialize(writer.TheNavigationMessage);
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

        public Cereal.AndroidGnss.Measurements TheMeasurements
        {
            get => _which == WHICH.TheMeasurements ? (Cereal.AndroidGnss.Measurements)_content : null;
            set
            {
                _which = WHICH.TheMeasurements;
                _content = value;
            }
        }

        public Cereal.AndroidGnss.NavigationMessage TheNavigationMessage
        {
            get => _which == WHICH.TheNavigationMessage ? (Cereal.AndroidGnss.NavigationMessage)_content : null;
            set
            {
                _which = WHICH.TheNavigationMessage;
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
            public WHICH which => (WHICH)ctx.ReadDataUShort(0U, (ushort)0);
            public Cereal.AndroidGnss.Measurements.READER TheMeasurements => which == WHICH.TheMeasurements ? ctx.ReadStruct(0, Cereal.AndroidGnss.Measurements.READER.create) : default;
            public Cereal.AndroidGnss.NavigationMessage.READER TheNavigationMessage => which == WHICH.TheNavigationMessage ? ctx.ReadStruct(0, Cereal.AndroidGnss.NavigationMessage.READER.create) : default;
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public WHICH which
            {
                get => (WHICH)this.ReadDataUShort(0U, (ushort)0);
                set => this.WriteData(0U, (ushort)value, (ushort)0);
            }

            public Cereal.AndroidGnss.Measurements.WRITER TheMeasurements
            {
                get => which == WHICH.TheMeasurements ? BuildPointer<Cereal.AndroidGnss.Measurements.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.AndroidGnss.NavigationMessage.WRITER TheNavigationMessage
            {
                get => which == WHICH.TheNavigationMessage ? BuildPointer<Cereal.AndroidGnss.NavigationMessage.WRITER>(0) : default;
                set => Link(0, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa20710d4f428d6cdUL)]
        public class Measurements : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa20710d4f428d6cdUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                TheClock = CapnpSerializable.Create<Cereal.AndroidGnss.Measurements.Clock>(reader.TheClock);
                TheMeasurements = reader.TheMeasurements?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.AndroidGnss.Measurements.Measurement>(_));
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                TheClock?.serialize(writer.TheClock);
                writer.TheMeasurements.Init(TheMeasurements, (_s1, _v1) => _v1?.serialize(_s1));
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public Cereal.AndroidGnss.Measurements.Clock TheClock
            {
                get;
                set;
            }

            public IReadOnlyList<Cereal.AndroidGnss.Measurements.Measurement> TheMeasurements
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
                public Cereal.AndroidGnss.Measurements.Clock.READER TheClock => ctx.ReadStruct(0, Cereal.AndroidGnss.Measurements.Clock.READER.create);
                public IReadOnlyList<Cereal.AndroidGnss.Measurements.Measurement.READER> TheMeasurements => ctx.ReadList(1).Cast(Cereal.AndroidGnss.Measurements.Measurement.READER.create);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 2);
                }

                public Cereal.AndroidGnss.Measurements.Clock.WRITER TheClock
                {
                    get => BuildPointer<Cereal.AndroidGnss.Measurements.Clock.WRITER>(0);
                    set => Link(0, value);
                }

                public ListOfStructsSerializer<Cereal.AndroidGnss.Measurements.Measurement.WRITER> TheMeasurements
                {
                    get => BuildPointer<ListOfStructsSerializer<Cereal.AndroidGnss.Measurements.Measurement.WRITER>>(1);
                    set => Link(1, value);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa0e27b453a38f450UL)]
            public class Clock : ICapnpSerializable
            {
                public const UInt64 typeId = 0xa0e27b453a38f450UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    TimeNanos = reader.TimeNanos;
                    HardwareClockDiscontinuityCount = reader.HardwareClockDiscontinuityCount;
                    HasTimeUncertaintyNanos = reader.HasTimeUncertaintyNanos;
                    TimeUncertaintyNanos = reader.TimeUncertaintyNanos;
                    HasLeapSecond = reader.HasLeapSecond;
                    LeapSecond = reader.LeapSecond;
                    HasFullBiasNanos = reader.HasFullBiasNanos;
                    FullBiasNanos = reader.FullBiasNanos;
                    HasBiasNanos = reader.HasBiasNanos;
                    BiasNanos = reader.BiasNanos;
                    HasBiasUncertaintyNanos = reader.HasBiasUncertaintyNanos;
                    BiasUncertaintyNanos = reader.BiasUncertaintyNanos;
                    HasDriftNanosPerSecond = reader.HasDriftNanosPerSecond;
                    DriftNanosPerSecond = reader.DriftNanosPerSecond;
                    HasDriftUncertaintyNanosPerSecond = reader.HasDriftUncertaintyNanosPerSecond;
                    DriftUncertaintyNanosPerSecond = reader.DriftUncertaintyNanosPerSecond;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.TimeNanos = TimeNanos;
                    writer.HardwareClockDiscontinuityCount = HardwareClockDiscontinuityCount;
                    writer.HasTimeUncertaintyNanos = HasTimeUncertaintyNanos;
                    writer.TimeUncertaintyNanos = TimeUncertaintyNanos;
                    writer.HasLeapSecond = HasLeapSecond;
                    writer.LeapSecond = LeapSecond;
                    writer.HasFullBiasNanos = HasFullBiasNanos;
                    writer.FullBiasNanos = FullBiasNanos;
                    writer.HasBiasNanos = HasBiasNanos;
                    writer.BiasNanos = BiasNanos;
                    writer.HasBiasUncertaintyNanos = HasBiasUncertaintyNanos;
                    writer.BiasUncertaintyNanos = BiasUncertaintyNanos;
                    writer.HasDriftNanosPerSecond = HasDriftNanosPerSecond;
                    writer.DriftNanosPerSecond = DriftNanosPerSecond;
                    writer.HasDriftUncertaintyNanosPerSecond = HasDriftUncertaintyNanosPerSecond;
                    writer.DriftUncertaintyNanosPerSecond = DriftUncertaintyNanosPerSecond;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public long TimeNanos
                {
                    get;
                    set;
                }

                public int HardwareClockDiscontinuityCount
                {
                    get;
                    set;
                }

                public bool HasTimeUncertaintyNanos
                {
                    get;
                    set;
                }

                public double TimeUncertaintyNanos
                {
                    get;
                    set;
                }

                public bool HasLeapSecond
                {
                    get;
                    set;
                }

                public int LeapSecond
                {
                    get;
                    set;
                }

                public bool HasFullBiasNanos
                {
                    get;
                    set;
                }

                public long FullBiasNanos
                {
                    get;
                    set;
                }

                public bool HasBiasNanos
                {
                    get;
                    set;
                }

                public double BiasNanos
                {
                    get;
                    set;
                }

                public bool HasBiasUncertaintyNanos
                {
                    get;
                    set;
                }

                public double BiasUncertaintyNanos
                {
                    get;
                    set;
                }

                public bool HasDriftNanosPerSecond
                {
                    get;
                    set;
                }

                public double DriftNanosPerSecond
                {
                    get;
                    set;
                }

                public bool HasDriftUncertaintyNanosPerSecond
                {
                    get;
                    set;
                }

                public double DriftUncertaintyNanosPerSecond
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
                    public long TimeNanos => ctx.ReadDataLong(0UL, 0L);
                    public int HardwareClockDiscontinuityCount => ctx.ReadDataInt(64UL, 0);
                    public bool HasTimeUncertaintyNanos => ctx.ReadDataBool(96UL, false);
                    public double TimeUncertaintyNanos => ctx.ReadDataDouble(128UL, 0);
                    public bool HasLeapSecond => ctx.ReadDataBool(97UL, false);
                    public int LeapSecond => ctx.ReadDataInt(192UL, 0);
                    public bool HasFullBiasNanos => ctx.ReadDataBool(98UL, false);
                    public long FullBiasNanos => ctx.ReadDataLong(256UL, 0L);
                    public bool HasBiasNanos => ctx.ReadDataBool(99UL, false);
                    public double BiasNanos => ctx.ReadDataDouble(320UL, 0);
                    public bool HasBiasUncertaintyNanos => ctx.ReadDataBool(100UL, false);
                    public double BiasUncertaintyNanos => ctx.ReadDataDouble(384UL, 0);
                    public bool HasDriftNanosPerSecond => ctx.ReadDataBool(101UL, false);
                    public double DriftNanosPerSecond => ctx.ReadDataDouble(448UL, 0);
                    public bool HasDriftUncertaintyNanosPerSecond => ctx.ReadDataBool(102UL, false);
                    public double DriftUncertaintyNanosPerSecond => ctx.ReadDataDouble(512UL, 0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(9, 0);
                    }

                    public long TimeNanos
                    {
                        get => this.ReadDataLong(0UL, 0L);
                        set => this.WriteData(0UL, value, 0L);
                    }

                    public int HardwareClockDiscontinuityCount
                    {
                        get => this.ReadDataInt(64UL, 0);
                        set => this.WriteData(64UL, value, 0);
                    }

                    public bool HasTimeUncertaintyNanos
                    {
                        get => this.ReadDataBool(96UL, false);
                        set => this.WriteData(96UL, value, false);
                    }

                    public double TimeUncertaintyNanos
                    {
                        get => this.ReadDataDouble(128UL, 0);
                        set => this.WriteData(128UL, value, 0);
                    }

                    public bool HasLeapSecond
                    {
                        get => this.ReadDataBool(97UL, false);
                        set => this.WriteData(97UL, value, false);
                    }

                    public int LeapSecond
                    {
                        get => this.ReadDataInt(192UL, 0);
                        set => this.WriteData(192UL, value, 0);
                    }

                    public bool HasFullBiasNanos
                    {
                        get => this.ReadDataBool(98UL, false);
                        set => this.WriteData(98UL, value, false);
                    }

                    public long FullBiasNanos
                    {
                        get => this.ReadDataLong(256UL, 0L);
                        set => this.WriteData(256UL, value, 0L);
                    }

                    public bool HasBiasNanos
                    {
                        get => this.ReadDataBool(99UL, false);
                        set => this.WriteData(99UL, value, false);
                    }

                    public double BiasNanos
                    {
                        get => this.ReadDataDouble(320UL, 0);
                        set => this.WriteData(320UL, value, 0);
                    }

                    public bool HasBiasUncertaintyNanos
                    {
                        get => this.ReadDataBool(100UL, false);
                        set => this.WriteData(100UL, value, false);
                    }

                    public double BiasUncertaintyNanos
                    {
                        get => this.ReadDataDouble(384UL, 0);
                        set => this.WriteData(384UL, value, 0);
                    }

                    public bool HasDriftNanosPerSecond
                    {
                        get => this.ReadDataBool(101UL, false);
                        set => this.WriteData(101UL, value, false);
                    }

                    public double DriftNanosPerSecond
                    {
                        get => this.ReadDataDouble(448UL, 0);
                        set => this.WriteData(448UL, value, 0);
                    }

                    public bool HasDriftUncertaintyNanosPerSecond
                    {
                        get => this.ReadDataBool(102UL, false);
                        set => this.WriteData(102UL, value, false);
                    }

                    public double DriftUncertaintyNanosPerSecond
                    {
                        get => this.ReadDataDouble(512UL, 0);
                        set => this.WriteData(512UL, value, 0);
                    }
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd949bf717d77614dUL)]
            public class Measurement : ICapnpSerializable
            {
                public const UInt64 typeId = 0xd949bf717d77614dUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    SvId = reader.SvId;
                    TheConstellation = reader.TheConstellation;
                    TimeOffsetNanos = reader.TimeOffsetNanos;
                    TheState = reader.TheState;
                    ReceivedSvTimeNanos = reader.ReceivedSvTimeNanos;
                    ReceivedSvTimeUncertaintyNanos = reader.ReceivedSvTimeUncertaintyNanos;
                    Cn0DbHz = reader.Cn0DbHz;
                    PseudorangeRateMetersPerSecond = reader.PseudorangeRateMetersPerSecond;
                    PseudorangeRateUncertaintyMetersPerSecond = reader.PseudorangeRateUncertaintyMetersPerSecond;
                    AccumulatedDeltaRangeState = reader.AccumulatedDeltaRangeState;
                    AccumulatedDeltaRangeMeters = reader.AccumulatedDeltaRangeMeters;
                    AccumulatedDeltaRangeUncertaintyMeters = reader.AccumulatedDeltaRangeUncertaintyMeters;
                    HasCarrierFrequencyHz = reader.HasCarrierFrequencyHz;
                    CarrierFrequencyHz = reader.CarrierFrequencyHz;
                    HasCarrierCycles = reader.HasCarrierCycles;
                    CarrierCycles = reader.CarrierCycles;
                    HasCarrierPhase = reader.HasCarrierPhase;
                    CarrierPhase = reader.CarrierPhase;
                    HasCarrierPhaseUncertainty = reader.HasCarrierPhaseUncertainty;
                    CarrierPhaseUncertainty = reader.CarrierPhaseUncertainty;
                    HasSnrInDb = reader.HasSnrInDb;
                    SnrInDb = reader.SnrInDb;
                    TheMultipathIndicator = reader.TheMultipathIndicator;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.SvId = SvId;
                    writer.TheConstellation = TheConstellation;
                    writer.TimeOffsetNanos = TimeOffsetNanos;
                    writer.TheState = TheState;
                    writer.ReceivedSvTimeNanos = ReceivedSvTimeNanos;
                    writer.ReceivedSvTimeUncertaintyNanos = ReceivedSvTimeUncertaintyNanos;
                    writer.Cn0DbHz = Cn0DbHz;
                    writer.PseudorangeRateMetersPerSecond = PseudorangeRateMetersPerSecond;
                    writer.PseudorangeRateUncertaintyMetersPerSecond = PseudorangeRateUncertaintyMetersPerSecond;
                    writer.AccumulatedDeltaRangeState = AccumulatedDeltaRangeState;
                    writer.AccumulatedDeltaRangeMeters = AccumulatedDeltaRangeMeters;
                    writer.AccumulatedDeltaRangeUncertaintyMeters = AccumulatedDeltaRangeUncertaintyMeters;
                    writer.HasCarrierFrequencyHz = HasCarrierFrequencyHz;
                    writer.CarrierFrequencyHz = CarrierFrequencyHz;
                    writer.HasCarrierCycles = HasCarrierCycles;
                    writer.CarrierCycles = CarrierCycles;
                    writer.HasCarrierPhase = HasCarrierPhase;
                    writer.CarrierPhase = CarrierPhase;
                    writer.HasCarrierPhaseUncertainty = HasCarrierPhaseUncertainty;
                    writer.CarrierPhaseUncertainty = CarrierPhaseUncertainty;
                    writer.HasSnrInDb = HasSnrInDb;
                    writer.SnrInDb = SnrInDb;
                    writer.TheMultipathIndicator = TheMultipathIndicator;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public int SvId
                {
                    get;
                    set;
                }

                public Cereal.AndroidGnss.Measurements.Measurement.Constellation TheConstellation
                {
                    get;
                    set;
                }

                public double TimeOffsetNanos
                {
                    get;
                    set;
                }

                public int TheState
                {
                    get;
                    set;
                }

                public long ReceivedSvTimeNanos
                {
                    get;
                    set;
                }

                public long ReceivedSvTimeUncertaintyNanos
                {
                    get;
                    set;
                }

                public double Cn0DbHz
                {
                    get;
                    set;
                }

                public double PseudorangeRateMetersPerSecond
                {
                    get;
                    set;
                }

                public double PseudorangeRateUncertaintyMetersPerSecond
                {
                    get;
                    set;
                }

                public int AccumulatedDeltaRangeState
                {
                    get;
                    set;
                }

                public double AccumulatedDeltaRangeMeters
                {
                    get;
                    set;
                }

                public double AccumulatedDeltaRangeUncertaintyMeters
                {
                    get;
                    set;
                }

                public bool HasCarrierFrequencyHz
                {
                    get;
                    set;
                }

                public float CarrierFrequencyHz
                {
                    get;
                    set;
                }

                public bool HasCarrierCycles
                {
                    get;
                    set;
                }

                public long CarrierCycles
                {
                    get;
                    set;
                }

                public bool HasCarrierPhase
                {
                    get;
                    set;
                }

                public double CarrierPhase
                {
                    get;
                    set;
                }

                public bool HasCarrierPhaseUncertainty
                {
                    get;
                    set;
                }

                public double CarrierPhaseUncertainty
                {
                    get;
                    set;
                }

                public bool HasSnrInDb
                {
                    get;
                    set;
                }

                public double SnrInDb
                {
                    get;
                    set;
                }

                public Cereal.AndroidGnss.Measurements.Measurement.MultipathIndicator TheMultipathIndicator
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
                    public int SvId => ctx.ReadDataInt(0UL, 0);
                    public Cereal.AndroidGnss.Measurements.Measurement.Constellation TheConstellation => (Cereal.AndroidGnss.Measurements.Measurement.Constellation)ctx.ReadDataUShort(32UL, (ushort)0);
                    public double TimeOffsetNanos => ctx.ReadDataDouble(64UL, 0);
                    public int TheState => ctx.ReadDataInt(128UL, 0);
                    public long ReceivedSvTimeNanos => ctx.ReadDataLong(192UL, 0L);
                    public long ReceivedSvTimeUncertaintyNanos => ctx.ReadDataLong(256UL, 0L);
                    public double Cn0DbHz => ctx.ReadDataDouble(320UL, 0);
                    public double PseudorangeRateMetersPerSecond => ctx.ReadDataDouble(384UL, 0);
                    public double PseudorangeRateUncertaintyMetersPerSecond => ctx.ReadDataDouble(448UL, 0);
                    public int AccumulatedDeltaRangeState => ctx.ReadDataInt(160UL, 0);
                    public double AccumulatedDeltaRangeMeters => ctx.ReadDataDouble(512UL, 0);
                    public double AccumulatedDeltaRangeUncertaintyMeters => ctx.ReadDataDouble(576UL, 0);
                    public bool HasCarrierFrequencyHz => ctx.ReadDataBool(48UL, false);
                    public float CarrierFrequencyHz => ctx.ReadDataFloat(640UL, 0F);
                    public bool HasCarrierCycles => ctx.ReadDataBool(49UL, false);
                    public long CarrierCycles => ctx.ReadDataLong(704UL, 0L);
                    public bool HasCarrierPhase => ctx.ReadDataBool(50UL, false);
                    public double CarrierPhase => ctx.ReadDataDouble(768UL, 0);
                    public bool HasCarrierPhaseUncertainty => ctx.ReadDataBool(51UL, false);
                    public double CarrierPhaseUncertainty => ctx.ReadDataDouble(832UL, 0);
                    public bool HasSnrInDb => ctx.ReadDataBool(52UL, false);
                    public double SnrInDb => ctx.ReadDataDouble(896UL, 0);
                    public Cereal.AndroidGnss.Measurements.Measurement.MultipathIndicator TheMultipathIndicator => (Cereal.AndroidGnss.Measurements.Measurement.MultipathIndicator)ctx.ReadDataUShort(672UL, (ushort)0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(15, 0);
                    }

                    public int SvId
                    {
                        get => this.ReadDataInt(0UL, 0);
                        set => this.WriteData(0UL, value, 0);
                    }

                    public Cereal.AndroidGnss.Measurements.Measurement.Constellation TheConstellation
                    {
                        get => (Cereal.AndroidGnss.Measurements.Measurement.Constellation)this.ReadDataUShort(32UL, (ushort)0);
                        set => this.WriteData(32UL, (ushort)value, (ushort)0);
                    }

                    public double TimeOffsetNanos
                    {
                        get => this.ReadDataDouble(64UL, 0);
                        set => this.WriteData(64UL, value, 0);
                    }

                    public int TheState
                    {
                        get => this.ReadDataInt(128UL, 0);
                        set => this.WriteData(128UL, value, 0);
                    }

                    public long ReceivedSvTimeNanos
                    {
                        get => this.ReadDataLong(192UL, 0L);
                        set => this.WriteData(192UL, value, 0L);
                    }

                    public long ReceivedSvTimeUncertaintyNanos
                    {
                        get => this.ReadDataLong(256UL, 0L);
                        set => this.WriteData(256UL, value, 0L);
                    }

                    public double Cn0DbHz
                    {
                        get => this.ReadDataDouble(320UL, 0);
                        set => this.WriteData(320UL, value, 0);
                    }

                    public double PseudorangeRateMetersPerSecond
                    {
                        get => this.ReadDataDouble(384UL, 0);
                        set => this.WriteData(384UL, value, 0);
                    }

                    public double PseudorangeRateUncertaintyMetersPerSecond
                    {
                        get => this.ReadDataDouble(448UL, 0);
                        set => this.WriteData(448UL, value, 0);
                    }

                    public int AccumulatedDeltaRangeState
                    {
                        get => this.ReadDataInt(160UL, 0);
                        set => this.WriteData(160UL, value, 0);
                    }

                    public double AccumulatedDeltaRangeMeters
                    {
                        get => this.ReadDataDouble(512UL, 0);
                        set => this.WriteData(512UL, value, 0);
                    }

                    public double AccumulatedDeltaRangeUncertaintyMeters
                    {
                        get => this.ReadDataDouble(576UL, 0);
                        set => this.WriteData(576UL, value, 0);
                    }

                    public bool HasCarrierFrequencyHz
                    {
                        get => this.ReadDataBool(48UL, false);
                        set => this.WriteData(48UL, value, false);
                    }

                    public float CarrierFrequencyHz
                    {
                        get => this.ReadDataFloat(640UL, 0F);
                        set => this.WriteData(640UL, value, 0F);
                    }

                    public bool HasCarrierCycles
                    {
                        get => this.ReadDataBool(49UL, false);
                        set => this.WriteData(49UL, value, false);
                    }

                    public long CarrierCycles
                    {
                        get => this.ReadDataLong(704UL, 0L);
                        set => this.WriteData(704UL, value, 0L);
                    }

                    public bool HasCarrierPhase
                    {
                        get => this.ReadDataBool(50UL, false);
                        set => this.WriteData(50UL, value, false);
                    }

                    public double CarrierPhase
                    {
                        get => this.ReadDataDouble(768UL, 0);
                        set => this.WriteData(768UL, value, 0);
                    }

                    public bool HasCarrierPhaseUncertainty
                    {
                        get => this.ReadDataBool(51UL, false);
                        set => this.WriteData(51UL, value, false);
                    }

                    public double CarrierPhaseUncertainty
                    {
                        get => this.ReadDataDouble(832UL, 0);
                        set => this.WriteData(832UL, value, 0);
                    }

                    public bool HasSnrInDb
                    {
                        get => this.ReadDataBool(52UL, false);
                        set => this.WriteData(52UL, value, false);
                    }

                    public double SnrInDb
                    {
                        get => this.ReadDataDouble(896UL, 0);
                        set => this.WriteData(896UL, value, 0);
                    }

                    public Cereal.AndroidGnss.Measurements.Measurement.MultipathIndicator TheMultipathIndicator
                    {
                        get => (Cereal.AndroidGnss.Measurements.Measurement.MultipathIndicator)this.ReadDataUShort(672UL, (ushort)0);
                        set => this.WriteData(672UL, (ushort)value, (ushort)0);
                    }
                }

                [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9ef1f3ff0deb5ffbUL)]
                public enum Constellation : ushort
                {
                    unknown,
                    gps,
                    sbas,
                    glonass,
                    qzss,
                    beidou,
                    galileo
                }

                [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xcbb9490adce12d72UL)]
                public enum State : ushort
                {
                    unknown,
                    codeLock,
                    bitSync,
                    subframeSync,
                    towDecoded,
                    msecAmbiguous,
                    symbolSync,
                    gloStringSync,
                    gloTodDecoded,
                    bdsD2BitSync,
                    bdsD2SubframeSync,
                    galE1bcCodeLock,
                    galE1c2ndCodeLock,
                    galE1bPageSync,
                    sbasSync
                }

                [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc04e7b6231d4caa8UL)]
                public enum MultipathIndicator : ushort
                {
                    unknown,
                    detected,
                    notDetected
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe2517b083095fd4eUL)]
        public class NavigationMessage : ICapnpSerializable
        {
            public const UInt64 typeId = 0xe2517b083095fd4eUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Type = reader.Type;
                SvId = reader.SvId;
                MessageId = reader.MessageId;
                SubmessageId = reader.SubmessageId;
                Data = reader.Data;
                TheStatus = reader.TheStatus;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Type = Type;
                writer.SvId = SvId;
                writer.MessageId = MessageId;
                writer.SubmessageId = SubmessageId;
                writer.Data.Init(Data);
                writer.TheStatus = TheStatus;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public int Type
            {
                get;
                set;
            }

            public int SvId
            {
                get;
                set;
            }

            public int MessageId
            {
                get;
                set;
            }

            public int SubmessageId
            {
                get;
                set;
            }

            public IReadOnlyList<byte> Data
            {
                get;
                set;
            }

            public Cereal.AndroidGnss.NavigationMessage.Status TheStatus
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
                public int Type => ctx.ReadDataInt(0UL, 0);
                public int SvId => ctx.ReadDataInt(32UL, 0);
                public int MessageId => ctx.ReadDataInt(64UL, 0);
                public int SubmessageId => ctx.ReadDataInt(96UL, 0);
                public IReadOnlyList<byte> Data => ctx.ReadList(0).CastByte();
                public Cereal.AndroidGnss.NavigationMessage.Status TheStatus => (Cereal.AndroidGnss.NavigationMessage.Status)ctx.ReadDataUShort(128UL, (ushort)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(3, 1);
                }

                public int Type
                {
                    get => this.ReadDataInt(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public int SvId
                {
                    get => this.ReadDataInt(32UL, 0);
                    set => this.WriteData(32UL, value, 0);
                }

                public int MessageId
                {
                    get => this.ReadDataInt(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public int SubmessageId
                {
                    get => this.ReadDataInt(96UL, 0);
                    set => this.WriteData(96UL, value, 0);
                }

                public ListOfPrimitivesSerializer<byte> Data
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<byte>>(0);
                    set => Link(0, value);
                }

                public Cereal.AndroidGnss.NavigationMessage.Status TheStatus
                {
                    get => (Cereal.AndroidGnss.NavigationMessage.Status)this.ReadDataUShort(128UL, (ushort)0);
                    set => this.WriteData(128UL, (ushort)value, (ushort)0);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xec1ff7996b35366fUL)]
            public enum Status : ushort
            {
                unknown,
                parityPassed,
                parityRebuilt
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xde94674b07ae51c1UL)]
    public class QcomGnss : ICapnpSerializable
    {
        public const UInt64 typeId = 0xde94674b07ae51c1UL;
        public enum WHICH : ushort
        {
            TheMeasurementReport = 0,
            TheClockReport = 1,
            TheDrMeasurementReport = 2,
            DrSvPoly = 3,
            RawLog = 4,
            undefined = 65535
        }

        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            switch (reader.which)
            {
                case WHICH.TheMeasurementReport:
                    TheMeasurementReport = CapnpSerializable.Create<Cereal.QcomGnss.MeasurementReport>(reader.TheMeasurementReport);
                    break;
                case WHICH.TheClockReport:
                    TheClockReport = CapnpSerializable.Create<Cereal.QcomGnss.ClockReport>(reader.TheClockReport);
                    break;
                case WHICH.TheDrMeasurementReport:
                    TheDrMeasurementReport = CapnpSerializable.Create<Cereal.QcomGnss.DrMeasurementReport>(reader.TheDrMeasurementReport);
                    break;
                case WHICH.DrSvPoly:
                    DrSvPoly = CapnpSerializable.Create<Cereal.QcomGnss.DrSvPolyReport>(reader.DrSvPoly);
                    break;
                case WHICH.RawLog:
                    RawLog = reader.RawLog;
                    break;
            }

            LogTs = reader.LogTs;
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
                    case WHICH.TheMeasurementReport:
                        _content = null;
                        break;
                    case WHICH.TheClockReport:
                        _content = null;
                        break;
                    case WHICH.TheDrMeasurementReport:
                        _content = null;
                        break;
                    case WHICH.DrSvPoly:
                        _content = null;
                        break;
                    case WHICH.RawLog:
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
                case WHICH.TheMeasurementReport:
                    TheMeasurementReport?.serialize(writer.TheMeasurementReport);
                    break;
                case WHICH.TheClockReport:
                    TheClockReport?.serialize(writer.TheClockReport);
                    break;
                case WHICH.TheDrMeasurementReport:
                    TheDrMeasurementReport?.serialize(writer.TheDrMeasurementReport);
                    break;
                case WHICH.DrSvPoly:
                    DrSvPoly?.serialize(writer.DrSvPoly);
                    break;
                case WHICH.RawLog:
                    writer.RawLog.Init(RawLog);
                    break;
            }

            writer.LogTs = LogTs;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong LogTs
        {
            get;
            set;
        }

        public Cereal.QcomGnss.MeasurementReport TheMeasurementReport
        {
            get => _which == WHICH.TheMeasurementReport ? (Cereal.QcomGnss.MeasurementReport)_content : null;
            set
            {
                _which = WHICH.TheMeasurementReport;
                _content = value;
            }
        }

        public Cereal.QcomGnss.ClockReport TheClockReport
        {
            get => _which == WHICH.TheClockReport ? (Cereal.QcomGnss.ClockReport)_content : null;
            set
            {
                _which = WHICH.TheClockReport;
                _content = value;
            }
        }

        public Cereal.QcomGnss.DrMeasurementReport TheDrMeasurementReport
        {
            get => _which == WHICH.TheDrMeasurementReport ? (Cereal.QcomGnss.DrMeasurementReport)_content : null;
            set
            {
                _which = WHICH.TheDrMeasurementReport;
                _content = value;
            }
        }

        public Cereal.QcomGnss.DrSvPolyReport DrSvPoly
        {
            get => _which == WHICH.DrSvPoly ? (Cereal.QcomGnss.DrSvPolyReport)_content : null;
            set
            {
                _which = WHICH.DrSvPoly;
                _content = value;
            }
        }

        public IReadOnlyList<byte> RawLog
        {
            get => _which == WHICH.RawLog ? (IReadOnlyList<byte>)_content : null;
            set
            {
                _which = WHICH.RawLog;
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
            public WHICH which => (WHICH)ctx.ReadDataUShort(64U, (ushort)0);
            public ulong LogTs => ctx.ReadDataULong(0UL, 0UL);
            public Cereal.QcomGnss.MeasurementReport.READER TheMeasurementReport => which == WHICH.TheMeasurementReport ? ctx.ReadStruct(0, Cereal.QcomGnss.MeasurementReport.READER.create) : default;
            public Cereal.QcomGnss.ClockReport.READER TheClockReport => which == WHICH.TheClockReport ? ctx.ReadStruct(0, Cereal.QcomGnss.ClockReport.READER.create) : default;
            public Cereal.QcomGnss.DrMeasurementReport.READER TheDrMeasurementReport => which == WHICH.TheDrMeasurementReport ? ctx.ReadStruct(0, Cereal.QcomGnss.DrMeasurementReport.READER.create) : default;
            public Cereal.QcomGnss.DrSvPolyReport.READER DrSvPoly => which == WHICH.DrSvPoly ? ctx.ReadStruct(0, Cereal.QcomGnss.DrSvPolyReport.READER.create) : default;
            public IReadOnlyList<byte> RawLog => which == WHICH.RawLog ? ctx.ReadList(0).CastByte() : default;
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 1);
            }

            public WHICH which
            {
                get => (WHICH)this.ReadDataUShort(64U, (ushort)0);
                set => this.WriteData(64U, (ushort)value, (ushort)0);
            }

            public ulong LogTs
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public Cereal.QcomGnss.MeasurementReport.WRITER TheMeasurementReport
            {
                get => which == WHICH.TheMeasurementReport ? BuildPointer<Cereal.QcomGnss.MeasurementReport.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.QcomGnss.ClockReport.WRITER TheClockReport
            {
                get => which == WHICH.TheClockReport ? BuildPointer<Cereal.QcomGnss.ClockReport.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.QcomGnss.DrMeasurementReport.WRITER TheDrMeasurementReport
            {
                get => which == WHICH.TheDrMeasurementReport ? BuildPointer<Cereal.QcomGnss.DrMeasurementReport.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.QcomGnss.DrSvPolyReport.WRITER DrSvPoly
            {
                get => which == WHICH.DrSvPoly ? BuildPointer<Cereal.QcomGnss.DrSvPolyReport.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<byte> RawLog
            {
                get => which == WHICH.RawLog ? BuildPointer<ListOfPrimitivesSerializer<byte>>(0) : default;
                set => Link(0, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd71a12b6faada7eeUL)]
        public enum MeasurementSource : ushort
        {
            gps,
            glonass,
            beidou
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe81e829a0d6c83e9UL)]
        public enum SVObservationState : ushort
        {
            idle,
            search,
            searchVerify,
            bitEdge,
            trackVerify,
            track,
            restart,
            dpo,
            glo10msBe,
            glo10msAt
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe501010e1bcae83bUL)]
        public class MeasurementStatus : ICapnpSerializable
        {
            public const UInt64 typeId = 0xe501010e1bcae83bUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                SubMillisecondIsValid = reader.SubMillisecondIsValid;
                SubBitTimeIsKnown = reader.SubBitTimeIsKnown;
                SatelliteTimeIsKnown = reader.SatelliteTimeIsKnown;
                BitEdgeConfirmedFromSignal = reader.BitEdgeConfirmedFromSignal;
                MeasuredVelocity = reader.MeasuredVelocity;
                FineOrCoarseVelocity = reader.FineOrCoarseVelocity;
                LockPointValid = reader.LockPointValid;
                LockPointPositive = reader.LockPointPositive;
                LastUpdateFromDifference = reader.LastUpdateFromDifference;
                LastUpdateFromVelocityDifference = reader.LastUpdateFromVelocityDifference;
                StrongIndicationOfCrossCorelation = reader.StrongIndicationOfCrossCorelation;
                TentativeMeasurement = reader.TentativeMeasurement;
                MeasurementNotUsable = reader.MeasurementNotUsable;
                SirCheckIsNeeded = reader.SirCheckIsNeeded;
                ProbationMode = reader.ProbationMode;
                GlonassMeanderBitEdgeValid = reader.GlonassMeanderBitEdgeValid;
                GlonassTimeMarkValid = reader.GlonassTimeMarkValid;
                GpsRoundRobinRxDiversity = reader.GpsRoundRobinRxDiversity;
                GpsRxDiversity = reader.GpsRxDiversity;
                GpsLowBandwidthRxDiversityCombined = reader.GpsLowBandwidthRxDiversityCombined;
                GpsHighBandwidthNu4 = reader.GpsHighBandwidthNu4;
                GpsHighBandwidthNu8 = reader.GpsHighBandwidthNu8;
                GpsHighBandwidthUniform = reader.GpsHighBandwidthUniform;
                MultipathIndicator = reader.MultipathIndicator;
                ImdJammingIndicator = reader.ImdJammingIndicator;
                LteB13TxJammingIndicator = reader.LteB13TxJammingIndicator;
                FreshMeasurementIndicator = reader.FreshMeasurementIndicator;
                MultipathEstimateIsValid = reader.MultipathEstimateIsValid;
                DirectionIsValid = reader.DirectionIsValid;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.SubMillisecondIsValid = SubMillisecondIsValid;
                writer.SubBitTimeIsKnown = SubBitTimeIsKnown;
                writer.SatelliteTimeIsKnown = SatelliteTimeIsKnown;
                writer.BitEdgeConfirmedFromSignal = BitEdgeConfirmedFromSignal;
                writer.MeasuredVelocity = MeasuredVelocity;
                writer.FineOrCoarseVelocity = FineOrCoarseVelocity;
                writer.LockPointValid = LockPointValid;
                writer.LockPointPositive = LockPointPositive;
                writer.LastUpdateFromDifference = LastUpdateFromDifference;
                writer.LastUpdateFromVelocityDifference = LastUpdateFromVelocityDifference;
                writer.StrongIndicationOfCrossCorelation = StrongIndicationOfCrossCorelation;
                writer.TentativeMeasurement = TentativeMeasurement;
                writer.MeasurementNotUsable = MeasurementNotUsable;
                writer.SirCheckIsNeeded = SirCheckIsNeeded;
                writer.ProbationMode = ProbationMode;
                writer.GlonassMeanderBitEdgeValid = GlonassMeanderBitEdgeValid;
                writer.GlonassTimeMarkValid = GlonassTimeMarkValid;
                writer.GpsRoundRobinRxDiversity = GpsRoundRobinRxDiversity;
                writer.GpsRxDiversity = GpsRxDiversity;
                writer.GpsLowBandwidthRxDiversityCombined = GpsLowBandwidthRxDiversityCombined;
                writer.GpsHighBandwidthNu4 = GpsHighBandwidthNu4;
                writer.GpsHighBandwidthNu8 = GpsHighBandwidthNu8;
                writer.GpsHighBandwidthUniform = GpsHighBandwidthUniform;
                writer.MultipathIndicator = MultipathIndicator;
                writer.ImdJammingIndicator = ImdJammingIndicator;
                writer.LteB13TxJammingIndicator = LteB13TxJammingIndicator;
                writer.FreshMeasurementIndicator = FreshMeasurementIndicator;
                writer.MultipathEstimateIsValid = MultipathEstimateIsValid;
                writer.DirectionIsValid = DirectionIsValid;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool SubMillisecondIsValid
            {
                get;
                set;
            }

            public bool SubBitTimeIsKnown
            {
                get;
                set;
            }

            public bool SatelliteTimeIsKnown
            {
                get;
                set;
            }

            public bool BitEdgeConfirmedFromSignal
            {
                get;
                set;
            }

            public bool MeasuredVelocity
            {
                get;
                set;
            }

            public bool FineOrCoarseVelocity
            {
                get;
                set;
            }

            public bool LockPointValid
            {
                get;
                set;
            }

            public bool LockPointPositive
            {
                get;
                set;
            }

            public bool LastUpdateFromDifference
            {
                get;
                set;
            }

            public bool LastUpdateFromVelocityDifference
            {
                get;
                set;
            }

            public bool StrongIndicationOfCrossCorelation
            {
                get;
                set;
            }

            public bool TentativeMeasurement
            {
                get;
                set;
            }

            public bool MeasurementNotUsable
            {
                get;
                set;
            }

            public bool SirCheckIsNeeded
            {
                get;
                set;
            }

            public bool ProbationMode
            {
                get;
                set;
            }

            public bool GlonassMeanderBitEdgeValid
            {
                get;
                set;
            }

            public bool GlonassTimeMarkValid
            {
                get;
                set;
            }

            public bool GpsRoundRobinRxDiversity
            {
                get;
                set;
            }

            public bool GpsRxDiversity
            {
                get;
                set;
            }

            public bool GpsLowBandwidthRxDiversityCombined
            {
                get;
                set;
            }

            public bool GpsHighBandwidthNu4
            {
                get;
                set;
            }

            public bool GpsHighBandwidthNu8
            {
                get;
                set;
            }

            public bool GpsHighBandwidthUniform
            {
                get;
                set;
            }

            public bool MultipathIndicator
            {
                get;
                set;
            }

            public bool ImdJammingIndicator
            {
                get;
                set;
            }

            public bool LteB13TxJammingIndicator
            {
                get;
                set;
            }

            public bool FreshMeasurementIndicator
            {
                get;
                set;
            }

            public bool MultipathEstimateIsValid
            {
                get;
                set;
            }

            public bool DirectionIsValid
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
                public bool SubMillisecondIsValid => ctx.ReadDataBool(0UL, false);
                public bool SubBitTimeIsKnown => ctx.ReadDataBool(1UL, false);
                public bool SatelliteTimeIsKnown => ctx.ReadDataBool(2UL, false);
                public bool BitEdgeConfirmedFromSignal => ctx.ReadDataBool(3UL, false);
                public bool MeasuredVelocity => ctx.ReadDataBool(4UL, false);
                public bool FineOrCoarseVelocity => ctx.ReadDataBool(5UL, false);
                public bool LockPointValid => ctx.ReadDataBool(6UL, false);
                public bool LockPointPositive => ctx.ReadDataBool(7UL, false);
                public bool LastUpdateFromDifference => ctx.ReadDataBool(8UL, false);
                public bool LastUpdateFromVelocityDifference => ctx.ReadDataBool(9UL, false);
                public bool StrongIndicationOfCrossCorelation => ctx.ReadDataBool(10UL, false);
                public bool TentativeMeasurement => ctx.ReadDataBool(11UL, false);
                public bool MeasurementNotUsable => ctx.ReadDataBool(12UL, false);
                public bool SirCheckIsNeeded => ctx.ReadDataBool(13UL, false);
                public bool ProbationMode => ctx.ReadDataBool(14UL, false);
                public bool GlonassMeanderBitEdgeValid => ctx.ReadDataBool(15UL, false);
                public bool GlonassTimeMarkValid => ctx.ReadDataBool(16UL, false);
                public bool GpsRoundRobinRxDiversity => ctx.ReadDataBool(17UL, false);
                public bool GpsRxDiversity => ctx.ReadDataBool(18UL, false);
                public bool GpsLowBandwidthRxDiversityCombined => ctx.ReadDataBool(19UL, false);
                public bool GpsHighBandwidthNu4 => ctx.ReadDataBool(20UL, false);
                public bool GpsHighBandwidthNu8 => ctx.ReadDataBool(21UL, false);
                public bool GpsHighBandwidthUniform => ctx.ReadDataBool(22UL, false);
                public bool MultipathIndicator => ctx.ReadDataBool(23UL, false);
                public bool ImdJammingIndicator => ctx.ReadDataBool(24UL, false);
                public bool LteB13TxJammingIndicator => ctx.ReadDataBool(25UL, false);
                public bool FreshMeasurementIndicator => ctx.ReadDataBool(26UL, false);
                public bool MultipathEstimateIsValid => ctx.ReadDataBool(27UL, false);
                public bool DirectionIsValid => ctx.ReadDataBool(28UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 0);
                }

                public bool SubMillisecondIsValid
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public bool SubBitTimeIsKnown
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public bool SatelliteTimeIsKnown
                {
                    get => this.ReadDataBool(2UL, false);
                    set => this.WriteData(2UL, value, false);
                }

                public bool BitEdgeConfirmedFromSignal
                {
                    get => this.ReadDataBool(3UL, false);
                    set => this.WriteData(3UL, value, false);
                }

                public bool MeasuredVelocity
                {
                    get => this.ReadDataBool(4UL, false);
                    set => this.WriteData(4UL, value, false);
                }

                public bool FineOrCoarseVelocity
                {
                    get => this.ReadDataBool(5UL, false);
                    set => this.WriteData(5UL, value, false);
                }

                public bool LockPointValid
                {
                    get => this.ReadDataBool(6UL, false);
                    set => this.WriteData(6UL, value, false);
                }

                public bool LockPointPositive
                {
                    get => this.ReadDataBool(7UL, false);
                    set => this.WriteData(7UL, value, false);
                }

                public bool LastUpdateFromDifference
                {
                    get => this.ReadDataBool(8UL, false);
                    set => this.WriteData(8UL, value, false);
                }

                public bool LastUpdateFromVelocityDifference
                {
                    get => this.ReadDataBool(9UL, false);
                    set => this.WriteData(9UL, value, false);
                }

                public bool StrongIndicationOfCrossCorelation
                {
                    get => this.ReadDataBool(10UL, false);
                    set => this.WriteData(10UL, value, false);
                }

                public bool TentativeMeasurement
                {
                    get => this.ReadDataBool(11UL, false);
                    set => this.WriteData(11UL, value, false);
                }

                public bool MeasurementNotUsable
                {
                    get => this.ReadDataBool(12UL, false);
                    set => this.WriteData(12UL, value, false);
                }

                public bool SirCheckIsNeeded
                {
                    get => this.ReadDataBool(13UL, false);
                    set => this.WriteData(13UL, value, false);
                }

                public bool ProbationMode
                {
                    get => this.ReadDataBool(14UL, false);
                    set => this.WriteData(14UL, value, false);
                }

                public bool GlonassMeanderBitEdgeValid
                {
                    get => this.ReadDataBool(15UL, false);
                    set => this.WriteData(15UL, value, false);
                }

                public bool GlonassTimeMarkValid
                {
                    get => this.ReadDataBool(16UL, false);
                    set => this.WriteData(16UL, value, false);
                }

                public bool GpsRoundRobinRxDiversity
                {
                    get => this.ReadDataBool(17UL, false);
                    set => this.WriteData(17UL, value, false);
                }

                public bool GpsRxDiversity
                {
                    get => this.ReadDataBool(18UL, false);
                    set => this.WriteData(18UL, value, false);
                }

                public bool GpsLowBandwidthRxDiversityCombined
                {
                    get => this.ReadDataBool(19UL, false);
                    set => this.WriteData(19UL, value, false);
                }

                public bool GpsHighBandwidthNu4
                {
                    get => this.ReadDataBool(20UL, false);
                    set => this.WriteData(20UL, value, false);
                }

                public bool GpsHighBandwidthNu8
                {
                    get => this.ReadDataBool(21UL, false);
                    set => this.WriteData(21UL, value, false);
                }

                public bool GpsHighBandwidthUniform
                {
                    get => this.ReadDataBool(22UL, false);
                    set => this.WriteData(22UL, value, false);
                }

                public bool MultipathIndicator
                {
                    get => this.ReadDataBool(23UL, false);
                    set => this.WriteData(23UL, value, false);
                }

                public bool ImdJammingIndicator
                {
                    get => this.ReadDataBool(24UL, false);
                    set => this.WriteData(24UL, value, false);
                }

                public bool LteB13TxJammingIndicator
                {
                    get => this.ReadDataBool(25UL, false);
                    set => this.WriteData(25UL, value, false);
                }

                public bool FreshMeasurementIndicator
                {
                    get => this.ReadDataBool(26UL, false);
                    set => this.WriteData(26UL, value, false);
                }

                public bool MultipathEstimateIsValid
                {
                    get => this.ReadDataBool(27UL, false);
                    set => this.WriteData(27UL, value, false);
                }

                public bool DirectionIsValid
                {
                    get => this.ReadDataBool(28UL, false);
                    set => this.WriteData(28UL, value, false);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf580d7d86b7b8692UL)]
        public class MeasurementReport : ICapnpSerializable
        {
            public const UInt64 typeId = 0xf580d7d86b7b8692UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Source = reader.Source;
                FCount = reader.FCount;
                GpsWeek = reader.GpsWeek;
                GlonassCycleNumber = reader.GlonassCycleNumber;
                GlonassNumberOfDays = reader.GlonassNumberOfDays;
                Milliseconds = reader.Milliseconds;
                TimeBias = reader.TimeBias;
                ClockTimeUncertainty = reader.ClockTimeUncertainty;
                ClockFrequencyBias = reader.ClockFrequencyBias;
                ClockFrequencyUncertainty = reader.ClockFrequencyUncertainty;
                Sv = reader.Sv?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.QcomGnss.MeasurementReport.SV>(_));
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Source = Source;
                writer.FCount = FCount;
                writer.GpsWeek = GpsWeek;
                writer.GlonassCycleNumber = GlonassCycleNumber;
                writer.GlonassNumberOfDays = GlonassNumberOfDays;
                writer.Milliseconds = Milliseconds;
                writer.TimeBias = TimeBias;
                writer.ClockTimeUncertainty = ClockTimeUncertainty;
                writer.ClockFrequencyBias = ClockFrequencyBias;
                writer.ClockFrequencyUncertainty = ClockFrequencyUncertainty;
                writer.Sv.Init(Sv, (_s1, _v1) => _v1?.serialize(_s1));
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public Cereal.QcomGnss.MeasurementSource Source
            {
                get;
                set;
            }

            public uint FCount
            {
                get;
                set;
            }

            public ushort GpsWeek
            {
                get;
                set;
            }

            public byte GlonassCycleNumber
            {
                get;
                set;
            }

            public ushort GlonassNumberOfDays
            {
                get;
                set;
            }

            public uint Milliseconds
            {
                get;
                set;
            }

            public float TimeBias
            {
                get;
                set;
            }

            public float ClockTimeUncertainty
            {
                get;
                set;
            }

            public float ClockFrequencyBias
            {
                get;
                set;
            }

            public float ClockFrequencyUncertainty
            {
                get;
                set;
            }

            public IReadOnlyList<Cereal.QcomGnss.MeasurementReport.SV> Sv
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
                public Cereal.QcomGnss.MeasurementSource Source => (Cereal.QcomGnss.MeasurementSource)ctx.ReadDataUShort(0UL, (ushort)0);
                public uint FCount => ctx.ReadDataUInt(32UL, 0U);
                public ushort GpsWeek => ctx.ReadDataUShort(16UL, (ushort)0);
                public byte GlonassCycleNumber => ctx.ReadDataByte(64UL, (byte)0);
                public ushort GlonassNumberOfDays => ctx.ReadDataUShort(80UL, (ushort)0);
                public uint Milliseconds => ctx.ReadDataUInt(96UL, 0U);
                public float TimeBias => ctx.ReadDataFloat(128UL, 0F);
                public float ClockTimeUncertainty => ctx.ReadDataFloat(160UL, 0F);
                public float ClockFrequencyBias => ctx.ReadDataFloat(192UL, 0F);
                public float ClockFrequencyUncertainty => ctx.ReadDataFloat(224UL, 0F);
                public IReadOnlyList<Cereal.QcomGnss.MeasurementReport.SV.READER> Sv => ctx.ReadList(0).Cast(Cereal.QcomGnss.MeasurementReport.SV.READER.create);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(4, 1);
                }

                public Cereal.QcomGnss.MeasurementSource Source
                {
                    get => (Cereal.QcomGnss.MeasurementSource)this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, (ushort)value, (ushort)0);
                }

                public uint FCount
                {
                    get => this.ReadDataUInt(32UL, 0U);
                    set => this.WriteData(32UL, value, 0U);
                }

                public ushort GpsWeek
                {
                    get => this.ReadDataUShort(16UL, (ushort)0);
                    set => this.WriteData(16UL, value, (ushort)0);
                }

                public byte GlonassCycleNumber
                {
                    get => this.ReadDataByte(64UL, (byte)0);
                    set => this.WriteData(64UL, value, (byte)0);
                }

                public ushort GlonassNumberOfDays
                {
                    get => this.ReadDataUShort(80UL, (ushort)0);
                    set => this.WriteData(80UL, value, (ushort)0);
                }

                public uint Milliseconds
                {
                    get => this.ReadDataUInt(96UL, 0U);
                    set => this.WriteData(96UL, value, 0U);
                }

                public float TimeBias
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float ClockTimeUncertainty
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float ClockFrequencyBias
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public float ClockFrequencyUncertainty
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public ListOfStructsSerializer<Cereal.QcomGnss.MeasurementReport.SV.WRITER> Sv
                {
                    get => BuildPointer<ListOfStructsSerializer<Cereal.QcomGnss.MeasurementReport.SV.WRITER>>(0);
                    set => Link(0, value);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf10c595ae7bb2c27UL)]
            public class SV : ICapnpSerializable
            {
                public const UInt64 typeId = 0xf10c595ae7bb2c27UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    SvId = reader.SvId;
                    GlonassFrequencyIndex = reader.GlonassFrequencyIndex;
                    ObservationState = reader.ObservationState;
                    Observations = reader.Observations;
                    GoodObservations = reader.GoodObservations;
                    GpsParityErrorCount = reader.GpsParityErrorCount;
                    GlonassHemmingErrorCount = reader.GlonassHemmingErrorCount;
                    FilterStages = reader.FilterStages;
                    CarrierNoise = reader.CarrierNoise;
                    Latency = reader.Latency;
                    PredetectInterval = reader.PredetectInterval;
                    Postdetections = reader.Postdetections;
                    UnfilteredMeasurementIntegral = reader.UnfilteredMeasurementIntegral;
                    UnfilteredMeasurementFraction = reader.UnfilteredMeasurementFraction;
                    UnfilteredTimeUncertainty = reader.UnfilteredTimeUncertainty;
                    UnfilteredSpeed = reader.UnfilteredSpeed;
                    UnfilteredSpeedUncertainty = reader.UnfilteredSpeedUncertainty;
                    MeasurementStatus = CapnpSerializable.Create<Cereal.QcomGnss.MeasurementStatus>(reader.MeasurementStatus);
                    MultipathEstimate = reader.MultipathEstimate;
                    Azimuth = reader.Azimuth;
                    Elevation = reader.Elevation;
                    CarrierPhaseCyclesIntegral = reader.CarrierPhaseCyclesIntegral;
                    CarrierPhaseCyclesFraction = reader.CarrierPhaseCyclesFraction;
                    FineSpeed = reader.FineSpeed;
                    FineSpeedUncertainty = reader.FineSpeedUncertainty;
                    CycleSlipCount = reader.CycleSlipCount;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.SvId = SvId;
                    writer.GlonassFrequencyIndex = GlonassFrequencyIndex;
                    writer.ObservationState = ObservationState;
                    writer.Observations = Observations;
                    writer.GoodObservations = GoodObservations;
                    writer.GpsParityErrorCount = GpsParityErrorCount;
                    writer.GlonassHemmingErrorCount = GlonassHemmingErrorCount;
                    writer.FilterStages = FilterStages;
                    writer.CarrierNoise = CarrierNoise;
                    writer.Latency = Latency;
                    writer.PredetectInterval = PredetectInterval;
                    writer.Postdetections = Postdetections;
                    writer.UnfilteredMeasurementIntegral = UnfilteredMeasurementIntegral;
                    writer.UnfilteredMeasurementFraction = UnfilteredMeasurementFraction;
                    writer.UnfilteredTimeUncertainty = UnfilteredTimeUncertainty;
                    writer.UnfilteredSpeed = UnfilteredSpeed;
                    writer.UnfilteredSpeedUncertainty = UnfilteredSpeedUncertainty;
                    MeasurementStatus?.serialize(writer.MeasurementStatus);
                    writer.MultipathEstimate = MultipathEstimate;
                    writer.Azimuth = Azimuth;
                    writer.Elevation = Elevation;
                    writer.CarrierPhaseCyclesIntegral = CarrierPhaseCyclesIntegral;
                    writer.CarrierPhaseCyclesFraction = CarrierPhaseCyclesFraction;
                    writer.FineSpeed = FineSpeed;
                    writer.FineSpeedUncertainty = FineSpeedUncertainty;
                    writer.CycleSlipCount = CycleSlipCount;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public byte SvId
                {
                    get;
                    set;
                }

                public sbyte GlonassFrequencyIndex
                {
                    get;
                    set;
                }

                public Cereal.QcomGnss.SVObservationState ObservationState
                {
                    get;
                    set;
                }

                public byte Observations
                {
                    get;
                    set;
                }

                public byte GoodObservations
                {
                    get;
                    set;
                }

                public ushort GpsParityErrorCount
                {
                    get;
                    set;
                }

                public byte GlonassHemmingErrorCount
                {
                    get;
                    set;
                }

                public byte FilterStages
                {
                    get;
                    set;
                }

                public ushort CarrierNoise
                {
                    get;
                    set;
                }

                public short Latency
                {
                    get;
                    set;
                }

                public byte PredetectInterval
                {
                    get;
                    set;
                }

                public ushort Postdetections
                {
                    get;
                    set;
                }

                public uint UnfilteredMeasurementIntegral
                {
                    get;
                    set;
                }

                public float UnfilteredMeasurementFraction
                {
                    get;
                    set;
                }

                public float UnfilteredTimeUncertainty
                {
                    get;
                    set;
                }

                public float UnfilteredSpeed
                {
                    get;
                    set;
                }

                public float UnfilteredSpeedUncertainty
                {
                    get;
                    set;
                }

                public Cereal.QcomGnss.MeasurementStatus MeasurementStatus
                {
                    get;
                    set;
                }

                public uint MultipathEstimate
                {
                    get;
                    set;
                }

                public float Azimuth
                {
                    get;
                    set;
                }

                public float Elevation
                {
                    get;
                    set;
                }

                public int CarrierPhaseCyclesIntegral
                {
                    get;
                    set;
                }

                public ushort CarrierPhaseCyclesFraction
                {
                    get;
                    set;
                }

                public float FineSpeed
                {
                    get;
                    set;
                }

                public float FineSpeedUncertainty
                {
                    get;
                    set;
                }

                public byte CycleSlipCount
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
                    public byte SvId => ctx.ReadDataByte(0UL, (byte)0);
                    public sbyte GlonassFrequencyIndex => ctx.ReadDataSByte(8UL, (sbyte)0);
                    public Cereal.QcomGnss.SVObservationState ObservationState => (Cereal.QcomGnss.SVObservationState)ctx.ReadDataUShort(16UL, (ushort)0);
                    public byte Observations => ctx.ReadDataByte(32UL, (byte)0);
                    public byte GoodObservations => ctx.ReadDataByte(40UL, (byte)0);
                    public ushort GpsParityErrorCount => ctx.ReadDataUShort(48UL, (ushort)0);
                    public byte GlonassHemmingErrorCount => ctx.ReadDataByte(64UL, (byte)0);
                    public byte FilterStages => ctx.ReadDataByte(72UL, (byte)0);
                    public ushort CarrierNoise => ctx.ReadDataUShort(80UL, (ushort)0);
                    public short Latency => ctx.ReadDataShort(96UL, (short)0);
                    public byte PredetectInterval => ctx.ReadDataByte(112UL, (byte)0);
                    public ushort Postdetections => ctx.ReadDataUShort(128UL, (ushort)0);
                    public uint UnfilteredMeasurementIntegral => ctx.ReadDataUInt(160UL, 0U);
                    public float UnfilteredMeasurementFraction => ctx.ReadDataFloat(192UL, 0F);
                    public float UnfilteredTimeUncertainty => ctx.ReadDataFloat(224UL, 0F);
                    public float UnfilteredSpeed => ctx.ReadDataFloat(256UL, 0F);
                    public float UnfilteredSpeedUncertainty => ctx.ReadDataFloat(288UL, 0F);
                    public Cereal.QcomGnss.MeasurementStatus.READER MeasurementStatus => ctx.ReadStruct(0, Cereal.QcomGnss.MeasurementStatus.READER.create);
                    public uint MultipathEstimate => ctx.ReadDataUInt(320UL, 0U);
                    public float Azimuth => ctx.ReadDataFloat(352UL, 0F);
                    public float Elevation => ctx.ReadDataFloat(384UL, 0F);
                    public int CarrierPhaseCyclesIntegral => ctx.ReadDataInt(416UL, 0);
                    public ushort CarrierPhaseCyclesFraction => ctx.ReadDataUShort(144UL, (ushort)0);
                    public float FineSpeed => ctx.ReadDataFloat(448UL, 0F);
                    public float FineSpeedUncertainty => ctx.ReadDataFloat(480UL, 0F);
                    public byte CycleSlipCount => ctx.ReadDataByte(120UL, (byte)0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(8, 1);
                    }

                    public byte SvId
                    {
                        get => this.ReadDataByte(0UL, (byte)0);
                        set => this.WriteData(0UL, value, (byte)0);
                    }

                    public sbyte GlonassFrequencyIndex
                    {
                        get => this.ReadDataSByte(8UL, (sbyte)0);
                        set => this.WriteData(8UL, value, (sbyte)0);
                    }

                    public Cereal.QcomGnss.SVObservationState ObservationState
                    {
                        get => (Cereal.QcomGnss.SVObservationState)this.ReadDataUShort(16UL, (ushort)0);
                        set => this.WriteData(16UL, (ushort)value, (ushort)0);
                    }

                    public byte Observations
                    {
                        get => this.ReadDataByte(32UL, (byte)0);
                        set => this.WriteData(32UL, value, (byte)0);
                    }

                    public byte GoodObservations
                    {
                        get => this.ReadDataByte(40UL, (byte)0);
                        set => this.WriteData(40UL, value, (byte)0);
                    }

                    public ushort GpsParityErrorCount
                    {
                        get => this.ReadDataUShort(48UL, (ushort)0);
                        set => this.WriteData(48UL, value, (ushort)0);
                    }

                    public byte GlonassHemmingErrorCount
                    {
                        get => this.ReadDataByte(64UL, (byte)0);
                        set => this.WriteData(64UL, value, (byte)0);
                    }

                    public byte FilterStages
                    {
                        get => this.ReadDataByte(72UL, (byte)0);
                        set => this.WriteData(72UL, value, (byte)0);
                    }

                    public ushort CarrierNoise
                    {
                        get => this.ReadDataUShort(80UL, (ushort)0);
                        set => this.WriteData(80UL, value, (ushort)0);
                    }

                    public short Latency
                    {
                        get => this.ReadDataShort(96UL, (short)0);
                        set => this.WriteData(96UL, value, (short)0);
                    }

                    public byte PredetectInterval
                    {
                        get => this.ReadDataByte(112UL, (byte)0);
                        set => this.WriteData(112UL, value, (byte)0);
                    }

                    public ushort Postdetections
                    {
                        get => this.ReadDataUShort(128UL, (ushort)0);
                        set => this.WriteData(128UL, value, (ushort)0);
                    }

                    public uint UnfilteredMeasurementIntegral
                    {
                        get => this.ReadDataUInt(160UL, 0U);
                        set => this.WriteData(160UL, value, 0U);
                    }

                    public float UnfilteredMeasurementFraction
                    {
                        get => this.ReadDataFloat(192UL, 0F);
                        set => this.WriteData(192UL, value, 0F);
                    }

                    public float UnfilteredTimeUncertainty
                    {
                        get => this.ReadDataFloat(224UL, 0F);
                        set => this.WriteData(224UL, value, 0F);
                    }

                    public float UnfilteredSpeed
                    {
                        get => this.ReadDataFloat(256UL, 0F);
                        set => this.WriteData(256UL, value, 0F);
                    }

                    public float UnfilteredSpeedUncertainty
                    {
                        get => this.ReadDataFloat(288UL, 0F);
                        set => this.WriteData(288UL, value, 0F);
                    }

                    public Cereal.QcomGnss.MeasurementStatus.WRITER MeasurementStatus
                    {
                        get => BuildPointer<Cereal.QcomGnss.MeasurementStatus.WRITER>(0);
                        set => Link(0, value);
                    }

                    public uint MultipathEstimate
                    {
                        get => this.ReadDataUInt(320UL, 0U);
                        set => this.WriteData(320UL, value, 0U);
                    }

                    public float Azimuth
                    {
                        get => this.ReadDataFloat(352UL, 0F);
                        set => this.WriteData(352UL, value, 0F);
                    }

                    public float Elevation
                    {
                        get => this.ReadDataFloat(384UL, 0F);
                        set => this.WriteData(384UL, value, 0F);
                    }

                    public int CarrierPhaseCyclesIntegral
                    {
                        get => this.ReadDataInt(416UL, 0);
                        set => this.WriteData(416UL, value, 0);
                    }

                    public ushort CarrierPhaseCyclesFraction
                    {
                        get => this.ReadDataUShort(144UL, (ushort)0);
                        set => this.WriteData(144UL, value, (ushort)0);
                    }

                    public float FineSpeed
                    {
                        get => this.ReadDataFloat(448UL, 0F);
                        set => this.WriteData(448UL, value, 0F);
                    }

                    public float FineSpeedUncertainty
                    {
                        get => this.ReadDataFloat(480UL, 0F);
                        set => this.WriteData(480UL, value, 0F);
                    }

                    public byte CycleSlipCount
                    {
                        get => this.ReadDataByte(120UL, (byte)0);
                        set => this.WriteData(120UL, value, (byte)0);
                    }
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xca965e4add8f4f0bUL)]
        public class ClockReport : ICapnpSerializable
        {
            public const UInt64 typeId = 0xca965e4add8f4f0bUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                HasFCount = reader.HasFCount;
                FCount = reader.FCount;
                HasGpsWeek = reader.HasGpsWeek;
                GpsWeek = reader.GpsWeek;
                HasGpsMilliseconds = reader.HasGpsMilliseconds;
                GpsMilliseconds = reader.GpsMilliseconds;
                GpsTimeBias = reader.GpsTimeBias;
                GpsClockTimeUncertainty = reader.GpsClockTimeUncertainty;
                GpsClockSource = reader.GpsClockSource;
                HasGlonassYear = reader.HasGlonassYear;
                GlonassYear = reader.GlonassYear;
                HasGlonassDay = reader.HasGlonassDay;
                GlonassDay = reader.GlonassDay;
                HasGlonassMilliseconds = reader.HasGlonassMilliseconds;
                GlonassMilliseconds = reader.GlonassMilliseconds;
                GlonassTimeBias = reader.GlonassTimeBias;
                GlonassClockTimeUncertainty = reader.GlonassClockTimeUncertainty;
                GlonassClockSource = reader.GlonassClockSource;
                BdsWeek = reader.BdsWeek;
                BdsMilliseconds = reader.BdsMilliseconds;
                BdsTimeBias = reader.BdsTimeBias;
                BdsClockTimeUncertainty = reader.BdsClockTimeUncertainty;
                BdsClockSource = reader.BdsClockSource;
                GalWeek = reader.GalWeek;
                GalMilliseconds = reader.GalMilliseconds;
                GalTimeBias = reader.GalTimeBias;
                GalClockTimeUncertainty = reader.GalClockTimeUncertainty;
                GalClockSource = reader.GalClockSource;
                ClockFrequencyBias = reader.ClockFrequencyBias;
                ClockFrequencyUncertainty = reader.ClockFrequencyUncertainty;
                FrequencySource = reader.FrequencySource;
                GpsLeapSeconds = reader.GpsLeapSeconds;
                GpsLeapSecondsUncertainty = reader.GpsLeapSecondsUncertainty;
                GpsLeapSecondsSource = reader.GpsLeapSecondsSource;
                GpsToGlonassTimeBiasMilliseconds = reader.GpsToGlonassTimeBiasMilliseconds;
                GpsToGlonassTimeBiasMillisecondsUncertainty = reader.GpsToGlonassTimeBiasMillisecondsUncertainty;
                GpsToBdsTimeBiasMilliseconds = reader.GpsToBdsTimeBiasMilliseconds;
                GpsToBdsTimeBiasMillisecondsUncertainty = reader.GpsToBdsTimeBiasMillisecondsUncertainty;
                BdsToGloTimeBiasMilliseconds = reader.BdsToGloTimeBiasMilliseconds;
                BdsToGloTimeBiasMillisecondsUncertainty = reader.BdsToGloTimeBiasMillisecondsUncertainty;
                GpsToGalTimeBiasMilliseconds = reader.GpsToGalTimeBiasMilliseconds;
                GpsToGalTimeBiasMillisecondsUncertainty = reader.GpsToGalTimeBiasMillisecondsUncertainty;
                GalToGloTimeBiasMilliseconds = reader.GalToGloTimeBiasMilliseconds;
                GalToGloTimeBiasMillisecondsUncertainty = reader.GalToGloTimeBiasMillisecondsUncertainty;
                GalToBdsTimeBiasMilliseconds = reader.GalToBdsTimeBiasMilliseconds;
                GalToBdsTimeBiasMillisecondsUncertainty = reader.GalToBdsTimeBiasMillisecondsUncertainty;
                HasRtcTime = reader.HasRtcTime;
                SystemRtcTime = reader.SystemRtcTime;
                FCountOffset = reader.FCountOffset;
                LpmRtcCount = reader.LpmRtcCount;
                ClockResets = reader.ClockResets;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.HasFCount = HasFCount;
                writer.FCount = FCount;
                writer.HasGpsWeek = HasGpsWeek;
                writer.GpsWeek = GpsWeek;
                writer.HasGpsMilliseconds = HasGpsMilliseconds;
                writer.GpsMilliseconds = GpsMilliseconds;
                writer.GpsTimeBias = GpsTimeBias;
                writer.GpsClockTimeUncertainty = GpsClockTimeUncertainty;
                writer.GpsClockSource = GpsClockSource;
                writer.HasGlonassYear = HasGlonassYear;
                writer.GlonassYear = GlonassYear;
                writer.HasGlonassDay = HasGlonassDay;
                writer.GlonassDay = GlonassDay;
                writer.HasGlonassMilliseconds = HasGlonassMilliseconds;
                writer.GlonassMilliseconds = GlonassMilliseconds;
                writer.GlonassTimeBias = GlonassTimeBias;
                writer.GlonassClockTimeUncertainty = GlonassClockTimeUncertainty;
                writer.GlonassClockSource = GlonassClockSource;
                writer.BdsWeek = BdsWeek;
                writer.BdsMilliseconds = BdsMilliseconds;
                writer.BdsTimeBias = BdsTimeBias;
                writer.BdsClockTimeUncertainty = BdsClockTimeUncertainty;
                writer.BdsClockSource = BdsClockSource;
                writer.GalWeek = GalWeek;
                writer.GalMilliseconds = GalMilliseconds;
                writer.GalTimeBias = GalTimeBias;
                writer.GalClockTimeUncertainty = GalClockTimeUncertainty;
                writer.GalClockSource = GalClockSource;
                writer.ClockFrequencyBias = ClockFrequencyBias;
                writer.ClockFrequencyUncertainty = ClockFrequencyUncertainty;
                writer.FrequencySource = FrequencySource;
                writer.GpsLeapSeconds = GpsLeapSeconds;
                writer.GpsLeapSecondsUncertainty = GpsLeapSecondsUncertainty;
                writer.GpsLeapSecondsSource = GpsLeapSecondsSource;
                writer.GpsToGlonassTimeBiasMilliseconds = GpsToGlonassTimeBiasMilliseconds;
                writer.GpsToGlonassTimeBiasMillisecondsUncertainty = GpsToGlonassTimeBiasMillisecondsUncertainty;
                writer.GpsToBdsTimeBiasMilliseconds = GpsToBdsTimeBiasMilliseconds;
                writer.GpsToBdsTimeBiasMillisecondsUncertainty = GpsToBdsTimeBiasMillisecondsUncertainty;
                writer.BdsToGloTimeBiasMilliseconds = BdsToGloTimeBiasMilliseconds;
                writer.BdsToGloTimeBiasMillisecondsUncertainty = BdsToGloTimeBiasMillisecondsUncertainty;
                writer.GpsToGalTimeBiasMilliseconds = GpsToGalTimeBiasMilliseconds;
                writer.GpsToGalTimeBiasMillisecondsUncertainty = GpsToGalTimeBiasMillisecondsUncertainty;
                writer.GalToGloTimeBiasMilliseconds = GalToGloTimeBiasMilliseconds;
                writer.GalToGloTimeBiasMillisecondsUncertainty = GalToGloTimeBiasMillisecondsUncertainty;
                writer.GalToBdsTimeBiasMilliseconds = GalToBdsTimeBiasMilliseconds;
                writer.GalToBdsTimeBiasMillisecondsUncertainty = GalToBdsTimeBiasMillisecondsUncertainty;
                writer.HasRtcTime = HasRtcTime;
                writer.SystemRtcTime = SystemRtcTime;
                writer.FCountOffset = FCountOffset;
                writer.LpmRtcCount = LpmRtcCount;
                writer.ClockResets = ClockResets;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool HasFCount
            {
                get;
                set;
            }

            public uint FCount
            {
                get;
                set;
            }

            public bool HasGpsWeek
            {
                get;
                set;
            }

            public ushort GpsWeek
            {
                get;
                set;
            }

            public bool HasGpsMilliseconds
            {
                get;
                set;
            }

            public uint GpsMilliseconds
            {
                get;
                set;
            }

            public float GpsTimeBias
            {
                get;
                set;
            }

            public float GpsClockTimeUncertainty
            {
                get;
                set;
            }

            public byte GpsClockSource
            {
                get;
                set;
            }

            public bool HasGlonassYear
            {
                get;
                set;
            }

            public byte GlonassYear
            {
                get;
                set;
            }

            public bool HasGlonassDay
            {
                get;
                set;
            }

            public ushort GlonassDay
            {
                get;
                set;
            }

            public bool HasGlonassMilliseconds
            {
                get;
                set;
            }

            public uint GlonassMilliseconds
            {
                get;
                set;
            }

            public float GlonassTimeBias
            {
                get;
                set;
            }

            public float GlonassClockTimeUncertainty
            {
                get;
                set;
            }

            public byte GlonassClockSource
            {
                get;
                set;
            }

            public ushort BdsWeek
            {
                get;
                set;
            }

            public uint BdsMilliseconds
            {
                get;
                set;
            }

            public float BdsTimeBias
            {
                get;
                set;
            }

            public float BdsClockTimeUncertainty
            {
                get;
                set;
            }

            public byte BdsClockSource
            {
                get;
                set;
            }

            public ushort GalWeek
            {
                get;
                set;
            }

            public uint GalMilliseconds
            {
                get;
                set;
            }

            public float GalTimeBias
            {
                get;
                set;
            }

            public float GalClockTimeUncertainty
            {
                get;
                set;
            }

            public byte GalClockSource
            {
                get;
                set;
            }

            public float ClockFrequencyBias
            {
                get;
                set;
            }

            public float ClockFrequencyUncertainty
            {
                get;
                set;
            }

            public byte FrequencySource
            {
                get;
                set;
            }

            public byte GpsLeapSeconds
            {
                get;
                set;
            }

            public byte GpsLeapSecondsUncertainty
            {
                get;
                set;
            }

            public byte GpsLeapSecondsSource
            {
                get;
                set;
            }

            public float GpsToGlonassTimeBiasMilliseconds
            {
                get;
                set;
            }

            public float GpsToGlonassTimeBiasMillisecondsUncertainty
            {
                get;
                set;
            }

            public float GpsToBdsTimeBiasMilliseconds
            {
                get;
                set;
            }

            public float GpsToBdsTimeBiasMillisecondsUncertainty
            {
                get;
                set;
            }

            public float BdsToGloTimeBiasMilliseconds
            {
                get;
                set;
            }

            public float BdsToGloTimeBiasMillisecondsUncertainty
            {
                get;
                set;
            }

            public float GpsToGalTimeBiasMilliseconds
            {
                get;
                set;
            }

            public float GpsToGalTimeBiasMillisecondsUncertainty
            {
                get;
                set;
            }

            public float GalToGloTimeBiasMilliseconds
            {
                get;
                set;
            }

            public float GalToGloTimeBiasMillisecondsUncertainty
            {
                get;
                set;
            }

            public float GalToBdsTimeBiasMilliseconds
            {
                get;
                set;
            }

            public float GalToBdsTimeBiasMillisecondsUncertainty
            {
                get;
                set;
            }

            public bool HasRtcTime
            {
                get;
                set;
            }

            public uint SystemRtcTime
            {
                get;
                set;
            }

            public uint FCountOffset
            {
                get;
                set;
            }

            public uint LpmRtcCount
            {
                get;
                set;
            }

            public uint ClockResets
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
                public bool HasFCount => ctx.ReadDataBool(0UL, false);
                public uint FCount => ctx.ReadDataUInt(32UL, 0U);
                public bool HasGpsWeek => ctx.ReadDataBool(1UL, false);
                public ushort GpsWeek => ctx.ReadDataUShort(16UL, (ushort)0);
                public bool HasGpsMilliseconds => ctx.ReadDataBool(2UL, false);
                public uint GpsMilliseconds => ctx.ReadDataUInt(64UL, 0U);
                public float GpsTimeBias => ctx.ReadDataFloat(96UL, 0F);
                public float GpsClockTimeUncertainty => ctx.ReadDataFloat(128UL, 0F);
                public byte GpsClockSource => ctx.ReadDataByte(8UL, (byte)0);
                public bool HasGlonassYear => ctx.ReadDataBool(3UL, false);
                public byte GlonassYear => ctx.ReadDataByte(160UL, (byte)0);
                public bool HasGlonassDay => ctx.ReadDataBool(4UL, false);
                public ushort GlonassDay => ctx.ReadDataUShort(176UL, (ushort)0);
                public bool HasGlonassMilliseconds => ctx.ReadDataBool(5UL, false);
                public uint GlonassMilliseconds => ctx.ReadDataUInt(192UL, 0U);
                public float GlonassTimeBias => ctx.ReadDataFloat(224UL, 0F);
                public float GlonassClockTimeUncertainty => ctx.ReadDataFloat(256UL, 0F);
                public byte GlonassClockSource => ctx.ReadDataByte(168UL, (byte)0);
                public ushort BdsWeek => ctx.ReadDataUShort(288UL, (ushort)0);
                public uint BdsMilliseconds => ctx.ReadDataUInt(320UL, 0U);
                public float BdsTimeBias => ctx.ReadDataFloat(352UL, 0F);
                public float BdsClockTimeUncertainty => ctx.ReadDataFloat(384UL, 0F);
                public byte BdsClockSource => ctx.ReadDataByte(304UL, (byte)0);
                public ushort GalWeek => ctx.ReadDataUShort(416UL, (ushort)0);
                public uint GalMilliseconds => ctx.ReadDataUInt(448UL, 0U);
                public float GalTimeBias => ctx.ReadDataFloat(480UL, 0F);
                public float GalClockTimeUncertainty => ctx.ReadDataFloat(512UL, 0F);
                public byte GalClockSource => ctx.ReadDataByte(312UL, (byte)0);
                public float ClockFrequencyBias => ctx.ReadDataFloat(544UL, 0F);
                public float ClockFrequencyUncertainty => ctx.ReadDataFloat(576UL, 0F);
                public byte FrequencySource => ctx.ReadDataByte(432UL, (byte)0);
                public byte GpsLeapSeconds => ctx.ReadDataByte(440UL, (byte)0);
                public byte GpsLeapSecondsUncertainty => ctx.ReadDataByte(608UL, (byte)0);
                public byte GpsLeapSecondsSource => ctx.ReadDataByte(616UL, (byte)0);
                public float GpsToGlonassTimeBiasMilliseconds => ctx.ReadDataFloat(640UL, 0F);
                public float GpsToGlonassTimeBiasMillisecondsUncertainty => ctx.ReadDataFloat(672UL, 0F);
                public float GpsToBdsTimeBiasMilliseconds => ctx.ReadDataFloat(704UL, 0F);
                public float GpsToBdsTimeBiasMillisecondsUncertainty => ctx.ReadDataFloat(736UL, 0F);
                public float BdsToGloTimeBiasMilliseconds => ctx.ReadDataFloat(768UL, 0F);
                public float BdsToGloTimeBiasMillisecondsUncertainty => ctx.ReadDataFloat(800UL, 0F);
                public float GpsToGalTimeBiasMilliseconds => ctx.ReadDataFloat(832UL, 0F);
                public float GpsToGalTimeBiasMillisecondsUncertainty => ctx.ReadDataFloat(864UL, 0F);
                public float GalToGloTimeBiasMilliseconds => ctx.ReadDataFloat(896UL, 0F);
                public float GalToGloTimeBiasMillisecondsUncertainty => ctx.ReadDataFloat(928UL, 0F);
                public float GalToBdsTimeBiasMilliseconds => ctx.ReadDataFloat(960UL, 0F);
                public float GalToBdsTimeBiasMillisecondsUncertainty => ctx.ReadDataFloat(992UL, 0F);
                public bool HasRtcTime => ctx.ReadDataBool(6UL, false);
                public uint SystemRtcTime => ctx.ReadDataUInt(1024UL, 0U);
                public uint FCountOffset => ctx.ReadDataUInt(1056UL, 0U);
                public uint LpmRtcCount => ctx.ReadDataUInt(1088UL, 0U);
                public uint ClockResets => ctx.ReadDataUInt(1120UL, 0U);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(18, 0);
                }

                public bool HasFCount
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public uint FCount
                {
                    get => this.ReadDataUInt(32UL, 0U);
                    set => this.WriteData(32UL, value, 0U);
                }

                public bool HasGpsWeek
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public ushort GpsWeek
                {
                    get => this.ReadDataUShort(16UL, (ushort)0);
                    set => this.WriteData(16UL, value, (ushort)0);
                }

                public bool HasGpsMilliseconds
                {
                    get => this.ReadDataBool(2UL, false);
                    set => this.WriteData(2UL, value, false);
                }

                public uint GpsMilliseconds
                {
                    get => this.ReadDataUInt(64UL, 0U);
                    set => this.WriteData(64UL, value, 0U);
                }

                public float GpsTimeBias
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float GpsClockTimeUncertainty
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public byte GpsClockSource
                {
                    get => this.ReadDataByte(8UL, (byte)0);
                    set => this.WriteData(8UL, value, (byte)0);
                }

                public bool HasGlonassYear
                {
                    get => this.ReadDataBool(3UL, false);
                    set => this.WriteData(3UL, value, false);
                }

                public byte GlonassYear
                {
                    get => this.ReadDataByte(160UL, (byte)0);
                    set => this.WriteData(160UL, value, (byte)0);
                }

                public bool HasGlonassDay
                {
                    get => this.ReadDataBool(4UL, false);
                    set => this.WriteData(4UL, value, false);
                }

                public ushort GlonassDay
                {
                    get => this.ReadDataUShort(176UL, (ushort)0);
                    set => this.WriteData(176UL, value, (ushort)0);
                }

                public bool HasGlonassMilliseconds
                {
                    get => this.ReadDataBool(5UL, false);
                    set => this.WriteData(5UL, value, false);
                }

                public uint GlonassMilliseconds
                {
                    get => this.ReadDataUInt(192UL, 0U);
                    set => this.WriteData(192UL, value, 0U);
                }

                public float GlonassTimeBias
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public float GlonassClockTimeUncertainty
                {
                    get => this.ReadDataFloat(256UL, 0F);
                    set => this.WriteData(256UL, value, 0F);
                }

                public byte GlonassClockSource
                {
                    get => this.ReadDataByte(168UL, (byte)0);
                    set => this.WriteData(168UL, value, (byte)0);
                }

                public ushort BdsWeek
                {
                    get => this.ReadDataUShort(288UL, (ushort)0);
                    set => this.WriteData(288UL, value, (ushort)0);
                }

                public uint BdsMilliseconds
                {
                    get => this.ReadDataUInt(320UL, 0U);
                    set => this.WriteData(320UL, value, 0U);
                }

                public float BdsTimeBias
                {
                    get => this.ReadDataFloat(352UL, 0F);
                    set => this.WriteData(352UL, value, 0F);
                }

                public float BdsClockTimeUncertainty
                {
                    get => this.ReadDataFloat(384UL, 0F);
                    set => this.WriteData(384UL, value, 0F);
                }

                public byte BdsClockSource
                {
                    get => this.ReadDataByte(304UL, (byte)0);
                    set => this.WriteData(304UL, value, (byte)0);
                }

                public ushort GalWeek
                {
                    get => this.ReadDataUShort(416UL, (ushort)0);
                    set => this.WriteData(416UL, value, (ushort)0);
                }

                public uint GalMilliseconds
                {
                    get => this.ReadDataUInt(448UL, 0U);
                    set => this.WriteData(448UL, value, 0U);
                }

                public float GalTimeBias
                {
                    get => this.ReadDataFloat(480UL, 0F);
                    set => this.WriteData(480UL, value, 0F);
                }

                public float GalClockTimeUncertainty
                {
                    get => this.ReadDataFloat(512UL, 0F);
                    set => this.WriteData(512UL, value, 0F);
                }

                public byte GalClockSource
                {
                    get => this.ReadDataByte(312UL, (byte)0);
                    set => this.WriteData(312UL, value, (byte)0);
                }

                public float ClockFrequencyBias
                {
                    get => this.ReadDataFloat(544UL, 0F);
                    set => this.WriteData(544UL, value, 0F);
                }

                public float ClockFrequencyUncertainty
                {
                    get => this.ReadDataFloat(576UL, 0F);
                    set => this.WriteData(576UL, value, 0F);
                }

                public byte FrequencySource
                {
                    get => this.ReadDataByte(432UL, (byte)0);
                    set => this.WriteData(432UL, value, (byte)0);
                }

                public byte GpsLeapSeconds
                {
                    get => this.ReadDataByte(440UL, (byte)0);
                    set => this.WriteData(440UL, value, (byte)0);
                }

                public byte GpsLeapSecondsUncertainty
                {
                    get => this.ReadDataByte(608UL, (byte)0);
                    set => this.WriteData(608UL, value, (byte)0);
                }

                public byte GpsLeapSecondsSource
                {
                    get => this.ReadDataByte(616UL, (byte)0);
                    set => this.WriteData(616UL, value, (byte)0);
                }

                public float GpsToGlonassTimeBiasMilliseconds
                {
                    get => this.ReadDataFloat(640UL, 0F);
                    set => this.WriteData(640UL, value, 0F);
                }

                public float GpsToGlonassTimeBiasMillisecondsUncertainty
                {
                    get => this.ReadDataFloat(672UL, 0F);
                    set => this.WriteData(672UL, value, 0F);
                }

                public float GpsToBdsTimeBiasMilliseconds
                {
                    get => this.ReadDataFloat(704UL, 0F);
                    set => this.WriteData(704UL, value, 0F);
                }

                public float GpsToBdsTimeBiasMillisecondsUncertainty
                {
                    get => this.ReadDataFloat(736UL, 0F);
                    set => this.WriteData(736UL, value, 0F);
                }

                public float BdsToGloTimeBiasMilliseconds
                {
                    get => this.ReadDataFloat(768UL, 0F);
                    set => this.WriteData(768UL, value, 0F);
                }

                public float BdsToGloTimeBiasMillisecondsUncertainty
                {
                    get => this.ReadDataFloat(800UL, 0F);
                    set => this.WriteData(800UL, value, 0F);
                }

                public float GpsToGalTimeBiasMilliseconds
                {
                    get => this.ReadDataFloat(832UL, 0F);
                    set => this.WriteData(832UL, value, 0F);
                }

                public float GpsToGalTimeBiasMillisecondsUncertainty
                {
                    get => this.ReadDataFloat(864UL, 0F);
                    set => this.WriteData(864UL, value, 0F);
                }

                public float GalToGloTimeBiasMilliseconds
                {
                    get => this.ReadDataFloat(896UL, 0F);
                    set => this.WriteData(896UL, value, 0F);
                }

                public float GalToGloTimeBiasMillisecondsUncertainty
                {
                    get => this.ReadDataFloat(928UL, 0F);
                    set => this.WriteData(928UL, value, 0F);
                }

                public float GalToBdsTimeBiasMilliseconds
                {
                    get => this.ReadDataFloat(960UL, 0F);
                    set => this.WriteData(960UL, value, 0F);
                }

                public float GalToBdsTimeBiasMillisecondsUncertainty
                {
                    get => this.ReadDataFloat(992UL, 0F);
                    set => this.WriteData(992UL, value, 0F);
                }

                public bool HasRtcTime
                {
                    get => this.ReadDataBool(6UL, false);
                    set => this.WriteData(6UL, value, false);
                }

                public uint SystemRtcTime
                {
                    get => this.ReadDataUInt(1024UL, 0U);
                    set => this.WriteData(1024UL, value, 0U);
                }

                public uint FCountOffset
                {
                    get => this.ReadDataUInt(1056UL, 0U);
                    set => this.WriteData(1056UL, value, 0U);
                }

                public uint LpmRtcCount
                {
                    get => this.ReadDataUInt(1088UL, 0U);
                    set => this.WriteData(1088UL, value, 0U);
                }

                public uint ClockResets
                {
                    get => this.ReadDataUInt(1120UL, 0U);
                    set => this.WriteData(1120UL, value, 0U);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8053c39445c6c75cUL)]
        public class DrMeasurementReport : ICapnpSerializable
        {
            public const UInt64 typeId = 0x8053c39445c6c75cUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Reason = reader.Reason;
                SeqNum = reader.SeqNum;
                SeqMax = reader.SeqMax;
                RfLoss = reader.RfLoss;
                SystemRtcValid = reader.SystemRtcValid;
                FCount = reader.FCount;
                ClockResets = reader.ClockResets;
                SystemRtcTime = reader.SystemRtcTime;
                GpsLeapSeconds = reader.GpsLeapSeconds;
                GpsLeapSecondsUncertainty = reader.GpsLeapSecondsUncertainty;
                GpsToGlonassTimeBiasMilliseconds = reader.GpsToGlonassTimeBiasMilliseconds;
                GpsToGlonassTimeBiasMillisecondsUncertainty = reader.GpsToGlonassTimeBiasMillisecondsUncertainty;
                GpsWeek = reader.GpsWeek;
                GpsMilliseconds = reader.GpsMilliseconds;
                GpsTimeBiasMs = reader.GpsTimeBiasMs;
                GpsClockTimeUncertaintyMs = reader.GpsClockTimeUncertaintyMs;
                GpsClockSource = reader.GpsClockSource;
                GlonassClockSource = reader.GlonassClockSource;
                GlonassYear = reader.GlonassYear;
                GlonassDay = reader.GlonassDay;
                GlonassMilliseconds = reader.GlonassMilliseconds;
                GlonassTimeBias = reader.GlonassTimeBias;
                GlonassClockTimeUncertainty = reader.GlonassClockTimeUncertainty;
                ClockFrequencyBias = reader.ClockFrequencyBias;
                ClockFrequencyUncertainty = reader.ClockFrequencyUncertainty;
                FrequencySource = reader.FrequencySource;
                Source = reader.Source;
                Sv = reader.Sv?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.QcomGnss.DrMeasurementReport.SV>(_));
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Reason = Reason;
                writer.SeqNum = SeqNum;
                writer.SeqMax = SeqMax;
                writer.RfLoss = RfLoss;
                writer.SystemRtcValid = SystemRtcValid;
                writer.FCount = FCount;
                writer.ClockResets = ClockResets;
                writer.SystemRtcTime = SystemRtcTime;
                writer.GpsLeapSeconds = GpsLeapSeconds;
                writer.GpsLeapSecondsUncertainty = GpsLeapSecondsUncertainty;
                writer.GpsToGlonassTimeBiasMilliseconds = GpsToGlonassTimeBiasMilliseconds;
                writer.GpsToGlonassTimeBiasMillisecondsUncertainty = GpsToGlonassTimeBiasMillisecondsUncertainty;
                writer.GpsWeek = GpsWeek;
                writer.GpsMilliseconds = GpsMilliseconds;
                writer.GpsTimeBiasMs = GpsTimeBiasMs;
                writer.GpsClockTimeUncertaintyMs = GpsClockTimeUncertaintyMs;
                writer.GpsClockSource = GpsClockSource;
                writer.GlonassClockSource = GlonassClockSource;
                writer.GlonassYear = GlonassYear;
                writer.GlonassDay = GlonassDay;
                writer.GlonassMilliseconds = GlonassMilliseconds;
                writer.GlonassTimeBias = GlonassTimeBias;
                writer.GlonassClockTimeUncertainty = GlonassClockTimeUncertainty;
                writer.ClockFrequencyBias = ClockFrequencyBias;
                writer.ClockFrequencyUncertainty = ClockFrequencyUncertainty;
                writer.FrequencySource = FrequencySource;
                writer.Source = Source;
                writer.Sv.Init(Sv, (_s1, _v1) => _v1?.serialize(_s1));
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public byte Reason
            {
                get;
                set;
            }

            public byte SeqNum
            {
                get;
                set;
            }

            public byte SeqMax
            {
                get;
                set;
            }

            public ushort RfLoss
            {
                get;
                set;
            }

            public bool SystemRtcValid
            {
                get;
                set;
            }

            public uint FCount
            {
                get;
                set;
            }

            public uint ClockResets
            {
                get;
                set;
            }

            public ulong SystemRtcTime
            {
                get;
                set;
            }

            public byte GpsLeapSeconds
            {
                get;
                set;
            }

            public byte GpsLeapSecondsUncertainty
            {
                get;
                set;
            }

            public float GpsToGlonassTimeBiasMilliseconds
            {
                get;
                set;
            }

            public float GpsToGlonassTimeBiasMillisecondsUncertainty
            {
                get;
                set;
            }

            public ushort GpsWeek
            {
                get;
                set;
            }

            public uint GpsMilliseconds
            {
                get;
                set;
            }

            public uint GpsTimeBiasMs
            {
                get;
                set;
            }

            public uint GpsClockTimeUncertaintyMs
            {
                get;
                set;
            }

            public byte GpsClockSource
            {
                get;
                set;
            }

            public byte GlonassClockSource
            {
                get;
                set;
            }

            public byte GlonassYear
            {
                get;
                set;
            }

            public ushort GlonassDay
            {
                get;
                set;
            }

            public uint GlonassMilliseconds
            {
                get;
                set;
            }

            public float GlonassTimeBias
            {
                get;
                set;
            }

            public float GlonassClockTimeUncertainty
            {
                get;
                set;
            }

            public float ClockFrequencyBias
            {
                get;
                set;
            }

            public float ClockFrequencyUncertainty
            {
                get;
                set;
            }

            public byte FrequencySource
            {
                get;
                set;
            }

            public Cereal.QcomGnss.MeasurementSource Source
            {
                get;
                set;
            }

            public IReadOnlyList<Cereal.QcomGnss.DrMeasurementReport.SV> Sv
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
                public byte Reason => ctx.ReadDataByte(0UL, (byte)0);
                public byte SeqNum => ctx.ReadDataByte(8UL, (byte)0);
                public byte SeqMax => ctx.ReadDataByte(16UL, (byte)0);
                public ushort RfLoss => ctx.ReadDataUShort(32UL, (ushort)0);
                public bool SystemRtcValid => ctx.ReadDataBool(24UL, false);
                public uint FCount => ctx.ReadDataUInt(64UL, 0U);
                public uint ClockResets => ctx.ReadDataUInt(96UL, 0U);
                public ulong SystemRtcTime => ctx.ReadDataULong(128UL, 0UL);
                public byte GpsLeapSeconds => ctx.ReadDataByte(48UL, (byte)0);
                public byte GpsLeapSecondsUncertainty => ctx.ReadDataByte(56UL, (byte)0);
                public float GpsToGlonassTimeBiasMilliseconds => ctx.ReadDataFloat(192UL, 0F);
                public float GpsToGlonassTimeBiasMillisecondsUncertainty => ctx.ReadDataFloat(224UL, 0F);
                public ushort GpsWeek => ctx.ReadDataUShort(256UL, (ushort)0);
                public uint GpsMilliseconds => ctx.ReadDataUInt(288UL, 0U);
                public uint GpsTimeBiasMs => ctx.ReadDataUInt(320UL, 0U);
                public uint GpsClockTimeUncertaintyMs => ctx.ReadDataUInt(352UL, 0U);
                public byte GpsClockSource => ctx.ReadDataByte(272UL, (byte)0);
                public byte GlonassClockSource => ctx.ReadDataByte(280UL, (byte)0);
                public byte GlonassYear => ctx.ReadDataByte(384UL, (byte)0);
                public ushort GlonassDay => ctx.ReadDataUShort(400UL, (ushort)0);
                public uint GlonassMilliseconds => ctx.ReadDataUInt(416UL, 0U);
                public float GlonassTimeBias => ctx.ReadDataFloat(448UL, 0F);
                public float GlonassClockTimeUncertainty => ctx.ReadDataFloat(480UL, 0F);
                public float ClockFrequencyBias => ctx.ReadDataFloat(512UL, 0F);
                public float ClockFrequencyUncertainty => ctx.ReadDataFloat(544UL, 0F);
                public byte FrequencySource => ctx.ReadDataByte(392UL, (byte)0);
                public Cereal.QcomGnss.MeasurementSource Source => (Cereal.QcomGnss.MeasurementSource)ctx.ReadDataUShort(576UL, (ushort)0);
                public IReadOnlyList<Cereal.QcomGnss.DrMeasurementReport.SV.READER> Sv => ctx.ReadList(0).Cast(Cereal.QcomGnss.DrMeasurementReport.SV.READER.create);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(10, 1);
                }

                public byte Reason
                {
                    get => this.ReadDataByte(0UL, (byte)0);
                    set => this.WriteData(0UL, value, (byte)0);
                }

                public byte SeqNum
                {
                    get => this.ReadDataByte(8UL, (byte)0);
                    set => this.WriteData(8UL, value, (byte)0);
                }

                public byte SeqMax
                {
                    get => this.ReadDataByte(16UL, (byte)0);
                    set => this.WriteData(16UL, value, (byte)0);
                }

                public ushort RfLoss
                {
                    get => this.ReadDataUShort(32UL, (ushort)0);
                    set => this.WriteData(32UL, value, (ushort)0);
                }

                public bool SystemRtcValid
                {
                    get => this.ReadDataBool(24UL, false);
                    set => this.WriteData(24UL, value, false);
                }

                public uint FCount
                {
                    get => this.ReadDataUInt(64UL, 0U);
                    set => this.WriteData(64UL, value, 0U);
                }

                public uint ClockResets
                {
                    get => this.ReadDataUInt(96UL, 0U);
                    set => this.WriteData(96UL, value, 0U);
                }

                public ulong SystemRtcTime
                {
                    get => this.ReadDataULong(128UL, 0UL);
                    set => this.WriteData(128UL, value, 0UL);
                }

                public byte GpsLeapSeconds
                {
                    get => this.ReadDataByte(48UL, (byte)0);
                    set => this.WriteData(48UL, value, (byte)0);
                }

                public byte GpsLeapSecondsUncertainty
                {
                    get => this.ReadDataByte(56UL, (byte)0);
                    set => this.WriteData(56UL, value, (byte)0);
                }

                public float GpsToGlonassTimeBiasMilliseconds
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public float GpsToGlonassTimeBiasMillisecondsUncertainty
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public ushort GpsWeek
                {
                    get => this.ReadDataUShort(256UL, (ushort)0);
                    set => this.WriteData(256UL, value, (ushort)0);
                }

                public uint GpsMilliseconds
                {
                    get => this.ReadDataUInt(288UL, 0U);
                    set => this.WriteData(288UL, value, 0U);
                }

                public uint GpsTimeBiasMs
                {
                    get => this.ReadDataUInt(320UL, 0U);
                    set => this.WriteData(320UL, value, 0U);
                }

                public uint GpsClockTimeUncertaintyMs
                {
                    get => this.ReadDataUInt(352UL, 0U);
                    set => this.WriteData(352UL, value, 0U);
                }

                public byte GpsClockSource
                {
                    get => this.ReadDataByte(272UL, (byte)0);
                    set => this.WriteData(272UL, value, (byte)0);
                }

                public byte GlonassClockSource
                {
                    get => this.ReadDataByte(280UL, (byte)0);
                    set => this.WriteData(280UL, value, (byte)0);
                }

                public byte GlonassYear
                {
                    get => this.ReadDataByte(384UL, (byte)0);
                    set => this.WriteData(384UL, value, (byte)0);
                }

                public ushort GlonassDay
                {
                    get => this.ReadDataUShort(400UL, (ushort)0);
                    set => this.WriteData(400UL, value, (ushort)0);
                }

                public uint GlonassMilliseconds
                {
                    get => this.ReadDataUInt(416UL, 0U);
                    set => this.WriteData(416UL, value, 0U);
                }

                public float GlonassTimeBias
                {
                    get => this.ReadDataFloat(448UL, 0F);
                    set => this.WriteData(448UL, value, 0F);
                }

                public float GlonassClockTimeUncertainty
                {
                    get => this.ReadDataFloat(480UL, 0F);
                    set => this.WriteData(480UL, value, 0F);
                }

                public float ClockFrequencyBias
                {
                    get => this.ReadDataFloat(512UL, 0F);
                    set => this.WriteData(512UL, value, 0F);
                }

                public float ClockFrequencyUncertainty
                {
                    get => this.ReadDataFloat(544UL, 0F);
                    set => this.WriteData(544UL, value, 0F);
                }

                public byte FrequencySource
                {
                    get => this.ReadDataByte(392UL, (byte)0);
                    set => this.WriteData(392UL, value, (byte)0);
                }

                public Cereal.QcomGnss.MeasurementSource Source
                {
                    get => (Cereal.QcomGnss.MeasurementSource)this.ReadDataUShort(576UL, (ushort)0);
                    set => this.WriteData(576UL, (ushort)value, (ushort)0);
                }

                public ListOfStructsSerializer<Cereal.QcomGnss.DrMeasurementReport.SV.WRITER> Sv
                {
                    get => BuildPointer<ListOfStructsSerializer<Cereal.QcomGnss.DrMeasurementReport.SV.WRITER>>(0);
                    set => Link(0, value);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf08b81df8cbf459cUL)]
            public class SV : ICapnpSerializable
            {
                public const UInt64 typeId = 0xf08b81df8cbf459cUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    SvId = reader.SvId;
                    GlonassFrequencyIndex = reader.GlonassFrequencyIndex;
                    ObservationState = reader.ObservationState;
                    Observations = reader.Observations;
                    GoodObservations = reader.GoodObservations;
                    FilterStages = reader.FilterStages;
                    PredetectInterval = reader.PredetectInterval;
                    CycleSlipCount = reader.CycleSlipCount;
                    Postdetections = reader.Postdetections;
                    MeasurementStatus = CapnpSerializable.Create<Cereal.QcomGnss.MeasurementStatus>(reader.MeasurementStatus);
                    CarrierNoise = reader.CarrierNoise;
                    RfLoss = reader.RfLoss;
                    Latency = reader.Latency;
                    FilteredMeasurementFraction = reader.FilteredMeasurementFraction;
                    FilteredMeasurementIntegral = reader.FilteredMeasurementIntegral;
                    FilteredTimeUncertainty = reader.FilteredTimeUncertainty;
                    FilteredSpeed = reader.FilteredSpeed;
                    FilteredSpeedUncertainty = reader.FilteredSpeedUncertainty;
                    UnfilteredMeasurementFraction = reader.UnfilteredMeasurementFraction;
                    UnfilteredMeasurementIntegral = reader.UnfilteredMeasurementIntegral;
                    UnfilteredTimeUncertainty = reader.UnfilteredTimeUncertainty;
                    UnfilteredSpeed = reader.UnfilteredSpeed;
                    UnfilteredSpeedUncertainty = reader.UnfilteredSpeedUncertainty;
                    MultipathEstimate = reader.MultipathEstimate;
                    Azimuth = reader.Azimuth;
                    Elevation = reader.Elevation;
                    DopplerAcceleration = reader.DopplerAcceleration;
                    FineSpeed = reader.FineSpeed;
                    FineSpeedUncertainty = reader.FineSpeedUncertainty;
                    CarrierPhase = reader.CarrierPhase;
                    FCount = reader.FCount;
                    ParityErrorCount = reader.ParityErrorCount;
                    GoodParity = reader.GoodParity;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.SvId = SvId;
                    writer.GlonassFrequencyIndex = GlonassFrequencyIndex;
                    writer.ObservationState = ObservationState;
                    writer.Observations = Observations;
                    writer.GoodObservations = GoodObservations;
                    writer.FilterStages = FilterStages;
                    writer.PredetectInterval = PredetectInterval;
                    writer.CycleSlipCount = CycleSlipCount;
                    writer.Postdetections = Postdetections;
                    MeasurementStatus?.serialize(writer.MeasurementStatus);
                    writer.CarrierNoise = CarrierNoise;
                    writer.RfLoss = RfLoss;
                    writer.Latency = Latency;
                    writer.FilteredMeasurementFraction = FilteredMeasurementFraction;
                    writer.FilteredMeasurementIntegral = FilteredMeasurementIntegral;
                    writer.FilteredTimeUncertainty = FilteredTimeUncertainty;
                    writer.FilteredSpeed = FilteredSpeed;
                    writer.FilteredSpeedUncertainty = FilteredSpeedUncertainty;
                    writer.UnfilteredMeasurementFraction = UnfilteredMeasurementFraction;
                    writer.UnfilteredMeasurementIntegral = UnfilteredMeasurementIntegral;
                    writer.UnfilteredTimeUncertainty = UnfilteredTimeUncertainty;
                    writer.UnfilteredSpeed = UnfilteredSpeed;
                    writer.UnfilteredSpeedUncertainty = UnfilteredSpeedUncertainty;
                    writer.MultipathEstimate = MultipathEstimate;
                    writer.Azimuth = Azimuth;
                    writer.Elevation = Elevation;
                    writer.DopplerAcceleration = DopplerAcceleration;
                    writer.FineSpeed = FineSpeed;
                    writer.FineSpeedUncertainty = FineSpeedUncertainty;
                    writer.CarrierPhase = CarrierPhase;
                    writer.FCount = FCount;
                    writer.ParityErrorCount = ParityErrorCount;
                    writer.GoodParity = GoodParity;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public byte SvId
                {
                    get;
                    set;
                }

                public sbyte GlonassFrequencyIndex
                {
                    get;
                    set;
                }

                public Cereal.QcomGnss.SVObservationState ObservationState
                {
                    get;
                    set;
                }

                public byte Observations
                {
                    get;
                    set;
                }

                public byte GoodObservations
                {
                    get;
                    set;
                }

                public byte FilterStages
                {
                    get;
                    set;
                }

                public byte PredetectInterval
                {
                    get;
                    set;
                }

                public byte CycleSlipCount
                {
                    get;
                    set;
                }

                public ushort Postdetections
                {
                    get;
                    set;
                }

                public Cereal.QcomGnss.MeasurementStatus MeasurementStatus
                {
                    get;
                    set;
                }

                public ushort CarrierNoise
                {
                    get;
                    set;
                }

                public ushort RfLoss
                {
                    get;
                    set;
                }

                public short Latency
                {
                    get;
                    set;
                }

                public float FilteredMeasurementFraction
                {
                    get;
                    set;
                }

                public uint FilteredMeasurementIntegral
                {
                    get;
                    set;
                }

                public float FilteredTimeUncertainty
                {
                    get;
                    set;
                }

                public float FilteredSpeed
                {
                    get;
                    set;
                }

                public float FilteredSpeedUncertainty
                {
                    get;
                    set;
                }

                public float UnfilteredMeasurementFraction
                {
                    get;
                    set;
                }

                public uint UnfilteredMeasurementIntegral
                {
                    get;
                    set;
                }

                public float UnfilteredTimeUncertainty
                {
                    get;
                    set;
                }

                public float UnfilteredSpeed
                {
                    get;
                    set;
                }

                public float UnfilteredSpeedUncertainty
                {
                    get;
                    set;
                }

                public uint MultipathEstimate
                {
                    get;
                    set;
                }

                public float Azimuth
                {
                    get;
                    set;
                }

                public float Elevation
                {
                    get;
                    set;
                }

                public float DopplerAcceleration
                {
                    get;
                    set;
                }

                public float FineSpeed
                {
                    get;
                    set;
                }

                public float FineSpeedUncertainty
                {
                    get;
                    set;
                }

                public double CarrierPhase
                {
                    get;
                    set;
                }

                public uint FCount
                {
                    get;
                    set;
                }

                public ushort ParityErrorCount
                {
                    get;
                    set;
                }

                public bool GoodParity
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
                    public byte SvId => ctx.ReadDataByte(0UL, (byte)0);
                    public sbyte GlonassFrequencyIndex => ctx.ReadDataSByte(8UL, (sbyte)0);
                    public Cereal.QcomGnss.SVObservationState ObservationState => (Cereal.QcomGnss.SVObservationState)ctx.ReadDataUShort(16UL, (ushort)0);
                    public byte Observations => ctx.ReadDataByte(32UL, (byte)0);
                    public byte GoodObservations => ctx.ReadDataByte(40UL, (byte)0);
                    public byte FilterStages => ctx.ReadDataByte(48UL, (byte)0);
                    public byte PredetectInterval => ctx.ReadDataByte(56UL, (byte)0);
                    public byte CycleSlipCount => ctx.ReadDataByte(64UL, (byte)0);
                    public ushort Postdetections => ctx.ReadDataUShort(80UL, (ushort)0);
                    public Cereal.QcomGnss.MeasurementStatus.READER MeasurementStatus => ctx.ReadStruct(0, Cereal.QcomGnss.MeasurementStatus.READER.create);
                    public ushort CarrierNoise => ctx.ReadDataUShort(96UL, (ushort)0);
                    public ushort RfLoss => ctx.ReadDataUShort(112UL, (ushort)0);
                    public short Latency => ctx.ReadDataShort(128UL, (short)0);
                    public float FilteredMeasurementFraction => ctx.ReadDataFloat(160UL, 0F);
                    public uint FilteredMeasurementIntegral => ctx.ReadDataUInt(192UL, 0U);
                    public float FilteredTimeUncertainty => ctx.ReadDataFloat(224UL, 0F);
                    public float FilteredSpeed => ctx.ReadDataFloat(256UL, 0F);
                    public float FilteredSpeedUncertainty => ctx.ReadDataFloat(288UL, 0F);
                    public float UnfilteredMeasurementFraction => ctx.ReadDataFloat(320UL, 0F);
                    public uint UnfilteredMeasurementIntegral => ctx.ReadDataUInt(352UL, 0U);
                    public float UnfilteredTimeUncertainty => ctx.ReadDataFloat(384UL, 0F);
                    public float UnfilteredSpeed => ctx.ReadDataFloat(416UL, 0F);
                    public float UnfilteredSpeedUncertainty => ctx.ReadDataFloat(448UL, 0F);
                    public uint MultipathEstimate => ctx.ReadDataUInt(480UL, 0U);
                    public float Azimuth => ctx.ReadDataFloat(512UL, 0F);
                    public float Elevation => ctx.ReadDataFloat(544UL, 0F);
                    public float DopplerAcceleration => ctx.ReadDataFloat(576UL, 0F);
                    public float FineSpeed => ctx.ReadDataFloat(608UL, 0F);
                    public float FineSpeedUncertainty => ctx.ReadDataFloat(640UL, 0F);
                    public double CarrierPhase => ctx.ReadDataDouble(704UL, 0);
                    public uint FCount => ctx.ReadDataUInt(672UL, 0U);
                    public ushort ParityErrorCount => ctx.ReadDataUShort(144UL, (ushort)0);
                    public bool GoodParity => ctx.ReadDataBool(72UL, false);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(12, 1);
                    }

                    public byte SvId
                    {
                        get => this.ReadDataByte(0UL, (byte)0);
                        set => this.WriteData(0UL, value, (byte)0);
                    }

                    public sbyte GlonassFrequencyIndex
                    {
                        get => this.ReadDataSByte(8UL, (sbyte)0);
                        set => this.WriteData(8UL, value, (sbyte)0);
                    }

                    public Cereal.QcomGnss.SVObservationState ObservationState
                    {
                        get => (Cereal.QcomGnss.SVObservationState)this.ReadDataUShort(16UL, (ushort)0);
                        set => this.WriteData(16UL, (ushort)value, (ushort)0);
                    }

                    public byte Observations
                    {
                        get => this.ReadDataByte(32UL, (byte)0);
                        set => this.WriteData(32UL, value, (byte)0);
                    }

                    public byte GoodObservations
                    {
                        get => this.ReadDataByte(40UL, (byte)0);
                        set => this.WriteData(40UL, value, (byte)0);
                    }

                    public byte FilterStages
                    {
                        get => this.ReadDataByte(48UL, (byte)0);
                        set => this.WriteData(48UL, value, (byte)0);
                    }

                    public byte PredetectInterval
                    {
                        get => this.ReadDataByte(56UL, (byte)0);
                        set => this.WriteData(56UL, value, (byte)0);
                    }

                    public byte CycleSlipCount
                    {
                        get => this.ReadDataByte(64UL, (byte)0);
                        set => this.WriteData(64UL, value, (byte)0);
                    }

                    public ushort Postdetections
                    {
                        get => this.ReadDataUShort(80UL, (ushort)0);
                        set => this.WriteData(80UL, value, (ushort)0);
                    }

                    public Cereal.QcomGnss.MeasurementStatus.WRITER MeasurementStatus
                    {
                        get => BuildPointer<Cereal.QcomGnss.MeasurementStatus.WRITER>(0);
                        set => Link(0, value);
                    }

                    public ushort CarrierNoise
                    {
                        get => this.ReadDataUShort(96UL, (ushort)0);
                        set => this.WriteData(96UL, value, (ushort)0);
                    }

                    public ushort RfLoss
                    {
                        get => this.ReadDataUShort(112UL, (ushort)0);
                        set => this.WriteData(112UL, value, (ushort)0);
                    }

                    public short Latency
                    {
                        get => this.ReadDataShort(128UL, (short)0);
                        set => this.WriteData(128UL, value, (short)0);
                    }

                    public float FilteredMeasurementFraction
                    {
                        get => this.ReadDataFloat(160UL, 0F);
                        set => this.WriteData(160UL, value, 0F);
                    }

                    public uint FilteredMeasurementIntegral
                    {
                        get => this.ReadDataUInt(192UL, 0U);
                        set => this.WriteData(192UL, value, 0U);
                    }

                    public float FilteredTimeUncertainty
                    {
                        get => this.ReadDataFloat(224UL, 0F);
                        set => this.WriteData(224UL, value, 0F);
                    }

                    public float FilteredSpeed
                    {
                        get => this.ReadDataFloat(256UL, 0F);
                        set => this.WriteData(256UL, value, 0F);
                    }

                    public float FilteredSpeedUncertainty
                    {
                        get => this.ReadDataFloat(288UL, 0F);
                        set => this.WriteData(288UL, value, 0F);
                    }

                    public float UnfilteredMeasurementFraction
                    {
                        get => this.ReadDataFloat(320UL, 0F);
                        set => this.WriteData(320UL, value, 0F);
                    }

                    public uint UnfilteredMeasurementIntegral
                    {
                        get => this.ReadDataUInt(352UL, 0U);
                        set => this.WriteData(352UL, value, 0U);
                    }

                    public float UnfilteredTimeUncertainty
                    {
                        get => this.ReadDataFloat(384UL, 0F);
                        set => this.WriteData(384UL, value, 0F);
                    }

                    public float UnfilteredSpeed
                    {
                        get => this.ReadDataFloat(416UL, 0F);
                        set => this.WriteData(416UL, value, 0F);
                    }

                    public float UnfilteredSpeedUncertainty
                    {
                        get => this.ReadDataFloat(448UL, 0F);
                        set => this.WriteData(448UL, value, 0F);
                    }

                    public uint MultipathEstimate
                    {
                        get => this.ReadDataUInt(480UL, 0U);
                        set => this.WriteData(480UL, value, 0U);
                    }

                    public float Azimuth
                    {
                        get => this.ReadDataFloat(512UL, 0F);
                        set => this.WriteData(512UL, value, 0F);
                    }

                    public float Elevation
                    {
                        get => this.ReadDataFloat(544UL, 0F);
                        set => this.WriteData(544UL, value, 0F);
                    }

                    public float DopplerAcceleration
                    {
                        get => this.ReadDataFloat(576UL, 0F);
                        set => this.WriteData(576UL, value, 0F);
                    }

                    public float FineSpeed
                    {
                        get => this.ReadDataFloat(608UL, 0F);
                        set => this.WriteData(608UL, value, 0F);
                    }

                    public float FineSpeedUncertainty
                    {
                        get => this.ReadDataFloat(640UL, 0F);
                        set => this.WriteData(640UL, value, 0F);
                    }

                    public double CarrierPhase
                    {
                        get => this.ReadDataDouble(704UL, 0);
                        set => this.WriteData(704UL, value, 0);
                    }

                    public uint FCount
                    {
                        get => this.ReadDataUInt(672UL, 0U);
                        set => this.WriteData(672UL, value, 0U);
                    }

                    public ushort ParityErrorCount
                    {
                        get => this.ReadDataUShort(144UL, (ushort)0);
                        set => this.WriteData(144UL, value, (ushort)0);
                    }

                    public bool GoodParity
                    {
                        get => this.ReadDataBool(72UL, false);
                        set => this.WriteData(72UL, value, false);
                    }
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb1fb80811a673270UL)]
        public class DrSvPolyReport : ICapnpSerializable
        {
            public const UInt64 typeId = 0xb1fb80811a673270UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                SvId = reader.SvId;
                FrequencyIndex = reader.FrequencyIndex;
                HasPosition = reader.HasPosition;
                HasIono = reader.HasIono;
                HasTropo = reader.HasTropo;
                HasElevation = reader.HasElevation;
                PolyFromXtra = reader.PolyFromXtra;
                HasSbasIono = reader.HasSbasIono;
                Iode = reader.Iode;
                T0 = reader.T0;
                Xyz0 = reader.Xyz0;
                XyzN = reader.XyzN;
                Other = reader.Other;
                PositionUncertainty = reader.PositionUncertainty;
                IonoDelay = reader.IonoDelay;
                IonoDot = reader.IonoDot;
                SbasIonoDelay = reader.SbasIonoDelay;
                SbasIonoDot = reader.SbasIonoDot;
                TropoDelay = reader.TropoDelay;
                Elevation = reader.Elevation;
                ElevationDot = reader.ElevationDot;
                ElevationUncertainty = reader.ElevationUncertainty;
                VelocityCoeff = reader.VelocityCoeff;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.SvId = SvId;
                writer.FrequencyIndex = FrequencyIndex;
                writer.HasPosition = HasPosition;
                writer.HasIono = HasIono;
                writer.HasTropo = HasTropo;
                writer.HasElevation = HasElevation;
                writer.PolyFromXtra = PolyFromXtra;
                writer.HasSbasIono = HasSbasIono;
                writer.Iode = Iode;
                writer.T0 = T0;
                writer.Xyz0.Init(Xyz0);
                writer.XyzN.Init(XyzN);
                writer.Other.Init(Other);
                writer.PositionUncertainty = PositionUncertainty;
                writer.IonoDelay = IonoDelay;
                writer.IonoDot = IonoDot;
                writer.SbasIonoDelay = SbasIonoDelay;
                writer.SbasIonoDot = SbasIonoDot;
                writer.TropoDelay = TropoDelay;
                writer.Elevation = Elevation;
                writer.ElevationDot = ElevationDot;
                writer.ElevationUncertainty = ElevationUncertainty;
                writer.VelocityCoeff.Init(VelocityCoeff);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public ushort SvId
            {
                get;
                set;
            }

            public sbyte FrequencyIndex
            {
                get;
                set;
            }

            public bool HasPosition
            {
                get;
                set;
            }

            public bool HasIono
            {
                get;
                set;
            }

            public bool HasTropo
            {
                get;
                set;
            }

            public bool HasElevation
            {
                get;
                set;
            }

            public bool PolyFromXtra
            {
                get;
                set;
            }

            public bool HasSbasIono
            {
                get;
                set;
            }

            public ushort Iode
            {
                get;
                set;
            }

            public double T0
            {
                get;
                set;
            }

            public IReadOnlyList<double> Xyz0
            {
                get;
                set;
            }

            public IReadOnlyList<double> XyzN
            {
                get;
                set;
            }

            public IReadOnlyList<float> Other
            {
                get;
                set;
            }

            public float PositionUncertainty
            {
                get;
                set;
            }

            public float IonoDelay
            {
                get;
                set;
            }

            public float IonoDot
            {
                get;
                set;
            }

            public float SbasIonoDelay
            {
                get;
                set;
            }

            public float SbasIonoDot
            {
                get;
                set;
            }

            public float TropoDelay
            {
                get;
                set;
            }

            public float Elevation
            {
                get;
                set;
            }

            public float ElevationDot
            {
                get;
                set;
            }

            public float ElevationUncertainty
            {
                get;
                set;
            }

            public IReadOnlyList<double> VelocityCoeff
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
                public ushort SvId => ctx.ReadDataUShort(0UL, (ushort)0);
                public sbyte FrequencyIndex => ctx.ReadDataSByte(16UL, (sbyte)0);
                public bool HasPosition => ctx.ReadDataBool(24UL, false);
                public bool HasIono => ctx.ReadDataBool(25UL, false);
                public bool HasTropo => ctx.ReadDataBool(26UL, false);
                public bool HasElevation => ctx.ReadDataBool(27UL, false);
                public bool PolyFromXtra => ctx.ReadDataBool(28UL, false);
                public bool HasSbasIono => ctx.ReadDataBool(29UL, false);
                public ushort Iode => ctx.ReadDataUShort(32UL, (ushort)0);
                public double T0 => ctx.ReadDataDouble(64UL, 0);
                public IReadOnlyList<double> Xyz0 => ctx.ReadList(0).CastDouble();
                public IReadOnlyList<double> XyzN => ctx.ReadList(1).CastDouble();
                public IReadOnlyList<float> Other => ctx.ReadList(2).CastFloat();
                public float PositionUncertainty => ctx.ReadDataFloat(128UL, 0F);
                public float IonoDelay => ctx.ReadDataFloat(160UL, 0F);
                public float IonoDot => ctx.ReadDataFloat(192UL, 0F);
                public float SbasIonoDelay => ctx.ReadDataFloat(224UL, 0F);
                public float SbasIonoDot => ctx.ReadDataFloat(256UL, 0F);
                public float TropoDelay => ctx.ReadDataFloat(288UL, 0F);
                public float Elevation => ctx.ReadDataFloat(320UL, 0F);
                public float ElevationDot => ctx.ReadDataFloat(352UL, 0F);
                public float ElevationUncertainty => ctx.ReadDataFloat(384UL, 0F);
                public IReadOnlyList<double> VelocityCoeff => ctx.ReadList(3).CastDouble();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(7, 4);
                }

                public ushort SvId
                {
                    get => this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, value, (ushort)0);
                }

                public sbyte FrequencyIndex
                {
                    get => this.ReadDataSByte(16UL, (sbyte)0);
                    set => this.WriteData(16UL, value, (sbyte)0);
                }

                public bool HasPosition
                {
                    get => this.ReadDataBool(24UL, false);
                    set => this.WriteData(24UL, value, false);
                }

                public bool HasIono
                {
                    get => this.ReadDataBool(25UL, false);
                    set => this.WriteData(25UL, value, false);
                }

                public bool HasTropo
                {
                    get => this.ReadDataBool(26UL, false);
                    set => this.WriteData(26UL, value, false);
                }

                public bool HasElevation
                {
                    get => this.ReadDataBool(27UL, false);
                    set => this.WriteData(27UL, value, false);
                }

                public bool PolyFromXtra
                {
                    get => this.ReadDataBool(28UL, false);
                    set => this.WriteData(28UL, value, false);
                }

                public bool HasSbasIono
                {
                    get => this.ReadDataBool(29UL, false);
                    set => this.WriteData(29UL, value, false);
                }

                public ushort Iode
                {
                    get => this.ReadDataUShort(32UL, (ushort)0);
                    set => this.WriteData(32UL, value, (ushort)0);
                }

                public double T0
                {
                    get => this.ReadDataDouble(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public ListOfPrimitivesSerializer<double> Xyz0
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<double> XyzN
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> Other
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public float PositionUncertainty
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float IonoDelay
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float IonoDot
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public float SbasIonoDelay
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public float SbasIonoDot
                {
                    get => this.ReadDataFloat(256UL, 0F);
                    set => this.WriteData(256UL, value, 0F);
                }

                public float TropoDelay
                {
                    get => this.ReadDataFloat(288UL, 0F);
                    set => this.WriteData(288UL, value, 0F);
                }

                public float Elevation
                {
                    get => this.ReadDataFloat(320UL, 0F);
                    set => this.WriteData(320UL, value, 0F);
                }

                public float ElevationDot
                {
                    get => this.ReadDataFloat(352UL, 0F);
                    set => this.WriteData(352UL, value, 0F);
                }

                public float ElevationUncertainty
                {
                    get => this.ReadDataFloat(384UL, 0F);
                    set => this.WriteData(384UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<double> VelocityCoeff
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(3);
                    set => Link(3, value);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe3d6685d4e9d8f7aUL)]
    public class LidarPts : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe3d6685d4e9d8f7aUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            R = reader.R;
            Theta = reader.Theta;
            Reflect = reader.Reflect;
            Idx = reader.Idx;
            Pkt = reader.Pkt;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.R.Init(R);
            writer.Theta.Init(Theta);
            writer.Reflect.Init(Reflect);
            writer.Idx = Idx;
            writer.Pkt.Init(Pkt);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<ushort> R
        {
            get;
            set;
        }

        public IReadOnlyList<ushort> Theta
        {
            get;
            set;
        }

        public IReadOnlyList<byte> Reflect
        {
            get;
            set;
        }

        public ulong Idx
        {
            get;
            set;
        }

        public IReadOnlyList<byte> Pkt
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
            public IReadOnlyList<ushort> R => ctx.ReadList(0).CastUShort();
            public IReadOnlyList<ushort> Theta => ctx.ReadList(1).CastUShort();
            public IReadOnlyList<byte> Reflect => ctx.ReadList(2).CastByte();
            public ulong Idx => ctx.ReadDataULong(0UL, 0UL);
            public IReadOnlyList<byte> Pkt => ctx.ReadList(3).CastByte();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 4);
            }

            public ListOfPrimitivesSerializer<ushort> R
            {
                get => BuildPointer<ListOfPrimitivesSerializer<ushort>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<ushort> Theta
            {
                get => BuildPointer<ListOfPrimitivesSerializer<ushort>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<byte> Reflect
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(2);
                set => Link(2, value);
            }

            public ulong Idx
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<byte> Pkt
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(3);
                set => Link(3, value);
            }
        }
    }
}