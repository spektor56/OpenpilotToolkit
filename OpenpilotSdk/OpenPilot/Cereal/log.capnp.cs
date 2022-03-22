using Capnp;
using Capnp.Rpc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cereal
{
    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf8b13ce2183eb696UL)]
    public class Map<TKey, TValue> : ICapnpSerializable where TKey : class where TValue : class
    {
        public const UInt64 typeId = 0xf8b13ce2183eb696UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Entries = reader.Entries?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.Map<TKey, TValue>.Entry>(_));
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Entries.Init(Entries, (_s1, _v1) => _v1?.serialize(_s1));
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<Cereal.Map<TKey, TValue>.Entry> Entries
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
            public IReadOnlyList<Cereal.Map<TKey, TValue>.Entry.READER> Entries => ctx.ReadList(0).Cast(Cereal.Map<TKey, TValue>.Entry.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public ListOfStructsSerializer<Cereal.Map<TKey, TValue>.Entry.WRITER> Entries
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.Map<TKey, TValue>.Entry.WRITER>>(0);
                set => Link(0, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa5dfdd084a6eea0eUL)]
        public class Entry : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa5dfdd084a6eea0eUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Key = CapnpSerializable.Create<TKey>(reader.Key);
                Value = CapnpSerializable.Create<TValue>(reader.Value);
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Key.SetObject(Key);
                writer.Value.SetObject(Value);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public TKey Key
            {
                get;
                set;
            }

            public TValue Value
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
                public DeserializerState Key => ctx.StructReadPointer(0);
                public DeserializerState Value => ctx.StructReadPointer(1);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 2);
                }

                public DynamicSerializerState Key
                {
                    get => BuildPointer<DynamicSerializerState>(0);
                    set => Link(0, value);
                }

                public DynamicSerializerState Value
                {
                    get => BuildPointer<DynamicSerializerState>(1);
                    set => Link(1, value);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe71008caeb3fb65cUL)]
    public class InitData : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe71008caeb3fb65cUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            KernelArgs = reader.KernelArgs;
            GctxDEPRECATED = reader.GctxDEPRECATED;
            DongleId = reader.DongleId;
            TheDeviceType = reader.TheDeviceType;
            Version = reader.Version;
            TheAndroidBuildInfo = CapnpSerializable.Create<Cereal.InitData.AndroidBuildInfo>(reader.TheAndroidBuildInfo);
            AndroidSensorsDEPRECATED = reader.AndroidSensorsDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.InitData.AndroidSensor>(_));
            ChffrAndroidExtraDEPRECATED = CapnpSerializable.Create<Cereal.InitData.ChffrAndroidExtra>(reader.ChffrAndroidExtraDEPRECATED);
            ThePandaInfo = CapnpSerializable.Create<Cereal.InitData.PandaInfo>(reader.ThePandaInfo);
            Dirty = reader.Dirty;
            GitCommit = reader.GitCommit;
            GitBranch = reader.GitBranch;
            Passive = reader.Passive;
            GitRemote = reader.GitRemote;
            IosBuildInfoDEPRECATED = CapnpSerializable.Create<Cereal.InitData.IosBuildInfo>(reader.IosBuildInfoDEPRECATED);
            KernelVersion = reader.KernelVersion;
            AndroidProperties = CapnpSerializable.Create<Cereal.Map<string, string>>(reader.AndroidProperties);
            Params = CapnpSerializable.Create<Cereal.Map<string, IReadOnlyList<byte>>>(reader.Params);
            OsVersion = reader.OsVersion;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.KernelArgs.Init(KernelArgs);
            writer.GctxDEPRECATED = GctxDEPRECATED;
            writer.DongleId = DongleId;
            writer.TheDeviceType = TheDeviceType;
            writer.Version = Version;
            TheAndroidBuildInfo?.serialize(writer.TheAndroidBuildInfo);
            writer.AndroidSensorsDEPRECATED.Init(AndroidSensorsDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
            ChffrAndroidExtraDEPRECATED?.serialize(writer.ChffrAndroidExtraDEPRECATED);
            ThePandaInfo?.serialize(writer.ThePandaInfo);
            writer.Dirty = Dirty;
            writer.GitCommit = GitCommit;
            writer.GitBranch = GitBranch;
            writer.Passive = Passive;
            writer.GitRemote = GitRemote;
            IosBuildInfoDEPRECATED?.serialize(writer.IosBuildInfoDEPRECATED);
            writer.KernelVersion = KernelVersion;
            AndroidProperties?.serialize(writer.AndroidProperties);
            Params?.serialize(writer.Params);
            writer.OsVersion = OsVersion;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<string> KernelArgs
        {
            get;
            set;
        }

        public string GctxDEPRECATED
        {
            get;
            set;
        }

        public string DongleId
        {
            get;
            set;
        }

        public Cereal.InitData.DeviceType TheDeviceType
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public Cereal.InitData.AndroidBuildInfo TheAndroidBuildInfo
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.InitData.AndroidSensor> AndroidSensorsDEPRECATED
        {
            get;
            set;
        }

        public Cereal.InitData.ChffrAndroidExtra ChffrAndroidExtraDEPRECATED
        {
            get;
            set;
        }

        public Cereal.InitData.PandaInfo ThePandaInfo
        {
            get;
            set;
        }

        public bool Dirty
        {
            get;
            set;
        }

        public string GitCommit
        {
            get;
            set;
        }

        public string GitBranch
        {
            get;
            set;
        }

        public bool Passive
        {
            get;
            set;
        }

        public string GitRemote
        {
            get;
            set;
        }

        public Cereal.InitData.IosBuildInfo IosBuildInfoDEPRECATED
        {
            get;
            set;
        }

        public string KernelVersion
        {
            get;
            set;
        }

        public Cereal.Map<string, string> AndroidProperties
        {
            get;
            set;
        }

        public Cereal.Map<string, IReadOnlyList<byte>> Params
        {
            get;
            set;
        }

        public string OsVersion
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
            public IReadOnlyList<string> KernelArgs => ctx.ReadList(0).CastText2();
            public string GctxDEPRECATED => ctx.ReadText(1, null);
            public string DongleId => ctx.ReadText(2, null);
            public Cereal.InitData.DeviceType TheDeviceType => (Cereal.InitData.DeviceType)ctx.ReadDataUShort(0UL, (ushort)0);
            public string Version => ctx.ReadText(3, null);
            public Cereal.InitData.AndroidBuildInfo.READER TheAndroidBuildInfo => ctx.ReadStruct(4, Cereal.InitData.AndroidBuildInfo.READER.create);
            public IReadOnlyList<Cereal.InitData.AndroidSensor.READER> AndroidSensorsDEPRECATED => ctx.ReadList(5).Cast(Cereal.InitData.AndroidSensor.READER.create);
            public Cereal.InitData.ChffrAndroidExtra.READER ChffrAndroidExtraDEPRECATED => ctx.ReadStruct(6, Cereal.InitData.ChffrAndroidExtra.READER.create);
            public Cereal.InitData.PandaInfo.READER ThePandaInfo => ctx.ReadStruct(7, Cereal.InitData.PandaInfo.READER.create);
            public bool Dirty => ctx.ReadDataBool(16UL, false);
            public string GitCommit => ctx.ReadText(8, null);
            public string GitBranch => ctx.ReadText(9, null);
            public bool Passive => ctx.ReadDataBool(17UL, false);
            public string GitRemote => ctx.ReadText(10, null);
            public Cereal.InitData.IosBuildInfo.READER IosBuildInfoDEPRECATED => ctx.ReadStruct(11, Cereal.InitData.IosBuildInfo.READER.create);
            public string KernelVersion => ctx.ReadText(12, null);
            public Cereal.Map<string, string>.READER AndroidProperties => ctx.ReadStruct(13, Cereal.Map<string, string>.READER.create);
            public Cereal.Map<string, IReadOnlyList<byte>>.READER Params => ctx.ReadStruct(14, Cereal.Map<string, IReadOnlyList<byte>>.READER.create);
            public string OsVersion => ctx.ReadText(15, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 16);
            }

            public ListOfTextSerializer KernelArgs
            {
                get => BuildPointer<ListOfTextSerializer>(0);
                set => Link(0, value);
            }

            public string GctxDEPRECATED
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string DongleId
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public Cereal.InitData.DeviceType TheDeviceType
            {
                get => (Cereal.InitData.DeviceType)this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, (ushort)value, (ushort)0);
            }

            public string Version
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public Cereal.InitData.AndroidBuildInfo.WRITER TheAndroidBuildInfo
            {
                get => BuildPointer<Cereal.InitData.AndroidBuildInfo.WRITER>(4);
                set => Link(4, value);
            }

            public ListOfStructsSerializer<Cereal.InitData.AndroidSensor.WRITER> AndroidSensorsDEPRECATED
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.InitData.AndroidSensor.WRITER>>(5);
                set => Link(5, value);
            }

            public Cereal.InitData.ChffrAndroidExtra.WRITER ChffrAndroidExtraDEPRECATED
            {
                get => BuildPointer<Cereal.InitData.ChffrAndroidExtra.WRITER>(6);
                set => Link(6, value);
            }

            public Cereal.InitData.PandaInfo.WRITER ThePandaInfo
            {
                get => BuildPointer<Cereal.InitData.PandaInfo.WRITER>(7);
                set => Link(7, value);
            }

            public bool Dirty
            {
                get => this.ReadDataBool(16UL, false);
                set => this.WriteData(16UL, value, false);
            }

            public string GitCommit
            {
                get => this.ReadText(8, null);
                set => this.WriteText(8, value, null);
            }

            public string GitBranch
            {
                get => this.ReadText(9, null);
                set => this.WriteText(9, value, null);
            }

            public bool Passive
            {
                get => this.ReadDataBool(17UL, false);
                set => this.WriteData(17UL, value, false);
            }

            public string GitRemote
            {
                get => this.ReadText(10, null);
                set => this.WriteText(10, value, null);
            }

            public Cereal.InitData.IosBuildInfo.WRITER IosBuildInfoDEPRECATED
            {
                get => BuildPointer<Cereal.InitData.IosBuildInfo.WRITER>(11);
                set => Link(11, value);
            }

            public string KernelVersion
            {
                get => this.ReadText(12, null);
                set => this.WriteText(12, value, null);
            }

            public Cereal.Map<string, string>.WRITER AndroidProperties
            {
                get => BuildPointer<Cereal.Map<string, string>.WRITER>(13);
                set => Link(13, value);
            }

            public Cereal.Map<string, IReadOnlyList<byte>>.WRITER Params
            {
                get => BuildPointer<Cereal.Map<string, IReadOnlyList<byte>>.WRITER>(14);
                set => Link(14, value);
            }

            public string OsVersion
            {
                get => this.ReadText(15, null);
                set => this.WriteText(15, value, null);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9d5d7238eba86608UL)]
        public enum DeviceType : ushort
        {
            unknown,
            neo,
            chffrAndroid,
            chffrIos,
            tici,
            pc
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe673e8725cdff0adUL)]
        public class PandaInfo : ICapnpSerializable
        {
            public const UInt64 typeId = 0xe673e8725cdff0adUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                HasPanda = reader.HasPanda;
                DongleId = reader.DongleId;
                StVersion = reader.StVersion;
                EspVersion = reader.EspVersion;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.HasPanda = HasPanda;
                writer.DongleId = DongleId;
                writer.StVersion = StVersion;
                writer.EspVersion = EspVersion;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool HasPanda
            {
                get;
                set;
            }

            public string DongleId
            {
                get;
                set;
            }

            public string StVersion
            {
                get;
                set;
            }

            public string EspVersion
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
                public bool HasPanda => ctx.ReadDataBool(0UL, false);
                public string DongleId => ctx.ReadText(0, null);
                public string StVersion => ctx.ReadText(1, null);
                public string EspVersion => ctx.ReadText(2, null);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 3);
                }

                public bool HasPanda
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public string DongleId
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public string StVersion
                {
                    get => this.ReadText(1, null);
                    set => this.WriteText(1, value, null);
                }

                public string EspVersion
                {
                    get => this.ReadText(2, null);
                    set => this.WriteText(2, value, null);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfe2919d5c21f426cUL)]
        public class AndroidBuildInfo : ICapnpSerializable
        {
            public const UInt64 typeId = 0xfe2919d5c21f426cUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Board = reader.Board;
                Bootloader = reader.Bootloader;
                Brand = reader.Brand;
                Device = reader.Device;
                Display = reader.Display;
                Fingerprint = reader.Fingerprint;
                Hardware = reader.Hardware;
                Host = reader.Host;
                Id = reader.Id;
                Manufacturer = reader.Manufacturer;
                Model = reader.Model;
                Product = reader.Product;
                RadioVersion = reader.RadioVersion;
                Serial = reader.Serial;
                SupportedAbis = reader.SupportedAbis;
                Tags = reader.Tags;
                Time = reader.Time;
                Type = reader.Type;
                User = reader.User;
                VersionCodename = reader.VersionCodename;
                VersionRelease = reader.VersionRelease;
                VersionSdk = reader.VersionSdk;
                VersionSecurityPatch = reader.VersionSecurityPatch;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Board = Board;
                writer.Bootloader = Bootloader;
                writer.Brand = Brand;
                writer.Device = Device;
                writer.Display = Display;
                writer.Fingerprint = Fingerprint;
                writer.Hardware = Hardware;
                writer.Host = Host;
                writer.Id = Id;
                writer.Manufacturer = Manufacturer;
                writer.Model = Model;
                writer.Product = Product;
                writer.RadioVersion = RadioVersion;
                writer.Serial = Serial;
                writer.SupportedAbis.Init(SupportedAbis);
                writer.Tags = Tags;
                writer.Time = Time;
                writer.Type = Type;
                writer.User = User;
                writer.VersionCodename = VersionCodename;
                writer.VersionRelease = VersionRelease;
                writer.VersionSdk = VersionSdk;
                writer.VersionSecurityPatch = VersionSecurityPatch;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public string Board
            {
                get;
                set;
            }

            public string Bootloader
            {
                get;
                set;
            }

            public string Brand
            {
                get;
                set;
            }

            public string Device
            {
                get;
                set;
            }

            public string Display
            {
                get;
                set;
            }

            public string Fingerprint
            {
                get;
                set;
            }

            public string Hardware
            {
                get;
                set;
            }

            public string Host
            {
                get;
                set;
            }

            public string Id
            {
                get;
                set;
            }

            public string Manufacturer
            {
                get;
                set;
            }

            public string Model
            {
                get;
                set;
            }

            public string Product
            {
                get;
                set;
            }

            public string RadioVersion
            {
                get;
                set;
            }

            public string Serial
            {
                get;
                set;
            }

            public IReadOnlyList<string> SupportedAbis
            {
                get;
                set;
            }

            public string Tags
            {
                get;
                set;
            }

            public long Time
            {
                get;
                set;
            }

            public string Type
            {
                get;
                set;
            }

            public string User
            {
                get;
                set;
            }

            public string VersionCodename
            {
                get;
                set;
            }

            public string VersionRelease
            {
                get;
                set;
            }

            public int VersionSdk
            {
                get;
                set;
            }

            public string VersionSecurityPatch
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
                public string Board => ctx.ReadText(0, null);
                public string Bootloader => ctx.ReadText(1, null);
                public string Brand => ctx.ReadText(2, null);
                public string Device => ctx.ReadText(3, null);
                public string Display => ctx.ReadText(4, null);
                public string Fingerprint => ctx.ReadText(5, null);
                public string Hardware => ctx.ReadText(6, null);
                public string Host => ctx.ReadText(7, null);
                public string Id => ctx.ReadText(8, null);
                public string Manufacturer => ctx.ReadText(9, null);
                public string Model => ctx.ReadText(10, null);
                public string Product => ctx.ReadText(11, null);
                public string RadioVersion => ctx.ReadText(12, null);
                public string Serial => ctx.ReadText(13, null);
                public IReadOnlyList<string> SupportedAbis => ctx.ReadList(14).CastText2();
                public string Tags => ctx.ReadText(15, null);
                public long Time => ctx.ReadDataLong(0UL, 0L);
                public string Type => ctx.ReadText(16, null);
                public string User => ctx.ReadText(17, null);
                public string VersionCodename => ctx.ReadText(18, null);
                public string VersionRelease => ctx.ReadText(19, null);
                public int VersionSdk => ctx.ReadDataInt(64UL, 0);
                public string VersionSecurityPatch => ctx.ReadText(20, null);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 21);
                }

                public string Board
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public string Bootloader
                {
                    get => this.ReadText(1, null);
                    set => this.WriteText(1, value, null);
                }

                public string Brand
                {
                    get => this.ReadText(2, null);
                    set => this.WriteText(2, value, null);
                }

                public string Device
                {
                    get => this.ReadText(3, null);
                    set => this.WriteText(3, value, null);
                }

                public string Display
                {
                    get => this.ReadText(4, null);
                    set => this.WriteText(4, value, null);
                }

                public string Fingerprint
                {
                    get => this.ReadText(5, null);
                    set => this.WriteText(5, value, null);
                }

                public string Hardware
                {
                    get => this.ReadText(6, null);
                    set => this.WriteText(6, value, null);
                }

                public string Host
                {
                    get => this.ReadText(7, null);
                    set => this.WriteText(7, value, null);
                }

                public string Id
                {
                    get => this.ReadText(8, null);
                    set => this.WriteText(8, value, null);
                }

                public string Manufacturer
                {
                    get => this.ReadText(9, null);
                    set => this.WriteText(9, value, null);
                }

                public string Model
                {
                    get => this.ReadText(10, null);
                    set => this.WriteText(10, value, null);
                }

                public string Product
                {
                    get => this.ReadText(11, null);
                    set => this.WriteText(11, value, null);
                }

                public string RadioVersion
                {
                    get => this.ReadText(12, null);
                    set => this.WriteText(12, value, null);
                }

                public string Serial
                {
                    get => this.ReadText(13, null);
                    set => this.WriteText(13, value, null);
                }

                public ListOfTextSerializer SupportedAbis
                {
                    get => BuildPointer<ListOfTextSerializer>(14);
                    set => Link(14, value);
                }

                public string Tags
                {
                    get => this.ReadText(15, null);
                    set => this.WriteText(15, value, null);
                }

                public long Time
                {
                    get => this.ReadDataLong(0UL, 0L);
                    set => this.WriteData(0UL, value, 0L);
                }

                public string Type
                {
                    get => this.ReadText(16, null);
                    set => this.WriteText(16, value, null);
                }

                public string User
                {
                    get => this.ReadText(17, null);
                    set => this.WriteText(17, value, null);
                }

                public string VersionCodename
                {
                    get => this.ReadText(18, null);
                    set => this.WriteText(18, value, null);
                }

                public string VersionRelease
                {
                    get => this.ReadText(19, null);
                    set => this.WriteText(19, value, null);
                }

                public int VersionSdk
                {
                    get => this.ReadDataInt(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public string VersionSecurityPatch
                {
                    get => this.ReadText(20, null);
                    set => this.WriteText(20, value, null);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9b513b93a887dbcdUL)]
        public class AndroidSensor : ICapnpSerializable
        {
            public const UInt64 typeId = 0x9b513b93a887dbcdUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Id = reader.Id;
                Name = reader.Name;
                Vendor = reader.Vendor;
                Version = reader.Version;
                Handle = reader.Handle;
                Type = reader.Type;
                MaxRange = reader.MaxRange;
                Resolution = reader.Resolution;
                Power = reader.Power;
                MinDelay = reader.MinDelay;
                FifoReservedEventCount = reader.FifoReservedEventCount;
                FifoMaxEventCount = reader.FifoMaxEventCount;
                StringType = reader.StringType;
                MaxDelay = reader.MaxDelay;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Id = Id;
                writer.Name = Name;
                writer.Vendor = Vendor;
                writer.Version = Version;
                writer.Handle = Handle;
                writer.Type = Type;
                writer.MaxRange = MaxRange;
                writer.Resolution = Resolution;
                writer.Power = Power;
                writer.MinDelay = MinDelay;
                writer.FifoReservedEventCount = FifoReservedEventCount;
                writer.FifoMaxEventCount = FifoMaxEventCount;
                writer.StringType = StringType;
                writer.MaxDelay = MaxDelay;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public int Id
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public string Vendor
            {
                get;
                set;
            }

            public int Version
            {
                get;
                set;
            }

            public int Handle
            {
                get;
                set;
            }

            public int Type
            {
                get;
                set;
            }

            public float MaxRange
            {
                get;
                set;
            }

            public float Resolution
            {
                get;
                set;
            }

            public float Power
            {
                get;
                set;
            }

            public int MinDelay
            {
                get;
                set;
            }

            public uint FifoReservedEventCount
            {
                get;
                set;
            }

            public uint FifoMaxEventCount
            {
                get;
                set;
            }

            public string StringType
            {
                get;
                set;
            }

            public int MaxDelay
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
                public int Id => ctx.ReadDataInt(0UL, 0);
                public string Name => ctx.ReadText(0, null);
                public string Vendor => ctx.ReadText(1, null);
                public int Version => ctx.ReadDataInt(32UL, 0);
                public int Handle => ctx.ReadDataInt(64UL, 0);
                public int Type => ctx.ReadDataInt(96UL, 0);
                public float MaxRange => ctx.ReadDataFloat(128UL, 0F);
                public float Resolution => ctx.ReadDataFloat(160UL, 0F);
                public float Power => ctx.ReadDataFloat(192UL, 0F);
                public int MinDelay => ctx.ReadDataInt(224UL, 0);
                public uint FifoReservedEventCount => ctx.ReadDataUInt(256UL, 0U);
                public uint FifoMaxEventCount => ctx.ReadDataUInt(288UL, 0U);
                public string StringType => ctx.ReadText(2, null);
                public int MaxDelay => ctx.ReadDataInt(320UL, 0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(6, 3);
                }

                public int Id
                {
                    get => this.ReadDataInt(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public string Name
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public string Vendor
                {
                    get => this.ReadText(1, null);
                    set => this.WriteText(1, value, null);
                }

                public int Version
                {
                    get => this.ReadDataInt(32UL, 0);
                    set => this.WriteData(32UL, value, 0);
                }

                public int Handle
                {
                    get => this.ReadDataInt(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public int Type
                {
                    get => this.ReadDataInt(96UL, 0);
                    set => this.WriteData(96UL, value, 0);
                }

                public float MaxRange
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float Resolution
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float Power
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public int MinDelay
                {
                    get => this.ReadDataInt(224UL, 0);
                    set => this.WriteData(224UL, value, 0);
                }

                public uint FifoReservedEventCount
                {
                    get => this.ReadDataUInt(256UL, 0U);
                    set => this.WriteData(256UL, value, 0U);
                }

                public uint FifoMaxEventCount
                {
                    get => this.ReadDataUInt(288UL, 0U);
                    set => this.WriteData(288UL, value, 0U);
                }

                public string StringType
                {
                    get => this.ReadText(2, null);
                    set => this.WriteText(2, value, null);
                }

                public int MaxDelay
                {
                    get => this.ReadDataInt(320UL, 0);
                    set => this.WriteData(320UL, value, 0);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9cfb5d53a4f615a5UL)]
        public class ChffrAndroidExtra : ICapnpSerializable
        {
            public const UInt64 typeId = 0x9cfb5d53a4f615a5UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                AllCameraCharacteristics = CapnpSerializable.Create<Cereal.Map<string, string>>(reader.AllCameraCharacteristics);
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                AllCameraCharacteristics?.serialize(writer.AllCameraCharacteristics);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public Cereal.Map<string, string> AllCameraCharacteristics
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
                public Cereal.Map<string, string>.READER AllCameraCharacteristics => ctx.ReadStruct(0, Cereal.Map<string, string>.READER.create);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 1);
                }

                public Cereal.Map<string, string>.WRITER AllCameraCharacteristics
                {
                    get => BuildPointer<Cereal.Map<string, string>.WRITER>(0);
                    set => Link(0, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd97e3b28239f5580UL)]
        public class IosBuildInfo : ICapnpSerializable
        {
            public const UInt64 typeId = 0xd97e3b28239f5580UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                AppVersion = reader.AppVersion;
                AppBuild = reader.AppBuild;
                OsVersion = reader.OsVersion;
                DeviceModel = reader.DeviceModel;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.AppVersion = AppVersion;
                writer.AppBuild = AppBuild;
                writer.OsVersion = OsVersion;
                writer.DeviceModel = DeviceModel;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public string AppVersion
            {
                get;
                set;
            }

            public uint AppBuild
            {
                get;
                set;
            }

            public string OsVersion
            {
                get;
                set;
            }

            public string DeviceModel
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
                public string AppVersion => ctx.ReadText(0, null);
                public uint AppBuild => ctx.ReadDataUInt(0UL, 0U);
                public string OsVersion => ctx.ReadText(1, null);
                public string DeviceModel => ctx.ReadText(2, null);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 3);
                }

                public string AppVersion
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public uint AppBuild
                {
                    get => this.ReadDataUInt(0UL, 0U);
                    set => this.WriteData(0UL, value, 0U);
                }

                public string OsVersion
                {
                    get => this.ReadText(1, null);
                    set => this.WriteText(1, value, null);
                }

                public string DeviceModel
                {
                    get => this.ReadText(2, null);
                    set => this.WriteText(2, value, null);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xea0245f695ae0a33UL)]
    public class FrameData : ICapnpSerializable
    {
        public const UInt64 typeId = 0xea0245f695ae0a33UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            FrameId = reader.FrameId;
            EncodeId = reader.EncodeId;
            TimestampEof = reader.TimestampEof;
            FrameLength = reader.FrameLength;
            IntegLines = reader.IntegLines;
            GlobalGainDEPRECATED = reader.GlobalGainDEPRECATED;
            Image = reader.Image;
            TheFrameType = reader.TheFrameType;
            TimestampSof = reader.TimestampSof;
            TheAndroidCaptureResult = CapnpSerializable.Create<Cereal.FrameData.AndroidCaptureResult>(reader.TheAndroidCaptureResult);
            Transform = reader.Transform;
            LensPos = reader.LensPos;
            LensSag = reader.LensSag;
            LensErr = reader.LensErr;
            LensTruePos = reader.LensTruePos;
            Gain = reader.Gain;
            FocusVal = reader.FocusVal;
            FocusConf = reader.FocusConf;
            SharpnessScore = reader.SharpnessScore;
            RecoverState = reader.RecoverState;
            HighConversionGain = reader.HighConversionGain;
            MeasuredGreyFraction = reader.MeasuredGreyFraction;
            TargetGreyFraction = reader.TargetGreyFraction;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.FrameId = FrameId;
            writer.EncodeId = EncodeId;
            writer.TimestampEof = TimestampEof;
            writer.FrameLength = FrameLength;
            writer.IntegLines = IntegLines;
            writer.GlobalGainDEPRECATED = GlobalGainDEPRECATED;
            writer.Image.Init(Image);
            writer.TheFrameType = TheFrameType;
            writer.TimestampSof = TimestampSof;
            TheAndroidCaptureResult?.serialize(writer.TheAndroidCaptureResult);
            writer.Transform.Init(Transform);
            writer.LensPos = LensPos;
            writer.LensSag = LensSag;
            writer.LensErr = LensErr;
            writer.LensTruePos = LensTruePos;
            writer.Gain = Gain;
            writer.FocusVal.Init(FocusVal);
            writer.FocusConf.Init(FocusConf);
            writer.SharpnessScore.Init(SharpnessScore);
            writer.RecoverState = RecoverState;
            writer.HighConversionGain = HighConversionGain;
            writer.MeasuredGreyFraction = MeasuredGreyFraction;
            writer.TargetGreyFraction = TargetGreyFraction;
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

        public uint EncodeId
        {
            get;
            set;
        }

        public ulong TimestampEof
        {
            get;
            set;
        }

        public int FrameLength
        {
            get;
            set;
        }

        public int IntegLines
        {
            get;
            set;
        }

        public int GlobalGainDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<byte> Image
        {
            get;
            set;
        }

        public Cereal.FrameData.FrameType TheFrameType
        {
            get;
            set;
        }

        public ulong TimestampSof
        {
            get;
            set;
        }

        public Cereal.FrameData.AndroidCaptureResult TheAndroidCaptureResult
        {
            get;
            set;
        }

        public IReadOnlyList<float> Transform
        {
            get;
            set;
        }

        public int LensPos
        {
            get;
            set;
        }

        public float LensSag
        {
            get;
            set;
        }

        public float LensErr
        {
            get;
            set;
        }

        public float LensTruePos
        {
            get;
            set;
        }

        public float Gain
        {
            get;
            set;
        }

        public IReadOnlyList<short> FocusVal
        {
            get;
            set;
        }

        public IReadOnlyList<byte> FocusConf
        {
            get;
            set;
        }

        public IReadOnlyList<ushort> SharpnessScore
        {
            get;
            set;
        }

        public int RecoverState
        {
            get;
            set;
        }

        public bool HighConversionGain
        {
            get;
            set;
        }

        public float MeasuredGreyFraction
        {
            get;
            set;
        }

        public float TargetGreyFraction
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
            public uint EncodeId => ctx.ReadDataUInt(32UL, 0U);
            public ulong TimestampEof => ctx.ReadDataULong(64UL, 0UL);
            public int FrameLength => ctx.ReadDataInt(128UL, 0);
            public int IntegLines => ctx.ReadDataInt(160UL, 0);
            public int GlobalGainDEPRECATED => ctx.ReadDataInt(192UL, 0);
            public IReadOnlyList<byte> Image => ctx.ReadList(0).CastByte();
            public Cereal.FrameData.FrameType TheFrameType => (Cereal.FrameData.FrameType)ctx.ReadDataUShort(224UL, (ushort)0);
            public ulong TimestampSof => ctx.ReadDataULong(256UL, 0UL);
            public Cereal.FrameData.AndroidCaptureResult.READER TheAndroidCaptureResult => ctx.ReadStruct(1, Cereal.FrameData.AndroidCaptureResult.READER.create);
            public IReadOnlyList<float> Transform => ctx.ReadList(2).CastFloat();
            public int LensPos => ctx.ReadDataInt(320UL, 0);
            public float LensSag => ctx.ReadDataFloat(352UL, 0F);
            public float LensErr => ctx.ReadDataFloat(384UL, 0F);
            public float LensTruePos => ctx.ReadDataFloat(416UL, 0F);
            public float Gain => ctx.ReadDataFloat(448UL, 0F);
            public IReadOnlyList<short> FocusVal => ctx.ReadList(3).CastShort();
            public IReadOnlyList<byte> FocusConf => ctx.ReadList(4).CastByte();
            public IReadOnlyList<ushort> SharpnessScore => ctx.ReadList(5).CastUShort();
            public int RecoverState => ctx.ReadDataInt(480UL, 0);
            public bool HighConversionGain => ctx.ReadDataBool(240UL, false);
            public float MeasuredGreyFraction => ctx.ReadDataFloat(512UL, 0F);
            public float TargetGreyFraction => ctx.ReadDataFloat(544UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(9, 6);
            }

            public uint FrameId
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public uint EncodeId
            {
                get => this.ReadDataUInt(32UL, 0U);
                set => this.WriteData(32UL, value, 0U);
            }

            public ulong TimestampEof
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public int FrameLength
            {
                get => this.ReadDataInt(128UL, 0);
                set => this.WriteData(128UL, value, 0);
            }

            public int IntegLines
            {
                get => this.ReadDataInt(160UL, 0);
                set => this.WriteData(160UL, value, 0);
            }

            public int GlobalGainDEPRECATED
            {
                get => this.ReadDataInt(192UL, 0);
                set => this.WriteData(192UL, value, 0);
            }

            public ListOfPrimitivesSerializer<byte> Image
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(0);
                set => Link(0, value);
            }

            public Cereal.FrameData.FrameType TheFrameType
            {
                get => (Cereal.FrameData.FrameType)this.ReadDataUShort(224UL, (ushort)0);
                set => this.WriteData(224UL, (ushort)value, (ushort)0);
            }

            public ulong TimestampSof
            {
                get => this.ReadDataULong(256UL, 0UL);
                set => this.WriteData(256UL, value, 0UL);
            }

            public Cereal.FrameData.AndroidCaptureResult.WRITER TheAndroidCaptureResult
            {
                get => BuildPointer<Cereal.FrameData.AndroidCaptureResult.WRITER>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> Transform
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public int LensPos
            {
                get => this.ReadDataInt(320UL, 0);
                set => this.WriteData(320UL, value, 0);
            }

            public float LensSag
            {
                get => this.ReadDataFloat(352UL, 0F);
                set => this.WriteData(352UL, value, 0F);
            }

            public float LensErr
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }

            public float LensTruePos
            {
                get => this.ReadDataFloat(416UL, 0F);
                set => this.WriteData(416UL, value, 0F);
            }

            public float Gain
            {
                get => this.ReadDataFloat(448UL, 0F);
                set => this.WriteData(448UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<short> FocusVal
            {
                get => BuildPointer<ListOfPrimitivesSerializer<short>>(3);
                set => Link(3, value);
            }

            public ListOfPrimitivesSerializer<byte> FocusConf
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<ushort> SharpnessScore
            {
                get => BuildPointer<ListOfPrimitivesSerializer<ushort>>(5);
                set => Link(5, value);
            }

            public int RecoverState
            {
                get => this.ReadDataInt(480UL, 0);
                set => this.WriteData(480UL, value, 0);
            }

            public bool HighConversionGain
            {
                get => this.ReadDataBool(240UL, false);
                set => this.WriteData(240UL, value, false);
            }

            public float MeasuredGreyFraction
            {
                get => this.ReadDataFloat(512UL, 0F);
                set => this.WriteData(512UL, value, 0F);
            }

            public float TargetGreyFraction
            {
                get => this.ReadDataFloat(544UL, 0F);
                set => this.WriteData(544UL, value, 0F);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xddb169f01e102879UL)]
        public enum FrameType : ushort
        {
            unknown,
            neo,
            chffrAndroid,
            front
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbcc3efbac41d2048UL)]
        public class AndroidCaptureResult : ICapnpSerializable
        {
            public const UInt64 typeId = 0xbcc3efbac41d2048UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Sensitivity = reader.Sensitivity;
                FrameDuration = reader.FrameDuration;
                ExposureTime = reader.ExposureTime;
                RollingShutterSkew = reader.RollingShutterSkew;
                ColorCorrectionTransform = reader.ColorCorrectionTransform;
                ColorCorrectionGains = reader.ColorCorrectionGains;
                DisplayRotation = reader.DisplayRotation;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Sensitivity = Sensitivity;
                writer.FrameDuration = FrameDuration;
                writer.ExposureTime = ExposureTime;
                writer.RollingShutterSkew = RollingShutterSkew;
                writer.ColorCorrectionTransform.Init(ColorCorrectionTransform);
                writer.ColorCorrectionGains.Init(ColorCorrectionGains);
                writer.DisplayRotation = DisplayRotation;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public int Sensitivity
            {
                get;
                set;
            }

            public long FrameDuration
            {
                get;
                set;
            }

            public long ExposureTime
            {
                get;
                set;
            }

            public ulong RollingShutterSkew
            {
                get;
                set;
            }

            public IReadOnlyList<int> ColorCorrectionTransform
            {
                get;
                set;
            }

            public IReadOnlyList<float> ColorCorrectionGains
            {
                get;
                set;
            }

            public sbyte DisplayRotation
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
                public int Sensitivity => ctx.ReadDataInt(0UL, 0);
                public long FrameDuration => ctx.ReadDataLong(64UL, 0L);
                public long ExposureTime => ctx.ReadDataLong(128UL, 0L);
                public ulong RollingShutterSkew => ctx.ReadDataULong(192UL, 0UL);
                public IReadOnlyList<int> ColorCorrectionTransform => ctx.ReadList(0).CastInt();
                public IReadOnlyList<float> ColorCorrectionGains => ctx.ReadList(1).CastFloat();
                public sbyte DisplayRotation => ctx.ReadDataSByte(32UL, (sbyte)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(4, 2);
                }

                public int Sensitivity
                {
                    get => this.ReadDataInt(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public long FrameDuration
                {
                    get => this.ReadDataLong(64UL, 0L);
                    set => this.WriteData(64UL, value, 0L);
                }

                public long ExposureTime
                {
                    get => this.ReadDataLong(128UL, 0L);
                    set => this.WriteData(128UL, value, 0L);
                }

                public ulong RollingShutterSkew
                {
                    get => this.ReadDataULong(192UL, 0UL);
                    set => this.WriteData(192UL, value, 0UL);
                }

                public ListOfPrimitivesSerializer<int> ColorCorrectionTransform
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<int>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> ColorCorrectionGains
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public sbyte DisplayRotation
                {
                    get => this.ReadDataSByte(32UL, (sbyte)0);
                    set => this.WriteData(32UL, value, (sbyte)0);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb65fce64120af7d3UL)]
    public class Thumbnail : ICapnpSerializable
    {
        public const UInt64 typeId = 0xb65fce64120af7d3UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            FrameId = reader.FrameId;
            TimestampEof = reader.TimestampEof;
            TheThumbnail = reader.TheThumbnail;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.FrameId = FrameId;
            writer.TimestampEof = TimestampEof;
            writer.TheThumbnail.Init(TheThumbnail);
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

        public ulong TimestampEof
        {
            get;
            set;
        }

        public IReadOnlyList<byte> TheThumbnail
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
            public ulong TimestampEof => ctx.ReadDataULong(64UL, 0UL);
            public IReadOnlyList<byte> TheThumbnail => ctx.ReadList(0).CastByte();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 1);
            }

            public uint FrameId
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public ulong TimestampEof
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<byte> TheThumbnail
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(0);
                set => Link(0, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9d291d7813ba4a88UL)]
    public class GPSNMEAData : ICapnpSerializable
    {
        public const UInt64 typeId = 0x9d291d7813ba4a88UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Timestamp = reader.Timestamp;
            LocalWallTime = reader.LocalWallTime;
            Nmea = reader.Nmea;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Timestamp = Timestamp;
            writer.LocalWallTime = LocalWallTime;
            writer.Nmea = Nmea;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public long Timestamp
        {
            get;
            set;
        }

        public ulong LocalWallTime
        {
            get;
            set;
        }

        public string Nmea
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
            public long Timestamp => ctx.ReadDataLong(0UL, 0L);
            public ulong LocalWallTime => ctx.ReadDataULong(64UL, 0UL);
            public string Nmea => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 1);
            }

            public long Timestamp
            {
                get => this.ReadDataLong(0UL, 0L);
                set => this.WriteData(0UL, value, 0L);
            }

            public ulong LocalWallTime
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public string Nmea
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa2b29a69d44529a1UL)]
    public class SensorEventData : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa2b29a69d44529a1UL;
        public enum WHICH : ushort
        {
            Acceleration = 0,
            Magnetic = 1,
            Orientation = 2,
            Gyro = 3,
            Pressure = 4,
            MagneticUncalibrated = 5,
            GyroUncalibrated = 6,
            Proximity = 7,
            Light = 8,
            Temperature = 9,
            undefined = 65535
        }

        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            switch (reader.which)
            {
                case WHICH.Acceleration:
                    Acceleration = CapnpSerializable.Create<Cereal.SensorEventData.SensorVec>(reader.Acceleration);
                    break;
                case WHICH.Magnetic:
                    Magnetic = CapnpSerializable.Create<Cereal.SensorEventData.SensorVec>(reader.Magnetic);
                    break;
                case WHICH.Orientation:
                    Orientation = CapnpSerializable.Create<Cereal.SensorEventData.SensorVec>(reader.Orientation);
                    break;
                case WHICH.Gyro:
                    Gyro = CapnpSerializable.Create<Cereal.SensorEventData.SensorVec>(reader.Gyro);
                    break;
                case WHICH.Pressure:
                    Pressure = CapnpSerializable.Create<Cereal.SensorEventData.SensorVec>(reader.Pressure);
                    break;
                case WHICH.MagneticUncalibrated:
                    MagneticUncalibrated = CapnpSerializable.Create<Cereal.SensorEventData.SensorVec>(reader.MagneticUncalibrated);
                    break;
                case WHICH.GyroUncalibrated:
                    GyroUncalibrated = CapnpSerializable.Create<Cereal.SensorEventData.SensorVec>(reader.GyroUncalibrated);
                    break;
                case WHICH.Proximity:
                    Proximity = reader.Proximity;
                    break;
                case WHICH.Light:
                    Light = reader.Light;
                    break;
                case WHICH.Temperature:
                    Temperature = reader.Temperature;
                    break;
            }

            Version = reader.Version;
            Sensor = reader.Sensor;
            Type = reader.Type;
            Timestamp = reader.Timestamp;
            Source = reader.Source;
            UncalibratedDEPRECATED = reader.UncalibratedDEPRECATED;
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
                    case WHICH.Acceleration:
                        _content = null;
                        break;
                    case WHICH.Magnetic:
                        _content = null;
                        break;
                    case WHICH.Orientation:
                        _content = null;
                        break;
                    case WHICH.Gyro:
                        _content = null;
                        break;
                    case WHICH.Pressure:
                        _content = null;
                        break;
                    case WHICH.MagneticUncalibrated:
                        _content = null;
                        break;
                    case WHICH.GyroUncalibrated:
                        _content = null;
                        break;
                    case WHICH.Proximity:
                        _content = 0F;
                        break;
                    case WHICH.Light:
                        _content = 0F;
                        break;
                    case WHICH.Temperature:
                        _content = 0F;
                        break;
                }
            }
        }

        public void serialize(WRITER writer)
        {
            writer.which = which;
            switch (which)
            {
                case WHICH.Acceleration:
                    Acceleration?.serialize(writer.Acceleration);
                    break;
                case WHICH.Magnetic:
                    Magnetic?.serialize(writer.Magnetic);
                    break;
                case WHICH.Orientation:
                    Orientation?.serialize(writer.Orientation);
                    break;
                case WHICH.Gyro:
                    Gyro?.serialize(writer.Gyro);
                    break;
                case WHICH.Pressure:
                    Pressure?.serialize(writer.Pressure);
                    break;
                case WHICH.MagneticUncalibrated:
                    MagneticUncalibrated?.serialize(writer.MagneticUncalibrated);
                    break;
                case WHICH.GyroUncalibrated:
                    GyroUncalibrated?.serialize(writer.GyroUncalibrated);
                    break;
                case WHICH.Proximity:
                    writer.Proximity = Proximity.Value;
                    break;
                case WHICH.Light:
                    writer.Light = Light.Value;
                    break;
                case WHICH.Temperature:
                    writer.Temperature = Temperature.Value;
                    break;
            }

            writer.Version = Version;
            writer.Sensor = Sensor;
            writer.Type = Type;
            writer.Timestamp = Timestamp;
            writer.Source = Source;
            writer.UncalibratedDEPRECATED = UncalibratedDEPRECATED;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public int Version
        {
            get;
            set;
        }

        public int Sensor
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public long Timestamp
        {
            get;
            set;
        }

        public Cereal.SensorEventData.SensorVec Acceleration
        {
            get => _which == WHICH.Acceleration ? (Cereal.SensorEventData.SensorVec)_content : null;
            set
            {
                _which = WHICH.Acceleration;
                _content = value;
            }
        }

        public Cereal.SensorEventData.SensorVec Magnetic
        {
            get => _which == WHICH.Magnetic ? (Cereal.SensorEventData.SensorVec)_content : null;
            set
            {
                _which = WHICH.Magnetic;
                _content = value;
            }
        }

        public Cereal.SensorEventData.SensorVec Orientation
        {
            get => _which == WHICH.Orientation ? (Cereal.SensorEventData.SensorVec)_content : null;
            set
            {
                _which = WHICH.Orientation;
                _content = value;
            }
        }

        public Cereal.SensorEventData.SensorVec Gyro
        {
            get => _which == WHICH.Gyro ? (Cereal.SensorEventData.SensorVec)_content : null;
            set
            {
                _which = WHICH.Gyro;
                _content = value;
            }
        }

        public Cereal.SensorEventData.SensorSource Source
        {
            get;
            set;
        }

        public Cereal.SensorEventData.SensorVec Pressure
        {
            get => _which == WHICH.Pressure ? (Cereal.SensorEventData.SensorVec)_content : null;
            set
            {
                _which = WHICH.Pressure;
                _content = value;
            }
        }

        public bool UncalibratedDEPRECATED
        {
            get;
            set;
        }

        public Cereal.SensorEventData.SensorVec MagneticUncalibrated
        {
            get => _which == WHICH.MagneticUncalibrated ? (Cereal.SensorEventData.SensorVec)_content : null;
            set
            {
                _which = WHICH.MagneticUncalibrated;
                _content = value;
            }
        }

        public Cereal.SensorEventData.SensorVec GyroUncalibrated
        {
            get => _which == WHICH.GyroUncalibrated ? (Cereal.SensorEventData.SensorVec)_content : null;
            set
            {
                _which = WHICH.GyroUncalibrated;
                _content = value;
            }
        }

        public float? Proximity
        {
            get => _which == WHICH.Proximity ? (float? )_content : null;
            set
            {
                _which = WHICH.Proximity;
                _content = value;
            }
        }

        public float? Light
        {
            get => _which == WHICH.Light ? (float? )_content : null;
            set
            {
                _which = WHICH.Light;
                _content = value;
            }
        }

        public float? Temperature
        {
            get => _which == WHICH.Temperature ? (float? )_content : null;
            set
            {
                _which = WHICH.Temperature;
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
            public WHICH which => (WHICH)ctx.ReadDataUShort(96U, (ushort)0);
            public int Version => ctx.ReadDataInt(0UL, 0);
            public int Sensor => ctx.ReadDataInt(32UL, 0);
            public int Type => ctx.ReadDataInt(64UL, 0);
            public long Timestamp => ctx.ReadDataLong(128UL, 0L);
            public Cereal.SensorEventData.SensorVec.READER Acceleration => which == WHICH.Acceleration ? ctx.ReadStruct(0, Cereal.SensorEventData.SensorVec.READER.create) : default;
            public Cereal.SensorEventData.SensorVec.READER Magnetic => which == WHICH.Magnetic ? ctx.ReadStruct(0, Cereal.SensorEventData.SensorVec.READER.create) : default;
            public Cereal.SensorEventData.SensorVec.READER Orientation => which == WHICH.Orientation ? ctx.ReadStruct(0, Cereal.SensorEventData.SensorVec.READER.create) : default;
            public Cereal.SensorEventData.SensorVec.READER Gyro => which == WHICH.Gyro ? ctx.ReadStruct(0, Cereal.SensorEventData.SensorVec.READER.create) : default;
            public Cereal.SensorEventData.SensorSource Source => (Cereal.SensorEventData.SensorSource)ctx.ReadDataUShort(112UL, (ushort)0);
            public Cereal.SensorEventData.SensorVec.READER Pressure => which == WHICH.Pressure ? ctx.ReadStruct(0, Cereal.SensorEventData.SensorVec.READER.create) : default;
            public bool UncalibratedDEPRECATED => ctx.ReadDataBool(192UL, false);
            public Cereal.SensorEventData.SensorVec.READER MagneticUncalibrated => which == WHICH.MagneticUncalibrated ? ctx.ReadStruct(0, Cereal.SensorEventData.SensorVec.READER.create) : default;
            public Cereal.SensorEventData.SensorVec.READER GyroUncalibrated => which == WHICH.GyroUncalibrated ? ctx.ReadStruct(0, Cereal.SensorEventData.SensorVec.READER.create) : default;
            public float Proximity => which == WHICH.Proximity ? ctx.ReadDataFloat(224UL, 0F) : default;
            public float Light => which == WHICH.Light ? ctx.ReadDataFloat(224UL, 0F) : default;
            public float Temperature => which == WHICH.Temperature ? ctx.ReadDataFloat(224UL, 0F) : default;
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(4, 1);
            }

            public WHICH which
            {
                get => (WHICH)this.ReadDataUShort(96U, (ushort)0);
                set => this.WriteData(96U, (ushort)value, (ushort)0);
            }

            public int Version
            {
                get => this.ReadDataInt(0UL, 0);
                set => this.WriteData(0UL, value, 0);
            }

            public int Sensor
            {
                get => this.ReadDataInt(32UL, 0);
                set => this.WriteData(32UL, value, 0);
            }

            public int Type
            {
                get => this.ReadDataInt(64UL, 0);
                set => this.WriteData(64UL, value, 0);
            }

            public long Timestamp
            {
                get => this.ReadDataLong(128UL, 0L);
                set => this.WriteData(128UL, value, 0L);
            }

            public Cereal.SensorEventData.SensorVec.WRITER Acceleration
            {
                get => which == WHICH.Acceleration ? BuildPointer<Cereal.SensorEventData.SensorVec.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.SensorEventData.SensorVec.WRITER Magnetic
            {
                get => which == WHICH.Magnetic ? BuildPointer<Cereal.SensorEventData.SensorVec.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.SensorEventData.SensorVec.WRITER Orientation
            {
                get => which == WHICH.Orientation ? BuildPointer<Cereal.SensorEventData.SensorVec.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.SensorEventData.SensorVec.WRITER Gyro
            {
                get => which == WHICH.Gyro ? BuildPointer<Cereal.SensorEventData.SensorVec.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.SensorEventData.SensorSource Source
            {
                get => (Cereal.SensorEventData.SensorSource)this.ReadDataUShort(112UL, (ushort)0);
                set => this.WriteData(112UL, (ushort)value, (ushort)0);
            }

            public Cereal.SensorEventData.SensorVec.WRITER Pressure
            {
                get => which == WHICH.Pressure ? BuildPointer<Cereal.SensorEventData.SensorVec.WRITER>(0) : default;
                set => Link(0, value);
            }

            public bool UncalibratedDEPRECATED
            {
                get => this.ReadDataBool(192UL, false);
                set => this.WriteData(192UL, value, false);
            }

            public Cereal.SensorEventData.SensorVec.WRITER MagneticUncalibrated
            {
                get => which == WHICH.MagneticUncalibrated ? BuildPointer<Cereal.SensorEventData.SensorVec.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.SensorEventData.SensorVec.WRITER GyroUncalibrated
            {
                get => which == WHICH.GyroUncalibrated ? BuildPointer<Cereal.SensorEventData.SensorVec.WRITER>(0) : default;
                set => Link(0, value);
            }

            public float Proximity
            {
                get => which == WHICH.Proximity ? this.ReadDataFloat(224UL, 0F) : default;
                set => this.WriteData(224UL, value, 0F);
            }

            public float Light
            {
                get => which == WHICH.Light ? this.ReadDataFloat(224UL, 0F) : default;
                set => this.WriteData(224UL, value, 0F);
            }

            public float Temperature
            {
                get => which == WHICH.Temperature ? this.ReadDataFloat(224UL, 0F) : default;
                set => this.WriteData(224UL, value, 0F);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa43429bd2bfc24fcUL)]
        public class SensorVec : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa43429bd2bfc24fcUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                V = reader.V;
                Status = reader.Status;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.V.Init(V);
                writer.Status = Status;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> V
            {
                get;
                set;
            }

            public sbyte Status
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
                public IReadOnlyList<float> V => ctx.ReadList(0).CastFloat();
                public sbyte Status => ctx.ReadDataSByte(0UL, (sbyte)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 1);
                }

                public ListOfPrimitivesSerializer<float> V
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public sbyte Status
                {
                    get => this.ReadDataSByte(0UL, (sbyte)0);
                    set => this.WriteData(0UL, value, (sbyte)0);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe49b3ce8f7f48d0dUL)]
        public enum SensorSource : ushort
        {
            android,
            iOS,
            fiber,
            velodyne,
            bno055,
            lsm6ds3,
            bmp280,
            mmc3416x,
            bmx055,
            rpr0521,
            lsm6ds3trc,
            mmc5603nj
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe946524859add50eUL)]
    public class GpsLocationData : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe946524859add50eUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Flags = reader.Flags;
            Latitude = reader.Latitude;
            Longitude = reader.Longitude;
            Altitude = reader.Altitude;
            Speed = reader.Speed;
            BearingDeg = reader.BearingDeg;
            Accuracy = reader.Accuracy;
            Timestamp = reader.Timestamp;
            Source = reader.Source;
            VNED = reader.VNED;
            VerticalAccuracy = reader.VerticalAccuracy;
            BearingAccuracyDeg = reader.BearingAccuracyDeg;
            SpeedAccuracy = reader.SpeedAccuracy;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Flags = Flags;
            writer.Latitude = Latitude;
            writer.Longitude = Longitude;
            writer.Altitude = Altitude;
            writer.Speed = Speed;
            writer.BearingDeg = BearingDeg;
            writer.Accuracy = Accuracy;
            writer.Timestamp = Timestamp;
            writer.Source = Source;
            writer.VNED.Init(VNED);
            writer.VerticalAccuracy = VerticalAccuracy;
            writer.BearingAccuracyDeg = BearingAccuracyDeg;
            writer.SpeedAccuracy = SpeedAccuracy;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ushort Flags
        {
            get;
            set;
        }

        public double Latitude
        {
            get;
            set;
        }

        public double Longitude
        {
            get;
            set;
        }

        public double Altitude
        {
            get;
            set;
        }

        public float Speed
        {
            get;
            set;
        }

        public float BearingDeg
        {
            get;
            set;
        }

        public float Accuracy
        {
            get;
            set;
        }

        public long Timestamp
        {
            get;
            set;
        }

        public Cereal.GpsLocationData.SensorSource Source
        {
            get;
            set;
        }

        public IReadOnlyList<float> VNED
        {
            get;
            set;
        }

        public float VerticalAccuracy
        {
            get;
            set;
        }

        public float BearingAccuracyDeg
        {
            get;
            set;
        }

        public float SpeedAccuracy
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
            public ushort Flags => ctx.ReadDataUShort(0UL, (ushort)0);
            public double Latitude => ctx.ReadDataDouble(64UL, 0);
            public double Longitude => ctx.ReadDataDouble(128UL, 0);
            public double Altitude => ctx.ReadDataDouble(192UL, 0);
            public float Speed => ctx.ReadDataFloat(32UL, 0F);
            public float BearingDeg => ctx.ReadDataFloat(256UL, 0F);
            public float Accuracy => ctx.ReadDataFloat(288UL, 0F);
            public long Timestamp => ctx.ReadDataLong(320UL, 0L);
            public Cereal.GpsLocationData.SensorSource Source => (Cereal.GpsLocationData.SensorSource)ctx.ReadDataUShort(16UL, (ushort)0);
            public IReadOnlyList<float> VNED => ctx.ReadList(0).CastFloat();
            public float VerticalAccuracy => ctx.ReadDataFloat(384UL, 0F);
            public float BearingAccuracyDeg => ctx.ReadDataFloat(416UL, 0F);
            public float SpeedAccuracy => ctx.ReadDataFloat(448UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(8, 1);
            }

            public ushort Flags
            {
                get => this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, value, (ushort)0);
            }

            public double Latitude
            {
                get => this.ReadDataDouble(64UL, 0);
                set => this.WriteData(64UL, value, 0);
            }

            public double Longitude
            {
                get => this.ReadDataDouble(128UL, 0);
                set => this.WriteData(128UL, value, 0);
            }

            public double Altitude
            {
                get => this.ReadDataDouble(192UL, 0);
                set => this.WriteData(192UL, value, 0);
            }

            public float Speed
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float BearingDeg
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }

            public float Accuracy
            {
                get => this.ReadDataFloat(288UL, 0F);
                set => this.WriteData(288UL, value, 0F);
            }

            public long Timestamp
            {
                get => this.ReadDataLong(320UL, 0L);
                set => this.WriteData(320UL, value, 0L);
            }

            public Cereal.GpsLocationData.SensorSource Source
            {
                get => (Cereal.GpsLocationData.SensorSource)this.ReadDataUShort(16UL, (ushort)0);
                set => this.WriteData(16UL, (ushort)value, (ushort)0);
            }

            public ListOfPrimitivesSerializer<float> VNED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public float VerticalAccuracy
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }

            public float BearingAccuracyDeg
            {
                get => this.ReadDataFloat(416UL, 0F);
                set => this.WriteData(416UL, value, 0F);
            }

            public float SpeedAccuracy
            {
                get => this.ReadDataFloat(448UL, 0F);
                set => this.WriteData(448UL, value, 0F);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd3ff79f25c734863UL)]
        public enum SensorSource : ushort
        {
            android,
            iOS,
            car,
            velodyne,
            fusion,
            external,
            ublox,
            trimble
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8785009a964c7c59UL)]
    public class CanData : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8785009a964c7c59UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Address = reader.Address;
            BusTime = reader.BusTime;
            Dat = reader.Dat;
            Src = reader.Src;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Address = Address;
            writer.BusTime = BusTime;
            writer.Dat.Init(Dat);
            writer.Src = Src;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public uint Address
        {
            get;
            set;
        }

        public ushort BusTime
        {
            get;
            set;
        }

        public IReadOnlyList<byte> Dat
        {
            get;
            set;
        }

        public byte Src
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
            public uint Address => ctx.ReadDataUInt(0UL, 0U);
            public ushort BusTime => ctx.ReadDataUShort(32UL, (ushort)0);
            public IReadOnlyList<byte> Dat => ctx.ReadList(0).CastByte();
            public byte Src => ctx.ReadDataByte(48UL, (byte)0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 1);
            }

            public uint Address
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public ushort BusTime
            {
                get => this.ReadDataUShort(32UL, (ushort)0);
                set => this.WriteData(32UL, value, (ushort)0);
            }

            public ListOfPrimitivesSerializer<byte> Dat
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(0);
                set => Link(0, value);
            }

            public byte Src
            {
                get => this.ReadDataByte(48UL, (byte)0);
                set => this.WriteData(48UL, value, (byte)0);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa4d8b5af2aa492ebUL)]
    public class DeviceState : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa4d8b5af2aa492ebUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Cpu0DEPRECATED = reader.Cpu0DEPRECATED;
            Cpu1DEPRECATED = reader.Cpu1DEPRECATED;
            Cpu2DEPRECATED = reader.Cpu2DEPRECATED;
            Cpu3DEPRECATED = reader.Cpu3DEPRECATED;
            MemDEPRECATED = reader.MemDEPRECATED;
            GpuDEPRECATED = reader.GpuDEPRECATED;
            BatDEPRECATED = reader.BatDEPRECATED;
            FreeSpacePercent = reader.FreeSpacePercent;
            BatteryPercent = reader.BatteryPercent;
            BatteryStatusDEPRECATED = reader.BatteryStatusDEPRECATED;
            FanSpeedPercentDesired = reader.FanSpeedPercentDesired;
            Started = reader.Started;
            UsbOnline = reader.UsbOnline;
            StartedMonoTime = reader.StartedMonoTime;
            TheThermalStatus = reader.TheThermalStatus;
            BatteryCurrent = reader.BatteryCurrent;
            BatteryVoltageDEPRECATED = reader.BatteryVoltageDEPRECATED;
            ChargingError = reader.ChargingError;
            ChargingDisabled = reader.ChargingDisabled;
            MemoryUsagePercent = reader.MemoryUsagePercent;
            CpuUsagePercentDEPRECATED = reader.CpuUsagePercentDEPRECATED;
            Pa0DEPRECATED = reader.Pa0DEPRECATED;
            TheNetworkType = reader.TheNetworkType;
            OffroadPowerUsageUwh = reader.OffroadPowerUsageUwh;
            TheNetworkStrength = reader.TheNetworkStrength;
            CarBatteryCapacityUwh = reader.CarBatteryCapacityUwh;
            CpuTempC = reader.CpuTempC;
            GpuTempC = reader.GpuTempC;
            MemoryTempC = reader.MemoryTempC;
            BatteryTempCDEPRECATED = reader.BatteryTempCDEPRECATED;
            AmbientTempC = reader.AmbientTempC;
            TheNetworkInfo = CapnpSerializable.Create<Cereal.DeviceState.NetworkInfo>(reader.TheNetworkInfo);
            LastAthenaPingTime = reader.LastAthenaPingTime;
            GpuUsagePercent = reader.GpuUsagePercent;
            CpuUsagePercent = reader.CpuUsagePercent;
            NvmeTempC = reader.NvmeTempC;
            ModemTempC = reader.ModemTempC;
            ScreenBrightnessPercent = reader.ScreenBrightnessPercent;
            ThermalZones = reader.ThermalZones?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.DeviceState.ThermalZone>(_));
            PmicTempC = reader.PmicTempC;
            PowerDrawW = reader.PowerDrawW;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Cpu0DEPRECATED = Cpu0DEPRECATED;
            writer.Cpu1DEPRECATED = Cpu1DEPRECATED;
            writer.Cpu2DEPRECATED = Cpu2DEPRECATED;
            writer.Cpu3DEPRECATED = Cpu3DEPRECATED;
            writer.MemDEPRECATED = MemDEPRECATED;
            writer.GpuDEPRECATED = GpuDEPRECATED;
            writer.BatDEPRECATED = BatDEPRECATED;
            writer.FreeSpacePercent = FreeSpacePercent;
            writer.BatteryPercent = BatteryPercent;
            writer.BatteryStatusDEPRECATED = BatteryStatusDEPRECATED;
            writer.FanSpeedPercentDesired = FanSpeedPercentDesired;
            writer.Started = Started;
            writer.UsbOnline = UsbOnline;
            writer.StartedMonoTime = StartedMonoTime;
            writer.TheThermalStatus = TheThermalStatus;
            writer.BatteryCurrent = BatteryCurrent;
            writer.BatteryVoltageDEPRECATED = BatteryVoltageDEPRECATED;
            writer.ChargingError = ChargingError;
            writer.ChargingDisabled = ChargingDisabled;
            writer.MemoryUsagePercent = MemoryUsagePercent;
            writer.CpuUsagePercentDEPRECATED = CpuUsagePercentDEPRECATED;
            writer.Pa0DEPRECATED = Pa0DEPRECATED;
            writer.TheNetworkType = TheNetworkType;
            writer.OffroadPowerUsageUwh = OffroadPowerUsageUwh;
            writer.TheNetworkStrength = TheNetworkStrength;
            writer.CarBatteryCapacityUwh = CarBatteryCapacityUwh;
            writer.CpuTempC.Init(CpuTempC);
            writer.GpuTempC.Init(GpuTempC);
            writer.MemoryTempC = MemoryTempC;
            writer.BatteryTempCDEPRECATED = BatteryTempCDEPRECATED;
            writer.AmbientTempC = AmbientTempC;
            TheNetworkInfo?.serialize(writer.TheNetworkInfo);
            writer.LastAthenaPingTime = LastAthenaPingTime;
            writer.GpuUsagePercent = GpuUsagePercent;
            writer.CpuUsagePercent.Init(CpuUsagePercent);
            writer.NvmeTempC.Init(NvmeTempC);
            writer.ModemTempC.Init(ModemTempC);
            writer.ScreenBrightnessPercent = ScreenBrightnessPercent;
            writer.ThermalZones.Init(ThermalZones, (_s1, _v1) => _v1?.serialize(_s1));
            writer.PmicTempC.Init(PmicTempC);
            writer.PowerDrawW = PowerDrawW;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ushort Cpu0DEPRECATED
        {
            get;
            set;
        }

        public ushort Cpu1DEPRECATED
        {
            get;
            set;
        }

        public ushort Cpu2DEPRECATED
        {
            get;
            set;
        }

        public ushort Cpu3DEPRECATED
        {
            get;
            set;
        }

        public ushort MemDEPRECATED
        {
            get;
            set;
        }

        public ushort GpuDEPRECATED
        {
            get;
            set;
        }

        public uint BatDEPRECATED
        {
            get;
            set;
        }

        public float FreeSpacePercent
        {
            get;
            set;
        }

        public short BatteryPercent
        {
            get;
            set;
        }

        public string BatteryStatusDEPRECATED
        {
            get;
            set;
        }

        public ushort FanSpeedPercentDesired
        {
            get;
            set;
        }

        public bool Started
        {
            get;
            set;
        }

        public bool UsbOnline
        {
            get;
            set;
        }

        public ulong StartedMonoTime
        {
            get;
            set;
        }

        public Cereal.DeviceState.ThermalStatus TheThermalStatus
        {
            get;
            set;
        }

        public int BatteryCurrent
        {
            get;
            set;
        }

        public int BatteryVoltageDEPRECATED
        {
            get;
            set;
        }

        public bool ChargingError
        {
            get;
            set;
        }

        public bool ChargingDisabled
        {
            get;
            set;
        }

        public sbyte MemoryUsagePercent
        {
            get;
            set;
        }

        public sbyte CpuUsagePercentDEPRECATED
        {
            get;
            set;
        }

        public ushort Pa0DEPRECATED
        {
            get;
            set;
        }

        public Cereal.DeviceState.NetworkType TheNetworkType
        {
            get;
            set;
        }

        public uint OffroadPowerUsageUwh
        {
            get;
            set;
        }

        public Cereal.DeviceState.NetworkStrength TheNetworkStrength
        {
            get;
            set;
        }

        public uint CarBatteryCapacityUwh
        {
            get;
            set;
        }

        public IReadOnlyList<float> CpuTempC
        {
            get;
            set;
        }

        public IReadOnlyList<float> GpuTempC
        {
            get;
            set;
        }

        public float MemoryTempC
        {
            get;
            set;
        }

        public float BatteryTempCDEPRECATED
        {
            get;
            set;
        }

        public float AmbientTempC
        {
            get;
            set;
        }

        public Cereal.DeviceState.NetworkInfo TheNetworkInfo
        {
            get;
            set;
        }

        public ulong LastAthenaPingTime
        {
            get;
            set;
        }

        public sbyte GpuUsagePercent
        {
            get;
            set;
        }

        public IReadOnlyList<sbyte> CpuUsagePercent
        {
            get;
            set;
        }

        public IReadOnlyList<float> NvmeTempC
        {
            get;
            set;
        }

        public IReadOnlyList<float> ModemTempC
        {
            get;
            set;
        }

        public sbyte ScreenBrightnessPercent
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.DeviceState.ThermalZone> ThermalZones
        {
            get;
            set;
        }

        public IReadOnlyList<float> PmicTempC
        {
            get;
            set;
        }

        public float PowerDrawW
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
            public ushort Cpu0DEPRECATED => ctx.ReadDataUShort(0UL, (ushort)0);
            public ushort Cpu1DEPRECATED => ctx.ReadDataUShort(16UL, (ushort)0);
            public ushort Cpu2DEPRECATED => ctx.ReadDataUShort(32UL, (ushort)0);
            public ushort Cpu3DEPRECATED => ctx.ReadDataUShort(48UL, (ushort)0);
            public ushort MemDEPRECATED => ctx.ReadDataUShort(64UL, (ushort)0);
            public ushort GpuDEPRECATED => ctx.ReadDataUShort(80UL, (ushort)0);
            public uint BatDEPRECATED => ctx.ReadDataUInt(96UL, 0U);
            public float FreeSpacePercent => ctx.ReadDataFloat(128UL, 0F);
            public short BatteryPercent => ctx.ReadDataShort(160UL, (short)0);
            public string BatteryStatusDEPRECATED => ctx.ReadText(0, null);
            public ushort FanSpeedPercentDesired => ctx.ReadDataUShort(176UL, (ushort)0);
            public bool Started => ctx.ReadDataBool(192UL, false);
            public bool UsbOnline => ctx.ReadDataBool(193UL, false);
            public ulong StartedMonoTime => ctx.ReadDataULong(256UL, 0UL);
            public Cereal.DeviceState.ThermalStatus TheThermalStatus => (Cereal.DeviceState.ThermalStatus)ctx.ReadDataUShort(208UL, (ushort)0);
            public int BatteryCurrent => ctx.ReadDataInt(224UL, 0);
            public int BatteryVoltageDEPRECATED => ctx.ReadDataInt(320UL, 0);
            public bool ChargingError => ctx.ReadDataBool(194UL, false);
            public bool ChargingDisabled => ctx.ReadDataBool(195UL, false);
            public sbyte MemoryUsagePercent => ctx.ReadDataSByte(200UL, (sbyte)0);
            public sbyte CpuUsagePercentDEPRECATED => ctx.ReadDataSByte(352UL, (sbyte)0);
            public ushort Pa0DEPRECATED => ctx.ReadDataUShort(368UL, (ushort)0);
            public Cereal.DeviceState.NetworkType TheNetworkType => (Cereal.DeviceState.NetworkType)ctx.ReadDataUShort(384UL, (ushort)0);
            public uint OffroadPowerUsageUwh => ctx.ReadDataUInt(416UL, 0U);
            public Cereal.DeviceState.NetworkStrength TheNetworkStrength => (Cereal.DeviceState.NetworkStrength)ctx.ReadDataUShort(400UL, (ushort)0);
            public uint CarBatteryCapacityUwh => ctx.ReadDataUInt(448UL, 0U);
            public IReadOnlyList<float> CpuTempC => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<float> GpuTempC => ctx.ReadList(2).CastFloat();
            public float MemoryTempC => ctx.ReadDataFloat(480UL, 0F);
            public float BatteryTempCDEPRECATED => ctx.ReadDataFloat(512UL, 0F);
            public float AmbientTempC => ctx.ReadDataFloat(544UL, 0F);
            public Cereal.DeviceState.NetworkInfo.READER TheNetworkInfo => ctx.ReadStruct(3, Cereal.DeviceState.NetworkInfo.READER.create);
            public ulong LastAthenaPingTime => ctx.ReadDataULong(576UL, 0UL);
            public sbyte GpuUsagePercent => ctx.ReadDataSByte(360UL, (sbyte)0);
            public IReadOnlyList<sbyte> CpuUsagePercent => ctx.ReadList(4).CastSByte();
            public IReadOnlyList<float> NvmeTempC => ctx.ReadList(5).CastFloat();
            public IReadOnlyList<float> ModemTempC => ctx.ReadList(6).CastFloat();
            public sbyte ScreenBrightnessPercent => ctx.ReadDataSByte(640UL, (sbyte)0);
            public IReadOnlyList<Cereal.DeviceState.ThermalZone.READER> ThermalZones => ctx.ReadList(7).Cast(Cereal.DeviceState.ThermalZone.READER.create);
            public IReadOnlyList<float> PmicTempC => ctx.ReadList(8).CastFloat();
            public float PowerDrawW => ctx.ReadDataFloat(672UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(11, 9);
            }

            public ushort Cpu0DEPRECATED
            {
                get => this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, value, (ushort)0);
            }

            public ushort Cpu1DEPRECATED
            {
                get => this.ReadDataUShort(16UL, (ushort)0);
                set => this.WriteData(16UL, value, (ushort)0);
            }

            public ushort Cpu2DEPRECATED
            {
                get => this.ReadDataUShort(32UL, (ushort)0);
                set => this.WriteData(32UL, value, (ushort)0);
            }

            public ushort Cpu3DEPRECATED
            {
                get => this.ReadDataUShort(48UL, (ushort)0);
                set => this.WriteData(48UL, value, (ushort)0);
            }

            public ushort MemDEPRECATED
            {
                get => this.ReadDataUShort(64UL, (ushort)0);
                set => this.WriteData(64UL, value, (ushort)0);
            }

            public ushort GpuDEPRECATED
            {
                get => this.ReadDataUShort(80UL, (ushort)0);
                set => this.WriteData(80UL, value, (ushort)0);
            }

            public uint BatDEPRECATED
            {
                get => this.ReadDataUInt(96UL, 0U);
                set => this.WriteData(96UL, value, 0U);
            }

            public float FreeSpacePercent
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public short BatteryPercent
            {
                get => this.ReadDataShort(160UL, (short)0);
                set => this.WriteData(160UL, value, (short)0);
            }

            public string BatteryStatusDEPRECATED
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public ushort FanSpeedPercentDesired
            {
                get => this.ReadDataUShort(176UL, (ushort)0);
                set => this.WriteData(176UL, value, (ushort)0);
            }

            public bool Started
            {
                get => this.ReadDataBool(192UL, false);
                set => this.WriteData(192UL, value, false);
            }

            public bool UsbOnline
            {
                get => this.ReadDataBool(193UL, false);
                set => this.WriteData(193UL, value, false);
            }

            public ulong StartedMonoTime
            {
                get => this.ReadDataULong(256UL, 0UL);
                set => this.WriteData(256UL, value, 0UL);
            }

            public Cereal.DeviceState.ThermalStatus TheThermalStatus
            {
                get => (Cereal.DeviceState.ThermalStatus)this.ReadDataUShort(208UL, (ushort)0);
                set => this.WriteData(208UL, (ushort)value, (ushort)0);
            }

            public int BatteryCurrent
            {
                get => this.ReadDataInt(224UL, 0);
                set => this.WriteData(224UL, value, 0);
            }

            public int BatteryVoltageDEPRECATED
            {
                get => this.ReadDataInt(320UL, 0);
                set => this.WriteData(320UL, value, 0);
            }

            public bool ChargingError
            {
                get => this.ReadDataBool(194UL, false);
                set => this.WriteData(194UL, value, false);
            }

            public bool ChargingDisabled
            {
                get => this.ReadDataBool(195UL, false);
                set => this.WriteData(195UL, value, false);
            }

            public sbyte MemoryUsagePercent
            {
                get => this.ReadDataSByte(200UL, (sbyte)0);
                set => this.WriteData(200UL, value, (sbyte)0);
            }

            public sbyte CpuUsagePercentDEPRECATED
            {
                get => this.ReadDataSByte(352UL, (sbyte)0);
                set => this.WriteData(352UL, value, (sbyte)0);
            }

            public ushort Pa0DEPRECATED
            {
                get => this.ReadDataUShort(368UL, (ushort)0);
                set => this.WriteData(368UL, value, (ushort)0);
            }

            public Cereal.DeviceState.NetworkType TheNetworkType
            {
                get => (Cereal.DeviceState.NetworkType)this.ReadDataUShort(384UL, (ushort)0);
                set => this.WriteData(384UL, (ushort)value, (ushort)0);
            }

            public uint OffroadPowerUsageUwh
            {
                get => this.ReadDataUInt(416UL, 0U);
                set => this.WriteData(416UL, value, 0U);
            }

            public Cereal.DeviceState.NetworkStrength TheNetworkStrength
            {
                get => (Cereal.DeviceState.NetworkStrength)this.ReadDataUShort(400UL, (ushort)0);
                set => this.WriteData(400UL, (ushort)value, (ushort)0);
            }

            public uint CarBatteryCapacityUwh
            {
                get => this.ReadDataUInt(448UL, 0U);
                set => this.WriteData(448UL, value, 0U);
            }

            public ListOfPrimitivesSerializer<float> CpuTempC
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> GpuTempC
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public float MemoryTempC
            {
                get => this.ReadDataFloat(480UL, 0F);
                set => this.WriteData(480UL, value, 0F);
            }

            public float BatteryTempCDEPRECATED
            {
                get => this.ReadDataFloat(512UL, 0F);
                set => this.WriteData(512UL, value, 0F);
            }

            public float AmbientTempC
            {
                get => this.ReadDataFloat(544UL, 0F);
                set => this.WriteData(544UL, value, 0F);
            }

            public Cereal.DeviceState.NetworkInfo.WRITER TheNetworkInfo
            {
                get => BuildPointer<Cereal.DeviceState.NetworkInfo.WRITER>(3);
                set => Link(3, value);
            }

            public ulong LastAthenaPingTime
            {
                get => this.ReadDataULong(576UL, 0UL);
                set => this.WriteData(576UL, value, 0UL);
            }

            public sbyte GpuUsagePercent
            {
                get => this.ReadDataSByte(360UL, (sbyte)0);
                set => this.WriteData(360UL, value, (sbyte)0);
            }

            public ListOfPrimitivesSerializer<sbyte> CpuUsagePercent
            {
                get => BuildPointer<ListOfPrimitivesSerializer<sbyte>>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<float> NvmeTempC
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public ListOfPrimitivesSerializer<float> ModemTempC
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(6);
                set => Link(6, value);
            }

            public sbyte ScreenBrightnessPercent
            {
                get => this.ReadDataSByte(640UL, (sbyte)0);
                set => this.WriteData(640UL, value, (sbyte)0);
            }

            public ListOfStructsSerializer<Cereal.DeviceState.ThermalZone.WRITER> ThermalZones
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.DeviceState.ThermalZone.WRITER>>(7);
                set => Link(7, value);
            }

            public ListOfPrimitivesSerializer<float> PmicTempC
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(8);
                set => Link(8, value);
            }

            public float PowerDrawW
            {
                get => this.ReadDataFloat(672UL, 0F);
                set => this.WriteData(672UL, value, 0F);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd0790029853df66fUL)]
        public class ThermalZone : ICapnpSerializable
        {
            public const UInt64 typeId = 0xd0790029853df66fUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Name = reader.Name;
                Temp = reader.Temp;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Name = Name;
                writer.Temp = Temp;
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

            public float Temp
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
                public float Temp => ctx.ReadDataFloat(0UL, 0F);
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

                public float Temp
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xaf0f7110c254f77eUL)]
        public enum ThermalStatus : ushort
        {
            green,
            yellow,
            red,
            danger
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbbc79cc958d1049dUL)]
        public enum NetworkType : ushort
        {
            none,
            wifi,
            cell2G,
            cell3G,
            cell4G,
            cell5G,
            ethernet
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xdd308c8a13203e13UL)]
        public enum NetworkStrength : ushort
        {
            unknown,
            poor,
            moderate,
            good,
            great
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9d57532d82c04afcUL)]
        public class NetworkInfo : ICapnpSerializable
        {
            public const UInt64 typeId = 0x9d57532d82c04afcUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Technology = reader.Technology;
                Operator = reader.Operator;
                Band = reader.Band;
                Channel = reader.Channel;
                Extra = reader.Extra;
                State = reader.State;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Technology = Technology;
                writer.Operator = Operator;
                writer.Band = Band;
                writer.Channel = Channel;
                writer.Extra = Extra;
                writer.State = State;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public string Technology
            {
                get;
                set;
            }

            public string Operator
            {
                get;
                set;
            }

            public string Band
            {
                get;
                set;
            }

            public ushort Channel
            {
                get;
                set;
            }

            public string Extra
            {
                get;
                set;
            }

            public string State
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
                public string Technology => ctx.ReadText(0, null);
                public string Operator => ctx.ReadText(1, null);
                public string Band => ctx.ReadText(2, null);
                public ushort Channel => ctx.ReadDataUShort(0UL, (ushort)0);
                public string Extra => ctx.ReadText(3, null);
                public string State => ctx.ReadText(4, null);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 5);
                }

                public string Technology
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public string Operator
                {
                    get => this.ReadText(1, null);
                    set => this.WriteText(1, value, null);
                }

                public string Band
                {
                    get => this.ReadText(2, null);
                    set => this.WriteText(2, value, null);
                }

                public ushort Channel
                {
                    get => this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, value, (ushort)0);
                }

                public string Extra
                {
                    get => this.ReadText(3, null);
                    set => this.WriteText(3, value, null);
                }

                public string State
                {
                    get => this.ReadText(4, null);
                    set => this.WriteText(4, value, null);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa7649e2575e4591eUL)]
    public class PandaState : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa7649e2575e4591eUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            VoltageDEPRECATED = reader.VoltageDEPRECATED;
            CurrentDEPRECATED = reader.CurrentDEPRECATED;
            IgnitionLine = reader.IgnitionLine;
            ControlsAllowed = reader.ControlsAllowed;
            GasInterceptorDetected = reader.GasInterceptorDetected;
            StartedSignalDetectedDEPRECATED = reader.StartedSignalDetectedDEPRECATED;
            HasGpsDEPRECATED = reader.HasGpsDEPRECATED;
            CanSendErrs = reader.CanSendErrs;
            CanFwdErrs = reader.CanFwdErrs;
            GmlanSendErrs = reader.GmlanSendErrs;
            ThePandaType = reader.ThePandaType;
            FanSpeedRpmDEPRECATED = reader.FanSpeedRpmDEPRECATED;
            UsbPowerModeDEPRECATED = reader.UsbPowerModeDEPRECATED;
            IgnitionCan = reader.IgnitionCan;
            SafetyModel = reader.SafetyModel;
            TheFaultStatus = reader.TheFaultStatus;
            PowerSaveEnabled = reader.PowerSaveEnabled;
            Uptime = reader.Uptime;
            Faults = reader.Faults;
            CanRxErrs = reader.CanRxErrs;
            SafetyParam = reader.SafetyParam;
            TheHarnessStatus = reader.TheHarnessStatus;
            HeartbeatLost = reader.HeartbeatLost;
            UnsafeMode = reader.UnsafeMode;
            BlockedCnt = reader.BlockedCnt;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.VoltageDEPRECATED = VoltageDEPRECATED;
            writer.CurrentDEPRECATED = CurrentDEPRECATED;
            writer.IgnitionLine = IgnitionLine;
            writer.ControlsAllowed = ControlsAllowed;
            writer.GasInterceptorDetected = GasInterceptorDetected;
            writer.StartedSignalDetectedDEPRECATED = StartedSignalDetectedDEPRECATED;
            writer.HasGpsDEPRECATED = HasGpsDEPRECATED;
            writer.CanSendErrs = CanSendErrs;
            writer.CanFwdErrs = CanFwdErrs;
            writer.GmlanSendErrs = GmlanSendErrs;
            writer.ThePandaType = ThePandaType;
            writer.FanSpeedRpmDEPRECATED = FanSpeedRpmDEPRECATED;
            writer.UsbPowerModeDEPRECATED = UsbPowerModeDEPRECATED;
            writer.IgnitionCan = IgnitionCan;
            writer.SafetyModel = SafetyModel;
            writer.TheFaultStatus = TheFaultStatus;
            writer.PowerSaveEnabled = PowerSaveEnabled;
            writer.Uptime = Uptime;
            writer.Faults.Init(Faults);
            writer.CanRxErrs = CanRxErrs;
            writer.SafetyParam = SafetyParam;
            writer.TheHarnessStatus = TheHarnessStatus;
            writer.HeartbeatLost = HeartbeatLost;
            writer.UnsafeMode = UnsafeMode;
            writer.BlockedCnt = BlockedCnt;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public uint VoltageDEPRECATED
        {
            get;
            set;
        }

        public uint CurrentDEPRECATED
        {
            get;
            set;
        }

        public bool IgnitionLine
        {
            get;
            set;
        }

        public bool ControlsAllowed
        {
            get;
            set;
        }

        public bool GasInterceptorDetected
        {
            get;
            set;
        }

        public bool StartedSignalDetectedDEPRECATED
        {
            get;
            set;
        }

        public bool HasGpsDEPRECATED
        {
            get;
            set;
        }

        public uint CanSendErrs
        {
            get;
            set;
        }

        public uint CanFwdErrs
        {
            get;
            set;
        }

        public uint GmlanSendErrs
        {
            get;
            set;
        }

        public Cereal.PandaState.PandaType ThePandaType
        {
            get;
            set;
        }

        public ushort FanSpeedRpmDEPRECATED
        {
            get;
            set;
        }

        public Cereal.PeripheralState.UsbPowerMode UsbPowerModeDEPRECATED
        {
            get;
            set;
        }

        public bool IgnitionCan
        {
            get;
            set;
        }

        public Cereal.CarParams.SafetyModel SafetyModel
        {
            get;
            set;
        }

        public Cereal.PandaState.FaultStatus TheFaultStatus
        {
            get;
            set;
        }

        public bool PowerSaveEnabled
        {
            get;
            set;
        }

        public uint Uptime
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.PandaState.FaultType> Faults
        {
            get;
            set;
        }

        public uint CanRxErrs
        {
            get;
            set;
        }

        public short SafetyParam
        {
            get;
            set;
        }

        public Cereal.PandaState.HarnessStatus TheHarnessStatus
        {
            get;
            set;
        }

        public bool HeartbeatLost
        {
            get;
            set;
        }

        public short UnsafeMode
        {
            get;
            set;
        }

        public uint BlockedCnt
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
            public uint VoltageDEPRECATED => ctx.ReadDataUInt(0UL, 0U);
            public uint CurrentDEPRECATED => ctx.ReadDataUInt(32UL, 0U);
            public bool IgnitionLine => ctx.ReadDataBool(64UL, false);
            public bool ControlsAllowed => ctx.ReadDataBool(65UL, false);
            public bool GasInterceptorDetected => ctx.ReadDataBool(66UL, false);
            public bool StartedSignalDetectedDEPRECATED => ctx.ReadDataBool(67UL, false);
            public bool HasGpsDEPRECATED => ctx.ReadDataBool(68UL, false);
            public uint CanSendErrs => ctx.ReadDataUInt(96UL, 0U);
            public uint CanFwdErrs => ctx.ReadDataUInt(128UL, 0U);
            public uint GmlanSendErrs => ctx.ReadDataUInt(160UL, 0U);
            public Cereal.PandaState.PandaType ThePandaType => (Cereal.PandaState.PandaType)ctx.ReadDataUShort(80UL, (ushort)0);
            public ushort FanSpeedRpmDEPRECATED => ctx.ReadDataUShort(192UL, (ushort)0);
            public Cereal.PeripheralState.UsbPowerMode UsbPowerModeDEPRECATED => (Cereal.PeripheralState.UsbPowerMode)ctx.ReadDataUShort(208UL, (ushort)0);
            public bool IgnitionCan => ctx.ReadDataBool(69UL, false);
            public Cereal.CarParams.SafetyModel SafetyModel => (Cereal.CarParams.SafetyModel)ctx.ReadDataUShort(224UL, (ushort)0);
            public Cereal.PandaState.FaultStatus TheFaultStatus => (Cereal.PandaState.FaultStatus)ctx.ReadDataUShort(240UL, (ushort)0);
            public bool PowerSaveEnabled => ctx.ReadDataBool(70UL, false);
            public uint Uptime => ctx.ReadDataUInt(256UL, 0U);
            public IReadOnlyList<Cereal.PandaState.FaultType> Faults => ctx.ReadList(0).CastEnums(_0 => (Cereal.PandaState.FaultType)_0);
            public uint CanRxErrs => ctx.ReadDataUInt(288UL, 0U);
            public short SafetyParam => ctx.ReadDataShort(320UL, (short)0);
            public Cereal.PandaState.HarnessStatus TheHarnessStatus => (Cereal.PandaState.HarnessStatus)ctx.ReadDataUShort(336UL, (ushort)0);
            public bool HeartbeatLost => ctx.ReadDataBool(71UL, false);
            public short UnsafeMode => ctx.ReadDataShort(352UL, (short)0);
            public uint BlockedCnt => ctx.ReadDataUInt(384UL, 0U);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(7, 1);
            }

            public uint VoltageDEPRECATED
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public uint CurrentDEPRECATED
            {
                get => this.ReadDataUInt(32UL, 0U);
                set => this.WriteData(32UL, value, 0U);
            }

            public bool IgnitionLine
            {
                get => this.ReadDataBool(64UL, false);
                set => this.WriteData(64UL, value, false);
            }

            public bool ControlsAllowed
            {
                get => this.ReadDataBool(65UL, false);
                set => this.WriteData(65UL, value, false);
            }

            public bool GasInterceptorDetected
            {
                get => this.ReadDataBool(66UL, false);
                set => this.WriteData(66UL, value, false);
            }

            public bool StartedSignalDetectedDEPRECATED
            {
                get => this.ReadDataBool(67UL, false);
                set => this.WriteData(67UL, value, false);
            }

            public bool HasGpsDEPRECATED
            {
                get => this.ReadDataBool(68UL, false);
                set => this.WriteData(68UL, value, false);
            }

            public uint CanSendErrs
            {
                get => this.ReadDataUInt(96UL, 0U);
                set => this.WriteData(96UL, value, 0U);
            }

            public uint CanFwdErrs
            {
                get => this.ReadDataUInt(128UL, 0U);
                set => this.WriteData(128UL, value, 0U);
            }

            public uint GmlanSendErrs
            {
                get => this.ReadDataUInt(160UL, 0U);
                set => this.WriteData(160UL, value, 0U);
            }

            public Cereal.PandaState.PandaType ThePandaType
            {
                get => (Cereal.PandaState.PandaType)this.ReadDataUShort(80UL, (ushort)0);
                set => this.WriteData(80UL, (ushort)value, (ushort)0);
            }

            public ushort FanSpeedRpmDEPRECATED
            {
                get => this.ReadDataUShort(192UL, (ushort)0);
                set => this.WriteData(192UL, value, (ushort)0);
            }

            public Cereal.PeripheralState.UsbPowerMode UsbPowerModeDEPRECATED
            {
                get => (Cereal.PeripheralState.UsbPowerMode)this.ReadDataUShort(208UL, (ushort)0);
                set => this.WriteData(208UL, (ushort)value, (ushort)0);
            }

            public bool IgnitionCan
            {
                get => this.ReadDataBool(69UL, false);
                set => this.WriteData(69UL, value, false);
            }

            public Cereal.CarParams.SafetyModel SafetyModel
            {
                get => (Cereal.CarParams.SafetyModel)this.ReadDataUShort(224UL, (ushort)0);
                set => this.WriteData(224UL, (ushort)value, (ushort)0);
            }

            public Cereal.PandaState.FaultStatus TheFaultStatus
            {
                get => (Cereal.PandaState.FaultStatus)this.ReadDataUShort(240UL, (ushort)0);
                set => this.WriteData(240UL, (ushort)value, (ushort)0);
            }

            public bool PowerSaveEnabled
            {
                get => this.ReadDataBool(70UL, false);
                set => this.WriteData(70UL, value, false);
            }

            public uint Uptime
            {
                get => this.ReadDataUInt(256UL, 0U);
                set => this.WriteData(256UL, value, 0U);
            }

            public ListOfPrimitivesSerializer<Cereal.PandaState.FaultType> Faults
            {
                get => BuildPointer<ListOfPrimitivesSerializer<Cereal.PandaState.FaultType>>(0);
                set => Link(0, value);
            }

            public uint CanRxErrs
            {
                get => this.ReadDataUInt(288UL, 0U);
                set => this.WriteData(288UL, value, 0U);
            }

            public short SafetyParam
            {
                get => this.ReadDataShort(320UL, (short)0);
                set => this.WriteData(320UL, value, (short)0);
            }

            public Cereal.PandaState.HarnessStatus TheHarnessStatus
            {
                get => (Cereal.PandaState.HarnessStatus)this.ReadDataUShort(336UL, (ushort)0);
                set => this.WriteData(336UL, (ushort)value, (ushort)0);
            }

            public bool HeartbeatLost
            {
                get => this.ReadDataBool(71UL, false);
                set => this.WriteData(71UL, value, false);
            }

            public short UnsafeMode
            {
                get => this.ReadDataShort(352UL, (short)0);
                set => this.WriteData(352UL, value, (short)0);
            }

            public uint BlockedCnt
            {
                get => this.ReadDataUInt(384UL, 0U);
                set => this.WriteData(384UL, value, 0U);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf2fd0b8b0ac9adbbUL)]
        public enum FaultStatus : ushort
        {
            none,
            faultTemp,
            faultPerm
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xcd55c07f69249798UL)]
        public enum FaultType : ushort
        {
            relayMalfunction,
            unusedInterruptHandled,
            interruptRateCan1,
            interruptRateCan2,
            interruptRateCan3,
            interruptRateTach,
            interruptRateGmlan,
            interruptRateInterrupts,
            interruptRateSpiDma,
            interruptRateSpiCs,
            interruptRateUart1,
            interruptRateUart2,
            interruptRateUart3,
            interruptRateUart5,
            interruptRateUartDma,
            interruptRateUsb,
            interruptRateTim1,
            interruptRateTim3,
            registerDivergent,
            interruptRateKlineInit,
            interruptRateClockSource,
            interruptRateTick
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8a58adf93e5b3751UL)]
        public enum PandaType : ushort
        {
            unknown,
            whitePanda,
            greyPanda,
            blackPanda,
            pedal,
            uno,
            dos,
            redPanda
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf69a3ed1e8c081bfUL)]
        public enum HarnessStatus : ushort
        {
            notConnected,
            normal,
            flipped
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xceb8f49734857a88UL)]
    public class PeripheralState : ICapnpSerializable
    {
        public const UInt64 typeId = 0xceb8f49734857a88UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            PandaType = reader.PandaType;
            Voltage = reader.Voltage;
            Current = reader.Current;
            FanSpeedRpm = reader.FanSpeedRpm;
            TheUsbPowerMode = reader.TheUsbPowerMode;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.PandaType = PandaType;
            writer.Voltage = Voltage;
            writer.Current = Current;
            writer.FanSpeedRpm = FanSpeedRpm;
            writer.TheUsbPowerMode = TheUsbPowerMode;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public Cereal.PandaState.PandaType PandaType
        {
            get;
            set;
        }

        public uint Voltage
        {
            get;
            set;
        }

        public uint Current
        {
            get;
            set;
        }

        public ushort FanSpeedRpm
        {
            get;
            set;
        }

        public Cereal.PeripheralState.UsbPowerMode TheUsbPowerMode
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
            public Cereal.PandaState.PandaType PandaType => (Cereal.PandaState.PandaType)ctx.ReadDataUShort(0UL, (ushort)0);
            public uint Voltage => ctx.ReadDataUInt(32UL, 0U);
            public uint Current => ctx.ReadDataUInt(64UL, 0U);
            public ushort FanSpeedRpm => ctx.ReadDataUShort(16UL, (ushort)0);
            public Cereal.PeripheralState.UsbPowerMode TheUsbPowerMode => (Cereal.PeripheralState.UsbPowerMode)ctx.ReadDataUShort(96UL, (ushort)0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 0);
            }

            public Cereal.PandaState.PandaType PandaType
            {
                get => (Cereal.PandaState.PandaType)this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, (ushort)value, (ushort)0);
            }

            public uint Voltage
            {
                get => this.ReadDataUInt(32UL, 0U);
                set => this.WriteData(32UL, value, 0U);
            }

            public uint Current
            {
                get => this.ReadDataUInt(64UL, 0U);
                set => this.WriteData(64UL, value, 0U);
            }

            public ushort FanSpeedRpm
            {
                get => this.ReadDataUShort(16UL, (ushort)0);
                set => this.WriteData(16UL, value, (ushort)0);
            }

            public Cereal.PeripheralState.UsbPowerMode TheUsbPowerMode
            {
                get => (Cereal.PeripheralState.UsbPowerMode)this.ReadDataUShort(96UL, (ushort)0);
                set => this.WriteData(96UL, (ushort)value, (ushort)0);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa8883583b32c9877UL)]
        public enum UsbPowerMode : ushort
        {
            none,
            client,
            cdp,
            dcp
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9a185389d6fdd05fUL)]
    public class RadarState : ICapnpSerializable
    {
        public const UInt64 typeId = 0x9a185389d6fdd05fUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            WarpMatrixDEPRECATED = reader.WarpMatrixDEPRECATED;
            AngleOffsetDEPRECATED = reader.AngleOffsetDEPRECATED;
            CalStatusDEPRECATED = reader.CalStatusDEPRECATED;
            LeadOne = CapnpSerializable.Create<Cereal.RadarState.LeadData>(reader.LeadOne);
            LeadTwo = CapnpSerializable.Create<Cereal.RadarState.LeadData>(reader.LeadTwo);
            CumLagMs = reader.CumLagMs;
            MdMonoTime = reader.MdMonoTime;
            FtMonoTimeDEPRECATED = reader.FtMonoTimeDEPRECATED;
            CalCycleDEPRECATED = reader.CalCycleDEPRECATED;
            CalPercDEPRECATED = reader.CalPercDEPRECATED;
            CanMonoTimes = reader.CanMonoTimes;
            CarStateMonoTime = reader.CarStateMonoTime;
            RadarErrors = reader.RadarErrors;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.WarpMatrixDEPRECATED.Init(WarpMatrixDEPRECATED);
            writer.AngleOffsetDEPRECATED = AngleOffsetDEPRECATED;
            writer.CalStatusDEPRECATED = CalStatusDEPRECATED;
            LeadOne?.serialize(writer.LeadOne);
            LeadTwo?.serialize(writer.LeadTwo);
            writer.CumLagMs = CumLagMs;
            writer.MdMonoTime = MdMonoTime;
            writer.FtMonoTimeDEPRECATED = FtMonoTimeDEPRECATED;
            writer.CalCycleDEPRECATED = CalCycleDEPRECATED;
            writer.CalPercDEPRECATED = CalPercDEPRECATED;
            writer.CanMonoTimes.Init(CanMonoTimes);
            writer.CarStateMonoTime = CarStateMonoTime;
            writer.RadarErrors.Init(RadarErrors);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<float> WarpMatrixDEPRECATED
        {
            get;
            set;
        }

        public float AngleOffsetDEPRECATED
        {
            get;
            set;
        }

        public sbyte CalStatusDEPRECATED
        {
            get;
            set;
        }

        public Cereal.RadarState.LeadData LeadOne
        {
            get;
            set;
        }

        public Cereal.RadarState.LeadData LeadTwo
        {
            get;
            set;
        }

        public float CumLagMs
        {
            get;
            set;
        }

        public ulong MdMonoTime
        {
            get;
            set;
        }

        public ulong FtMonoTimeDEPRECATED
        {
            get;
            set;
        }

        public int CalCycleDEPRECATED
        {
            get;
            set;
        }

        public sbyte CalPercDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<ulong> CanMonoTimes
        {
            get;
            set;
        }

        public ulong CarStateMonoTime
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.RadarData.Error> RadarErrors
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
            public IReadOnlyList<float> WarpMatrixDEPRECATED => ctx.ReadList(0).CastFloat();
            public float AngleOffsetDEPRECATED => ctx.ReadDataFloat(0UL, 0F);
            public sbyte CalStatusDEPRECATED => ctx.ReadDataSByte(32UL, (sbyte)0);
            public Cereal.RadarState.LeadData.READER LeadOne => ctx.ReadStruct(1, Cereal.RadarState.LeadData.READER.create);
            public Cereal.RadarState.LeadData.READER LeadTwo => ctx.ReadStruct(2, Cereal.RadarState.LeadData.READER.create);
            public float CumLagMs => ctx.ReadDataFloat(64UL, 0F);
            public ulong MdMonoTime => ctx.ReadDataULong(128UL, 0UL);
            public ulong FtMonoTimeDEPRECATED => ctx.ReadDataULong(192UL, 0UL);
            public int CalCycleDEPRECATED => ctx.ReadDataInt(96UL, 0);
            public sbyte CalPercDEPRECATED => ctx.ReadDataSByte(40UL, (sbyte)0);
            public IReadOnlyList<ulong> CanMonoTimes => ctx.ReadList(3).CastULong();
            public ulong CarStateMonoTime => ctx.ReadDataULong(256UL, 0UL);
            public IReadOnlyList<Cereal.RadarData.Error> RadarErrors => ctx.ReadList(4).CastEnums(_0 => (Cereal.RadarData.Error)_0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(5, 5);
            }

            public ListOfPrimitivesSerializer<float> WarpMatrixDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public float AngleOffsetDEPRECATED
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }

            public sbyte CalStatusDEPRECATED
            {
                get => this.ReadDataSByte(32UL, (sbyte)0);
                set => this.WriteData(32UL, value, (sbyte)0);
            }

            public Cereal.RadarState.LeadData.WRITER LeadOne
            {
                get => BuildPointer<Cereal.RadarState.LeadData.WRITER>(1);
                set => Link(1, value);
            }

            public Cereal.RadarState.LeadData.WRITER LeadTwo
            {
                get => BuildPointer<Cereal.RadarState.LeadData.WRITER>(2);
                set => Link(2, value);
            }

            public float CumLagMs
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public ulong MdMonoTime
            {
                get => this.ReadDataULong(128UL, 0UL);
                set => this.WriteData(128UL, value, 0UL);
            }

            public ulong FtMonoTimeDEPRECATED
            {
                get => this.ReadDataULong(192UL, 0UL);
                set => this.WriteData(192UL, value, 0UL);
            }

            public int CalCycleDEPRECATED
            {
                get => this.ReadDataInt(96UL, 0);
                set => this.WriteData(96UL, value, 0);
            }

            public sbyte CalPercDEPRECATED
            {
                get => this.ReadDataSByte(40UL, (sbyte)0);
                set => this.WriteData(40UL, value, (sbyte)0);
            }

            public ListOfPrimitivesSerializer<ulong> CanMonoTimes
            {
                get => BuildPointer<ListOfPrimitivesSerializer<ulong>>(3);
                set => Link(3, value);
            }

            public ulong CarStateMonoTime
            {
                get => this.ReadDataULong(256UL, 0UL);
                set => this.WriteData(256UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<Cereal.RadarData.Error> RadarErrors
            {
                get => BuildPointer<ListOfPrimitivesSerializer<Cereal.RadarData.Error>>(4);
                set => Link(4, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb96f3ad9170cf085UL)]
        public class LeadData : ICapnpSerializable
        {
            public const UInt64 typeId = 0xb96f3ad9170cf085UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                DRel = reader.DRel;
                YRel = reader.YRel;
                VRel = reader.VRel;
                ARel = reader.ARel;
                VLead = reader.VLead;
                ALeadDEPRECATED = reader.ALeadDEPRECATED;
                DPath = reader.DPath;
                VLat = reader.VLat;
                VLeadK = reader.VLeadK;
                ALeadK = reader.ALeadK;
                Fcw = reader.Fcw;
                Status = reader.Status;
                ALeadTau = reader.ALeadTau;
                ModelProb = reader.ModelProb;
                Radar = reader.Radar;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.DRel = DRel;
                writer.YRel = YRel;
                writer.VRel = VRel;
                writer.ARel = ARel;
                writer.VLead = VLead;
                writer.ALeadDEPRECATED = ALeadDEPRECATED;
                writer.DPath = DPath;
                writer.VLat = VLat;
                writer.VLeadK = VLeadK;
                writer.ALeadK = ALeadK;
                writer.Fcw = Fcw;
                writer.Status = Status;
                writer.ALeadTau = ALeadTau;
                writer.ModelProb = ModelProb;
                writer.Radar = Radar;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
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

            public float VLead
            {
                get;
                set;
            }

            public float ALeadDEPRECATED
            {
                get;
                set;
            }

            public float DPath
            {
                get;
                set;
            }

            public float VLat
            {
                get;
                set;
            }

            public float VLeadK
            {
                get;
                set;
            }

            public float ALeadK
            {
                get;
                set;
            }

            public bool Fcw
            {
                get;
                set;
            }

            public bool Status
            {
                get;
                set;
            }

            public float ALeadTau
            {
                get;
                set;
            }

            public float ModelProb
            {
                get;
                set;
            }

            public bool Radar
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
                public float DRel => ctx.ReadDataFloat(0UL, 0F);
                public float YRel => ctx.ReadDataFloat(32UL, 0F);
                public float VRel => ctx.ReadDataFloat(64UL, 0F);
                public float ARel => ctx.ReadDataFloat(96UL, 0F);
                public float VLead => ctx.ReadDataFloat(128UL, 0F);
                public float ALeadDEPRECATED => ctx.ReadDataFloat(160UL, 0F);
                public float DPath => ctx.ReadDataFloat(192UL, 0F);
                public float VLat => ctx.ReadDataFloat(224UL, 0F);
                public float VLeadK => ctx.ReadDataFloat(256UL, 0F);
                public float ALeadK => ctx.ReadDataFloat(288UL, 0F);
                public bool Fcw => ctx.ReadDataBool(320UL, false);
                public bool Status => ctx.ReadDataBool(321UL, false);
                public float ALeadTau => ctx.ReadDataFloat(352UL, 0F);
                public float ModelProb => ctx.ReadDataFloat(384UL, 0F);
                public bool Radar => ctx.ReadDataBool(322UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(7, 0);
                }

                public float DRel
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float YRel
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float VRel
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float ARel
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float VLead
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float ALeadDEPRECATED
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float DPath
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public float VLat
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public float VLeadK
                {
                    get => this.ReadDataFloat(256UL, 0F);
                    set => this.WriteData(256UL, value, 0F);
                }

                public float ALeadK
                {
                    get => this.ReadDataFloat(288UL, 0F);
                    set => this.WriteData(288UL, value, 0F);
                }

                public bool Fcw
                {
                    get => this.ReadDataBool(320UL, false);
                    set => this.WriteData(320UL, value, false);
                }

                public bool Status
                {
                    get => this.ReadDataBool(321UL, false);
                    set => this.WriteData(321UL, value, false);
                }

                public float ALeadTau
                {
                    get => this.ReadDataFloat(352UL, 0F);
                    set => this.WriteData(352UL, value, 0F);
                }

                public float ModelProb
                {
                    get => this.ReadDataFloat(384UL, 0F);
                    set => this.WriteData(384UL, value, 0F);
                }

                public bool Radar
                {
                    get => this.ReadDataBool(322UL, false);
                    set => this.WriteData(322UL, value, false);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x96df70754d8390bcUL)]
    public class LiveCalibrationData : ICapnpSerializable
    {
        public const UInt64 typeId = 0x96df70754d8390bcUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            WarpMatrixDEPRECATED = reader.WarpMatrixDEPRECATED;
            CalStatus = reader.CalStatus;
            CalCycle = reader.CalCycle;
            CalPerc = reader.CalPerc;
            ExtrinsicMatrix = reader.ExtrinsicMatrix;
            WarpMatrix2DEPRECATED = reader.WarpMatrix2DEPRECATED;
            WarpMatrixBigDEPRECATED = reader.WarpMatrixBigDEPRECATED;
            RpyCalib = reader.RpyCalib;
            RpyCalibSpread = reader.RpyCalibSpread;
            ValidBlocks = reader.ValidBlocks;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.WarpMatrixDEPRECATED.Init(WarpMatrixDEPRECATED);
            writer.CalStatus = CalStatus;
            writer.CalCycle = CalCycle;
            writer.CalPerc = CalPerc;
            writer.ExtrinsicMatrix.Init(ExtrinsicMatrix);
            writer.WarpMatrix2DEPRECATED.Init(WarpMatrix2DEPRECATED);
            writer.WarpMatrixBigDEPRECATED.Init(WarpMatrixBigDEPRECATED);
            writer.RpyCalib.Init(RpyCalib);
            writer.RpyCalibSpread.Init(RpyCalibSpread);
            writer.ValidBlocks = ValidBlocks;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<float> WarpMatrixDEPRECATED
        {
            get;
            set;
        }

        public sbyte CalStatus
        {
            get;
            set;
        }

        public int CalCycle
        {
            get;
            set;
        }

        public sbyte CalPerc
        {
            get;
            set;
        }

        public IReadOnlyList<float> ExtrinsicMatrix
        {
            get;
            set;
        }

        public IReadOnlyList<float> WarpMatrix2DEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> WarpMatrixBigDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> RpyCalib
        {
            get;
            set;
        }

        public IReadOnlyList<float> RpyCalibSpread
        {
            get;
            set;
        }

        public int ValidBlocks
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
            public IReadOnlyList<float> WarpMatrixDEPRECATED => ctx.ReadList(0).CastFloat();
            public sbyte CalStatus => ctx.ReadDataSByte(0UL, (sbyte)0);
            public int CalCycle => ctx.ReadDataInt(32UL, 0);
            public sbyte CalPerc => ctx.ReadDataSByte(8UL, (sbyte)0);
            public IReadOnlyList<float> ExtrinsicMatrix => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<float> WarpMatrix2DEPRECATED => ctx.ReadList(2).CastFloat();
            public IReadOnlyList<float> WarpMatrixBigDEPRECATED => ctx.ReadList(3).CastFloat();
            public IReadOnlyList<float> RpyCalib => ctx.ReadList(4).CastFloat();
            public IReadOnlyList<float> RpyCalibSpread => ctx.ReadList(5).CastFloat();
            public int ValidBlocks => ctx.ReadDataInt(64UL, 0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 6);
            }

            public ListOfPrimitivesSerializer<float> WarpMatrixDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public sbyte CalStatus
            {
                get => this.ReadDataSByte(0UL, (sbyte)0);
                set => this.WriteData(0UL, value, (sbyte)0);
            }

            public int CalCycle
            {
                get => this.ReadDataInt(32UL, 0);
                set => this.WriteData(32UL, value, 0);
            }

            public sbyte CalPerc
            {
                get => this.ReadDataSByte(8UL, (sbyte)0);
                set => this.WriteData(8UL, value, (sbyte)0);
            }

            public ListOfPrimitivesSerializer<float> ExtrinsicMatrix
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> WarpMatrix2DEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public ListOfPrimitivesSerializer<float> WarpMatrixBigDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public ListOfPrimitivesSerializer<float> RpyCalib
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<float> RpyCalibSpread
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public int ValidBlocks
            {
                get => this.ReadDataInt(64UL, 0);
                set => this.WriteData(64UL, value, 0);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8faa644732dec251UL)]
    public class LiveTracks : ICapnpSerializable
    {
        public const UInt64 typeId = 0x8faa644732dec251UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            TrackId = reader.TrackId;
            DRel = reader.DRel;
            YRel = reader.YRel;
            VRel = reader.VRel;
            ARel = reader.ARel;
            TimeStamp = reader.TimeStamp;
            Status = reader.Status;
            CurrentTime = reader.CurrentTime;
            Stationary = reader.Stationary;
            Oncoming = reader.Oncoming;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.TrackId = TrackId;
            writer.DRel = DRel;
            writer.YRel = YRel;
            writer.VRel = VRel;
            writer.ARel = ARel;
            writer.TimeStamp = TimeStamp;
            writer.Status = Status;
            writer.CurrentTime = CurrentTime;
            writer.Stationary = Stationary;
            writer.Oncoming = Oncoming;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public int TrackId
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

        public float TimeStamp
        {
            get;
            set;
        }

        public float Status
        {
            get;
            set;
        }

        public float CurrentTime
        {
            get;
            set;
        }

        public bool Stationary
        {
            get;
            set;
        }

        public bool Oncoming
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
            public int TrackId => ctx.ReadDataInt(0UL, 0);
            public float DRel => ctx.ReadDataFloat(32UL, 0F);
            public float YRel => ctx.ReadDataFloat(64UL, 0F);
            public float VRel => ctx.ReadDataFloat(96UL, 0F);
            public float ARel => ctx.ReadDataFloat(128UL, 0F);
            public float TimeStamp => ctx.ReadDataFloat(160UL, 0F);
            public float Status => ctx.ReadDataFloat(192UL, 0F);
            public float CurrentTime => ctx.ReadDataFloat(224UL, 0F);
            public bool Stationary => ctx.ReadDataBool(256UL, false);
            public bool Oncoming => ctx.ReadDataBool(257UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(5, 0);
            }

            public int TrackId
            {
                get => this.ReadDataInt(0UL, 0);
                set => this.WriteData(0UL, value, 0);
            }

            public float DRel
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float YRel
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public float VRel
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public float ARel
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float TimeStamp
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public float Status
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public float CurrentTime
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public bool Stationary
            {
                get => this.ReadDataBool(256UL, false);
                set => this.WriteData(256UL, value, false);
            }

            public bool Oncoming
            {
                get => this.ReadDataBool(257UL, false);
                set => this.WriteData(257UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x97ff69c53601abf1UL)]
    public class ControlsState : ICapnpSerializable
    {
        public const UInt64 typeId = 0x97ff69c53601abf1UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            VEgoDEPRECATED = reader.VEgoDEPRECATED;
            AEgoDEPRECATED = reader.AEgoDEPRECATED;
            VPid = reader.VPid;
            VTargetLead = reader.VTargetLead;
            UpAccelCmd = reader.UpAccelCmd;
            UiAccelCmd = reader.UiAccelCmd;
            YActualDEPRECATED = reader.YActualDEPRECATED;
            YDesDEPRECATED = reader.YDesDEPRECATED;
            UpSteerDEPRECATED = reader.UpSteerDEPRECATED;
            UiSteerDEPRECATED = reader.UiSteerDEPRECATED;
            ATargetMinDEPRECATED = reader.ATargetMinDEPRECATED;
            ATargetMaxDEPRECATED = reader.ATargetMaxDEPRECATED;
            JerkFactorDEPRECATED = reader.JerkFactorDEPRECATED;
            AngleSteersDEPRECATED = reader.AngleSteersDEPRECATED;
            HudLeadDEPRECATED = reader.HudLeadDEPRECATED;
            CumLagMs = reader.CumLagMs;
            CanMonoTimeDEPRECATED = reader.CanMonoTimeDEPRECATED;
            RadarStateMonoTimeDEPRECATED = reader.RadarStateMonoTimeDEPRECATED;
            MdMonoTimeDEPRECATED = reader.MdMonoTimeDEPRECATED;
            Enabled = reader.Enabled;
            SteerOverrideDEPRECATED = reader.SteerOverrideDEPRECATED;
            CanMonoTimes = reader.CanMonoTimes;
            VCruise = reader.VCruise;
            RearViewCamDEPRECATED = reader.RearViewCamDEPRECATED;
            AlertText1 = reader.AlertText1;
            AlertText2 = reader.AlertText2;
            AwarenessStatusDEPRECATED = reader.AwarenessStatusDEPRECATED;
            AngleModelBiasDEPRECATED = reader.AngleModelBiasDEPRECATED;
            LongitudinalPlanMonoTime = reader.LongitudinalPlanMonoTime;
            SteeringAngleDesiredDegDEPRECATED = reader.SteeringAngleDesiredDegDEPRECATED;
            LongControlState = reader.LongControlState;
            State = reader.State;
            VEgoRawDEPRECATED = reader.VEgoRawDEPRECATED;
            UfAccelCmd = reader.UfAccelCmd;
            UfSteerDEPRECATED = reader.UfSteerDEPRECATED;
            ATarget = reader.ATarget;
            Active = reader.Active;
            Curvature = reader.Curvature;
            TheAlertStatus = reader.TheAlertStatus;
            TheAlertSize = reader.TheAlertSize;
            GpsPlannerActiveDEPRECATED = reader.GpsPlannerActiveDEPRECATED;
            Engageable = reader.Engageable;
            AlertBlinkingRate = reader.AlertBlinkingRate;
            DriverMonitoringOnDEPRECATED = reader.DriverMonitoringOnDEPRECATED;
            AlertType = reader.AlertType;
            AlertSoundDEPRECATED = reader.AlertSoundDEPRECATED;
            VCurvatureDEPRECATED = reader.VCurvatureDEPRECATED;
            DecelForTurnDEPRECATED = reader.DecelForTurnDEPRECATED;
            StartMonoTime = reader.StartMonoTime;
            MapValidDEPRECATED = reader.MapValidDEPRECATED;
            LateralPlanMonoTime = reader.LateralPlanMonoTime;
            ForceDecel = reader.ForceDecel;
            LateralControlState = CapnpSerializable.Create<Cereal.ControlsState.lateralControlState>(reader.LateralControlState);
            DecelForModelDEPRECATED = reader.DecelForModelDEPRECATED;
            AlertSound = reader.AlertSound;
            CanErrorCounter = reader.CanErrorCounter;
            Paused = reader.Paused;
            LkasEnabled = reader.LkasEnabled;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.VEgoDEPRECATED = VEgoDEPRECATED;
            writer.AEgoDEPRECATED = AEgoDEPRECATED;
            writer.VPid = VPid;
            writer.VTargetLead = VTargetLead;
            writer.UpAccelCmd = UpAccelCmd;
            writer.UiAccelCmd = UiAccelCmd;
            writer.YActualDEPRECATED = YActualDEPRECATED;
            writer.YDesDEPRECATED = YDesDEPRECATED;
            writer.UpSteerDEPRECATED = UpSteerDEPRECATED;
            writer.UiSteerDEPRECATED = UiSteerDEPRECATED;
            writer.ATargetMinDEPRECATED = ATargetMinDEPRECATED;
            writer.ATargetMaxDEPRECATED = ATargetMaxDEPRECATED;
            writer.JerkFactorDEPRECATED = JerkFactorDEPRECATED;
            writer.AngleSteersDEPRECATED = AngleSteersDEPRECATED;
            writer.HudLeadDEPRECATED = HudLeadDEPRECATED;
            writer.CumLagMs = CumLagMs;
            writer.CanMonoTimeDEPRECATED = CanMonoTimeDEPRECATED;
            writer.RadarStateMonoTimeDEPRECATED = RadarStateMonoTimeDEPRECATED;
            writer.MdMonoTimeDEPRECATED = MdMonoTimeDEPRECATED;
            writer.Enabled = Enabled;
            writer.SteerOverrideDEPRECATED = SteerOverrideDEPRECATED;
            writer.CanMonoTimes.Init(CanMonoTimes);
            writer.VCruise = VCruise;
            writer.RearViewCamDEPRECATED = RearViewCamDEPRECATED;
            writer.AlertText1 = AlertText1;
            writer.AlertText2 = AlertText2;
            writer.AwarenessStatusDEPRECATED = AwarenessStatusDEPRECATED;
            writer.AngleModelBiasDEPRECATED = AngleModelBiasDEPRECATED;
            writer.LongitudinalPlanMonoTime = LongitudinalPlanMonoTime;
            writer.SteeringAngleDesiredDegDEPRECATED = SteeringAngleDesiredDegDEPRECATED;
            writer.LongControlState = LongControlState;
            writer.State = State;
            writer.VEgoRawDEPRECATED = VEgoRawDEPRECATED;
            writer.UfAccelCmd = UfAccelCmd;
            writer.UfSteerDEPRECATED = UfSteerDEPRECATED;
            writer.ATarget = ATarget;
            writer.Active = Active;
            writer.Curvature = Curvature;
            writer.TheAlertStatus = TheAlertStatus;
            writer.TheAlertSize = TheAlertSize;
            writer.GpsPlannerActiveDEPRECATED = GpsPlannerActiveDEPRECATED;
            writer.Engageable = Engageable;
            writer.AlertBlinkingRate = AlertBlinkingRate;
            writer.DriverMonitoringOnDEPRECATED = DriverMonitoringOnDEPRECATED;
            writer.AlertType = AlertType;
            writer.AlertSoundDEPRECATED = AlertSoundDEPRECATED;
            writer.VCurvatureDEPRECATED = VCurvatureDEPRECATED;
            writer.DecelForTurnDEPRECATED = DecelForTurnDEPRECATED;
            writer.StartMonoTime = StartMonoTime;
            writer.MapValidDEPRECATED = MapValidDEPRECATED;
            writer.LateralPlanMonoTime = LateralPlanMonoTime;
            writer.ForceDecel = ForceDecel;
            LateralControlState?.serialize(writer.LateralControlState);
            writer.DecelForModelDEPRECATED = DecelForModelDEPRECATED;
            writer.AlertSound = AlertSound;
            writer.CanErrorCounter = CanErrorCounter;
            writer.Paused = Paused;
            writer.LkasEnabled = LkasEnabled;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public float VEgoDEPRECATED
        {
            get;
            set;
        }

        public float AEgoDEPRECATED
        {
            get;
            set;
        }

        public float VPid
        {
            get;
            set;
        }

        public float VTargetLead
        {
            get;
            set;
        }

        public float UpAccelCmd
        {
            get;
            set;
        }

        public float UiAccelCmd
        {
            get;
            set;
        }

        public float YActualDEPRECATED
        {
            get;
            set;
        }

        public float YDesDEPRECATED
        {
            get;
            set;
        }

        public float UpSteerDEPRECATED
        {
            get;
            set;
        }

        public float UiSteerDEPRECATED
        {
            get;
            set;
        }

        public float ATargetMinDEPRECATED
        {
            get;
            set;
        }

        public float ATargetMaxDEPRECATED
        {
            get;
            set;
        }

        public float JerkFactorDEPRECATED
        {
            get;
            set;
        }

        public float AngleSteersDEPRECATED
        {
            get;
            set;
        }

        public int HudLeadDEPRECATED
        {
            get;
            set;
        }

        public float CumLagMs
        {
            get;
            set;
        }

        public ulong CanMonoTimeDEPRECATED
        {
            get;
            set;
        }

        public ulong RadarStateMonoTimeDEPRECATED
        {
            get;
            set;
        }

        public ulong MdMonoTimeDEPRECATED
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        public bool SteerOverrideDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<ulong> CanMonoTimes
        {
            get;
            set;
        }

        public float VCruise
        {
            get;
            set;
        }

        public bool RearViewCamDEPRECATED
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

        public float AwarenessStatusDEPRECATED
        {
            get;
            set;
        }

        public float AngleModelBiasDEPRECATED
        {
            get;
            set;
        }

        public ulong LongitudinalPlanMonoTime
        {
            get;
            set;
        }

        public float SteeringAngleDesiredDegDEPRECATED
        {
            get;
            set;
        }

        public Cereal.CarControl.Actuators.LongControlState LongControlState
        {
            get;
            set;
        }

        public Cereal.ControlsState.OpenpilotState State
        {
            get;
            set;
        }

        public float VEgoRawDEPRECATED
        {
            get;
            set;
        }

        public float UfAccelCmd
        {
            get;
            set;
        }

        public float UfSteerDEPRECATED
        {
            get;
            set;
        }

        public float ATarget
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public float Curvature
        {
            get;
            set;
        }

        public Cereal.ControlsState.AlertStatus TheAlertStatus
        {
            get;
            set;
        }

        public Cereal.ControlsState.AlertSize TheAlertSize
        {
            get;
            set;
        }

        public bool GpsPlannerActiveDEPRECATED
        {
            get;
            set;
        }

        public bool Engageable
        {
            get;
            set;
        }

        public float AlertBlinkingRate
        {
            get;
            set;
        }

        public bool DriverMonitoringOnDEPRECATED
        {
            get;
            set;
        }

        public string AlertType
        {
            get;
            set;
        }

        public string AlertSoundDEPRECATED
        {
            get;
            set;
        }

        public float VCurvatureDEPRECATED
        {
            get;
            set;
        }

        public bool DecelForTurnDEPRECATED
        {
            get;
            set;
        }

        public ulong StartMonoTime
        {
            get;
            set;
        }

        public bool MapValidDEPRECATED
        {
            get;
            set;
        }

        public ulong LateralPlanMonoTime
        {
            get;
            set;
        }

        public bool ForceDecel
        {
            get;
            set;
        }

        public Cereal.ControlsState.lateralControlState LateralControlState
        {
            get;
            set;
        }

        public bool DecelForModelDEPRECATED
        {
            get;
            set;
        }

        public Cereal.CarControl.HUDControl.AudibleAlert AlertSound
        {
            get;
            set;
        }

        public uint CanErrorCounter
        {
            get;
            set;
        }

        public bool Paused
        {
            get;
            set;
        }

        public bool LkasEnabled
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
            public float VEgoDEPRECATED => ctx.ReadDataFloat(0UL, 0F);
            public float AEgoDEPRECATED => ctx.ReadDataFloat(32UL, 0F);
            public float VPid => ctx.ReadDataFloat(64UL, 0F);
            public float VTargetLead => ctx.ReadDataFloat(96UL, 0F);
            public float UpAccelCmd => ctx.ReadDataFloat(128UL, 0F);
            public float UiAccelCmd => ctx.ReadDataFloat(160UL, 0F);
            public float YActualDEPRECATED => ctx.ReadDataFloat(192UL, 0F);
            public float YDesDEPRECATED => ctx.ReadDataFloat(224UL, 0F);
            public float UpSteerDEPRECATED => ctx.ReadDataFloat(256UL, 0F);
            public float UiSteerDEPRECATED => ctx.ReadDataFloat(288UL, 0F);
            public float ATargetMinDEPRECATED => ctx.ReadDataFloat(320UL, 0F);
            public float ATargetMaxDEPRECATED => ctx.ReadDataFloat(352UL, 0F);
            public float JerkFactorDEPRECATED => ctx.ReadDataFloat(384UL, 0F);
            public float AngleSteersDEPRECATED => ctx.ReadDataFloat(416UL, 0F);
            public int HudLeadDEPRECATED => ctx.ReadDataInt(448UL, 0);
            public float CumLagMs => ctx.ReadDataFloat(480UL, 0F);
            public ulong CanMonoTimeDEPRECATED => ctx.ReadDataULong(512UL, 0UL);
            public ulong RadarStateMonoTimeDEPRECATED => ctx.ReadDataULong(576UL, 0UL);
            public ulong MdMonoTimeDEPRECATED => ctx.ReadDataULong(640UL, 0UL);
            public bool Enabled => ctx.ReadDataBool(704UL, false);
            public bool SteerOverrideDEPRECATED => ctx.ReadDataBool(705UL, false);
            public IReadOnlyList<ulong> CanMonoTimes => ctx.ReadList(0).CastULong();
            public float VCruise => ctx.ReadDataFloat(736UL, 0F);
            public bool RearViewCamDEPRECATED => ctx.ReadDataBool(706UL, false);
            public string AlertText1 => ctx.ReadText(1, null);
            public string AlertText2 => ctx.ReadText(2, null);
            public float AwarenessStatusDEPRECATED => ctx.ReadDataFloat(768UL, 0F);
            public float AngleModelBiasDEPRECATED => ctx.ReadDataFloat(800UL, 0F);
            public ulong LongitudinalPlanMonoTime => ctx.ReadDataULong(832UL, 0UL);
            public float SteeringAngleDesiredDegDEPRECATED => ctx.ReadDataFloat(896UL, 0F);
            public Cereal.CarControl.Actuators.LongControlState LongControlState => (Cereal.CarControl.Actuators.LongControlState)ctx.ReadDataUShort(720UL, (ushort)0);
            public Cereal.ControlsState.OpenpilotState State => (Cereal.ControlsState.OpenpilotState)ctx.ReadDataUShort(928UL, (ushort)0);
            public float VEgoRawDEPRECATED => ctx.ReadDataFloat(960UL, 0F);
            public float UfAccelCmd => ctx.ReadDataFloat(992UL, 0F);
            public float UfSteerDEPRECATED => ctx.ReadDataFloat(1024UL, 0F);
            public float ATarget => ctx.ReadDataFloat(1056UL, 0F);
            public bool Active => ctx.ReadDataBool(707UL, false);
            public float Curvature => ctx.ReadDataFloat(1088UL, 0F);
            public Cereal.ControlsState.AlertStatus TheAlertStatus => (Cereal.ControlsState.AlertStatus)ctx.ReadDataUShort(944UL, (ushort)0);
            public Cereal.ControlsState.AlertSize TheAlertSize => (Cereal.ControlsState.AlertSize)ctx.ReadDataUShort(1120UL, (ushort)0);
            public bool GpsPlannerActiveDEPRECATED => ctx.ReadDataBool(708UL, false);
            public bool Engageable => ctx.ReadDataBool(709UL, false);
            public float AlertBlinkingRate => ctx.ReadDataFloat(1152UL, 0F);
            public bool DriverMonitoringOnDEPRECATED => ctx.ReadDataBool(710UL, false);
            public string AlertType => ctx.ReadText(3, null);
            public string AlertSoundDEPRECATED => ctx.ReadText(4, null);
            public float VCurvatureDEPRECATED => ctx.ReadDataFloat(1184UL, 0F);
            public bool DecelForTurnDEPRECATED => ctx.ReadDataBool(711UL, false);
            public ulong StartMonoTime => ctx.ReadDataULong(1216UL, 0UL);
            public bool MapValidDEPRECATED => ctx.ReadDataBool(712UL, false);
            public ulong LateralPlanMonoTime => ctx.ReadDataULong(1280UL, 0UL);
            public bool ForceDecel => ctx.ReadDataBool(713UL, false);
            public lateralControlState.READER LateralControlState => new lateralControlState.READER(ctx);
            public bool DecelForModelDEPRECATED => ctx.ReadDataBool(714UL, false);
            public Cereal.CarControl.HUDControl.AudibleAlert AlertSound => (Cereal.CarControl.HUDControl.AudibleAlert)ctx.ReadDataUShort(1344UL, (ushort)0);
            public uint CanErrorCounter => ctx.ReadDataUInt(1376UL, 0U);
            public bool Paused => ctx.ReadDataBool(715UL, false);
            public bool LkasEnabled => ctx.ReadDataBool(716UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(22, 6);
            }

            public float VEgoDEPRECATED
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }

            public float AEgoDEPRECATED
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float VPid
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public float VTargetLead
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public float UpAccelCmd
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float UiAccelCmd
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public float YActualDEPRECATED
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public float YDesDEPRECATED
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public float UpSteerDEPRECATED
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }

            public float UiSteerDEPRECATED
            {
                get => this.ReadDataFloat(288UL, 0F);
                set => this.WriteData(288UL, value, 0F);
            }

            public float ATargetMinDEPRECATED
            {
                get => this.ReadDataFloat(320UL, 0F);
                set => this.WriteData(320UL, value, 0F);
            }

            public float ATargetMaxDEPRECATED
            {
                get => this.ReadDataFloat(352UL, 0F);
                set => this.WriteData(352UL, value, 0F);
            }

            public float JerkFactorDEPRECATED
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }

            public float AngleSteersDEPRECATED
            {
                get => this.ReadDataFloat(416UL, 0F);
                set => this.WriteData(416UL, value, 0F);
            }

            public int HudLeadDEPRECATED
            {
                get => this.ReadDataInt(448UL, 0);
                set => this.WriteData(448UL, value, 0);
            }

            public float CumLagMs
            {
                get => this.ReadDataFloat(480UL, 0F);
                set => this.WriteData(480UL, value, 0F);
            }

            public ulong CanMonoTimeDEPRECATED
            {
                get => this.ReadDataULong(512UL, 0UL);
                set => this.WriteData(512UL, value, 0UL);
            }

            public ulong RadarStateMonoTimeDEPRECATED
            {
                get => this.ReadDataULong(576UL, 0UL);
                set => this.WriteData(576UL, value, 0UL);
            }

            public ulong MdMonoTimeDEPRECATED
            {
                get => this.ReadDataULong(640UL, 0UL);
                set => this.WriteData(640UL, value, 0UL);
            }

            public bool Enabled
            {
                get => this.ReadDataBool(704UL, false);
                set => this.WriteData(704UL, value, false);
            }

            public bool SteerOverrideDEPRECATED
            {
                get => this.ReadDataBool(705UL, false);
                set => this.WriteData(705UL, value, false);
            }

            public ListOfPrimitivesSerializer<ulong> CanMonoTimes
            {
                get => BuildPointer<ListOfPrimitivesSerializer<ulong>>(0);
                set => Link(0, value);
            }

            public float VCruise
            {
                get => this.ReadDataFloat(736UL, 0F);
                set => this.WriteData(736UL, value, 0F);
            }

            public bool RearViewCamDEPRECATED
            {
                get => this.ReadDataBool(706UL, false);
                set => this.WriteData(706UL, value, false);
            }

            public string AlertText1
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public string AlertText2
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public float AwarenessStatusDEPRECATED
            {
                get => this.ReadDataFloat(768UL, 0F);
                set => this.WriteData(768UL, value, 0F);
            }

            public float AngleModelBiasDEPRECATED
            {
                get => this.ReadDataFloat(800UL, 0F);
                set => this.WriteData(800UL, value, 0F);
            }

            public ulong LongitudinalPlanMonoTime
            {
                get => this.ReadDataULong(832UL, 0UL);
                set => this.WriteData(832UL, value, 0UL);
            }

            public float SteeringAngleDesiredDegDEPRECATED
            {
                get => this.ReadDataFloat(896UL, 0F);
                set => this.WriteData(896UL, value, 0F);
            }

            public Cereal.CarControl.Actuators.LongControlState LongControlState
            {
                get => (Cereal.CarControl.Actuators.LongControlState)this.ReadDataUShort(720UL, (ushort)0);
                set => this.WriteData(720UL, (ushort)value, (ushort)0);
            }

            public Cereal.ControlsState.OpenpilotState State
            {
                get => (Cereal.ControlsState.OpenpilotState)this.ReadDataUShort(928UL, (ushort)0);
                set => this.WriteData(928UL, (ushort)value, (ushort)0);
            }

            public float VEgoRawDEPRECATED
            {
                get => this.ReadDataFloat(960UL, 0F);
                set => this.WriteData(960UL, value, 0F);
            }

            public float UfAccelCmd
            {
                get => this.ReadDataFloat(992UL, 0F);
                set => this.WriteData(992UL, value, 0F);
            }

            public float UfSteerDEPRECATED
            {
                get => this.ReadDataFloat(1024UL, 0F);
                set => this.WriteData(1024UL, value, 0F);
            }

            public float ATarget
            {
                get => this.ReadDataFloat(1056UL, 0F);
                set => this.WriteData(1056UL, value, 0F);
            }

            public bool Active
            {
                get => this.ReadDataBool(707UL, false);
                set => this.WriteData(707UL, value, false);
            }

            public float Curvature
            {
                get => this.ReadDataFloat(1088UL, 0F);
                set => this.WriteData(1088UL, value, 0F);
            }

            public Cereal.ControlsState.AlertStatus TheAlertStatus
            {
                get => (Cereal.ControlsState.AlertStatus)this.ReadDataUShort(944UL, (ushort)0);
                set => this.WriteData(944UL, (ushort)value, (ushort)0);
            }

            public Cereal.ControlsState.AlertSize TheAlertSize
            {
                get => (Cereal.ControlsState.AlertSize)this.ReadDataUShort(1120UL, (ushort)0);
                set => this.WriteData(1120UL, (ushort)value, (ushort)0);
            }

            public bool GpsPlannerActiveDEPRECATED
            {
                get => this.ReadDataBool(708UL, false);
                set => this.WriteData(708UL, value, false);
            }

            public bool Engageable
            {
                get => this.ReadDataBool(709UL, false);
                set => this.WriteData(709UL, value, false);
            }

            public float AlertBlinkingRate
            {
                get => this.ReadDataFloat(1152UL, 0F);
                set => this.WriteData(1152UL, value, 0F);
            }

            public bool DriverMonitoringOnDEPRECATED
            {
                get => this.ReadDataBool(710UL, false);
                set => this.WriteData(710UL, value, false);
            }

            public string AlertType
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public string AlertSoundDEPRECATED
            {
                get => this.ReadText(4, null);
                set => this.WriteText(4, value, null);
            }

            public float VCurvatureDEPRECATED
            {
                get => this.ReadDataFloat(1184UL, 0F);
                set => this.WriteData(1184UL, value, 0F);
            }

            public bool DecelForTurnDEPRECATED
            {
                get => this.ReadDataBool(711UL, false);
                set => this.WriteData(711UL, value, false);
            }

            public ulong StartMonoTime
            {
                get => this.ReadDataULong(1216UL, 0UL);
                set => this.WriteData(1216UL, value, 0UL);
            }

            public bool MapValidDEPRECATED
            {
                get => this.ReadDataBool(712UL, false);
                set => this.WriteData(712UL, value, false);
            }

            public ulong LateralPlanMonoTime
            {
                get => this.ReadDataULong(1280UL, 0UL);
                set => this.WriteData(1280UL, value, 0UL);
            }

            public bool ForceDecel
            {
                get => this.ReadDataBool(713UL, false);
                set => this.WriteData(713UL, value, false);
            }

            public lateralControlState.WRITER LateralControlState
            {
                get => Rewrap<lateralControlState.WRITER>();
            }

            public bool DecelForModelDEPRECATED
            {
                get => this.ReadDataBool(714UL, false);
                set => this.WriteData(714UL, value, false);
            }

            public Cereal.CarControl.HUDControl.AudibleAlert AlertSound
            {
                get => (Cereal.CarControl.HUDControl.AudibleAlert)this.ReadDataUShort(1344UL, (ushort)0);
                set => this.WriteData(1344UL, (ushort)value, (ushort)0);
            }

            public uint CanErrorCounter
            {
                get => this.ReadDataUInt(1376UL, 0U);
                set => this.WriteData(1376UL, value, 0U);
            }

            public bool Paused
            {
                get => this.ReadDataBool(715UL, false);
                set => this.WriteData(715UL, value, false);
            }

            public bool LkasEnabled
            {
                get => this.ReadDataBool(716UL, false);
                set => this.WriteData(716UL, value, false);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfd5b914d6b444695UL)]
        public class lateralControlState : ICapnpSerializable
        {
            public const UInt64 typeId = 0xfd5b914d6b444695UL;
            public enum WHICH : ushort
            {
                IndiState = 0,
                PidState = 1,
                LqrState = 2,
                AngleState = 3,
                DebugState = 4,
                undefined = 65535
            }

            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                switch (reader.which)
                {
                    case WHICH.IndiState:
                        IndiState = CapnpSerializable.Create<Cereal.ControlsState.LateralINDIState>(reader.IndiState);
                        break;
                    case WHICH.PidState:
                        PidState = CapnpSerializable.Create<Cereal.ControlsState.LateralPIDState>(reader.PidState);
                        break;
                    case WHICH.LqrState:
                        LqrState = CapnpSerializable.Create<Cereal.ControlsState.LateralLQRState>(reader.LqrState);
                        break;
                    case WHICH.AngleState:
                        AngleState = CapnpSerializable.Create<Cereal.ControlsState.LateralAngleState>(reader.AngleState);
                        break;
                    case WHICH.DebugState:
                        DebugState = CapnpSerializable.Create<Cereal.ControlsState.LateralDebugState>(reader.DebugState);
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
                        case WHICH.IndiState:
                            _content = null;
                            break;
                        case WHICH.PidState:
                            _content = null;
                            break;
                        case WHICH.LqrState:
                            _content = null;
                            break;
                        case WHICH.AngleState:
                            _content = null;
                            break;
                        case WHICH.DebugState:
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
                    case WHICH.IndiState:
                        IndiState?.serialize(writer.IndiState);
                        break;
                    case WHICH.PidState:
                        PidState?.serialize(writer.PidState);
                        break;
                    case WHICH.LqrState:
                        LqrState?.serialize(writer.LqrState);
                        break;
                    case WHICH.AngleState:
                        AngleState?.serialize(writer.AngleState);
                        break;
                    case WHICH.DebugState:
                        DebugState?.serialize(writer.DebugState);
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

            public Cereal.ControlsState.LateralINDIState IndiState
            {
                get => _which == WHICH.IndiState ? (Cereal.ControlsState.LateralINDIState)_content : null;
                set
                {
                    _which = WHICH.IndiState;
                    _content = value;
                }
            }

            public Cereal.ControlsState.LateralPIDState PidState
            {
                get => _which == WHICH.PidState ? (Cereal.ControlsState.LateralPIDState)_content : null;
                set
                {
                    _which = WHICH.PidState;
                    _content = value;
                }
            }

            public Cereal.ControlsState.LateralLQRState LqrState
            {
                get => _which == WHICH.LqrState ? (Cereal.ControlsState.LateralLQRState)_content : null;
                set
                {
                    _which = WHICH.LqrState;
                    _content = value;
                }
            }

            public Cereal.ControlsState.LateralAngleState AngleState
            {
                get => _which == WHICH.AngleState ? (Cereal.ControlsState.LateralAngleState)_content : null;
                set
                {
                    _which = WHICH.AngleState;
                    _content = value;
                }
            }

            public Cereal.ControlsState.LateralDebugState DebugState
            {
                get => _which == WHICH.DebugState ? (Cereal.ControlsState.LateralDebugState)_content : null;
                set
                {
                    _which = WHICH.DebugState;
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
                public WHICH which => (WHICH)ctx.ReadDataUShort(1136U, (ushort)0);
                public Cereal.ControlsState.LateralINDIState.READER IndiState => which == WHICH.IndiState ? ctx.ReadStruct(5, Cereal.ControlsState.LateralINDIState.READER.create) : default;
                public Cereal.ControlsState.LateralPIDState.READER PidState => which == WHICH.PidState ? ctx.ReadStruct(5, Cereal.ControlsState.LateralPIDState.READER.create) : default;
                public Cereal.ControlsState.LateralLQRState.READER LqrState => which == WHICH.LqrState ? ctx.ReadStruct(5, Cereal.ControlsState.LateralLQRState.READER.create) : default;
                public Cereal.ControlsState.LateralAngleState.READER AngleState => which == WHICH.AngleState ? ctx.ReadStruct(5, Cereal.ControlsState.LateralAngleState.READER.create) : default;
                public Cereal.ControlsState.LateralDebugState.READER DebugState => which == WHICH.DebugState ? ctx.ReadStruct(5, Cereal.ControlsState.LateralDebugState.READER.create) : default;
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                }

                public WHICH which
                {
                    get => (WHICH)this.ReadDataUShort(1136U, (ushort)0);
                    set => this.WriteData(1136U, (ushort)value, (ushort)0);
                }

                public Cereal.ControlsState.LateralINDIState.WRITER IndiState
                {
                    get => which == WHICH.IndiState ? BuildPointer<Cereal.ControlsState.LateralINDIState.WRITER>(5) : default;
                    set => Link(5, value);
                }

                public Cereal.ControlsState.LateralPIDState.WRITER PidState
                {
                    get => which == WHICH.PidState ? BuildPointer<Cereal.ControlsState.LateralPIDState.WRITER>(5) : default;
                    set => Link(5, value);
                }

                public Cereal.ControlsState.LateralLQRState.WRITER LqrState
                {
                    get => which == WHICH.LqrState ? BuildPointer<Cereal.ControlsState.LateralLQRState.WRITER>(5) : default;
                    set => Link(5, value);
                }

                public Cereal.ControlsState.LateralAngleState.WRITER AngleState
                {
                    get => which == WHICH.AngleState ? BuildPointer<Cereal.ControlsState.LateralAngleState.WRITER>(5) : default;
                    set => Link(5, value);
                }

                public Cereal.ControlsState.LateralDebugState.WRITER DebugState
                {
                    get => which == WHICH.DebugState ? BuildPointer<Cereal.ControlsState.LateralDebugState.WRITER>(5) : default;
                    set => Link(5, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xdbe58b96d2d1ac61UL)]
        public enum OpenpilotState : ushort
        {
            disabled,
            preEnabled,
            enabled,
            softDisabling
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa0d0dcd113193c62UL)]
        public enum AlertStatus : ushort
        {
            normal,
            userPrompt,
            critical
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe98bb99d6e985f64UL)]
        public enum AlertSize : ushort
        {
            none,
            small,
            mid,
            full
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x939463348632375eUL)]
        public class LateralINDIState : ICapnpSerializable
        {
            public const UInt64 typeId = 0x939463348632375eUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Active = reader.Active;
                SteeringAngleDeg = reader.SteeringAngleDeg;
                SteeringRateDeg = reader.SteeringRateDeg;
                SteeringAccelDeg = reader.SteeringAccelDeg;
                RateSetPoint = reader.RateSetPoint;
                AccelSetPoint = reader.AccelSetPoint;
                AccelError = reader.AccelError;
                DelayedOutput = reader.DelayedOutput;
                Delta = reader.Delta;
                Output = reader.Output;
                Saturated = reader.Saturated;
                SteeringAngleDesiredDeg = reader.SteeringAngleDesiredDeg;
                SteeringRateDesiredDeg = reader.SteeringRateDesiredDeg;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Active = Active;
                writer.SteeringAngleDeg = SteeringAngleDeg;
                writer.SteeringRateDeg = SteeringRateDeg;
                writer.SteeringAccelDeg = SteeringAccelDeg;
                writer.RateSetPoint = RateSetPoint;
                writer.AccelSetPoint = AccelSetPoint;
                writer.AccelError = AccelError;
                writer.DelayedOutput = DelayedOutput;
                writer.Delta = Delta;
                writer.Output = Output;
                writer.Saturated = Saturated;
                writer.SteeringAngleDesiredDeg = SteeringAngleDesiredDeg;
                writer.SteeringRateDesiredDeg = SteeringRateDesiredDeg;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool Active
            {
                get;
                set;
            }

            public float SteeringAngleDeg
            {
                get;
                set;
            }

            public float SteeringRateDeg
            {
                get;
                set;
            }

            public float SteeringAccelDeg
            {
                get;
                set;
            }

            public float RateSetPoint
            {
                get;
                set;
            }

            public float AccelSetPoint
            {
                get;
                set;
            }

            public float AccelError
            {
                get;
                set;
            }

            public float DelayedOutput
            {
                get;
                set;
            }

            public float Delta
            {
                get;
                set;
            }

            public float Output
            {
                get;
                set;
            }

            public bool Saturated
            {
                get;
                set;
            }

            public float SteeringAngleDesiredDeg
            {
                get;
                set;
            }

            public float SteeringRateDesiredDeg
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
                public bool Active => ctx.ReadDataBool(0UL, false);
                public float SteeringAngleDeg => ctx.ReadDataFloat(32UL, 0F);
                public float SteeringRateDeg => ctx.ReadDataFloat(64UL, 0F);
                public float SteeringAccelDeg => ctx.ReadDataFloat(96UL, 0F);
                public float RateSetPoint => ctx.ReadDataFloat(128UL, 0F);
                public float AccelSetPoint => ctx.ReadDataFloat(160UL, 0F);
                public float AccelError => ctx.ReadDataFloat(192UL, 0F);
                public float DelayedOutput => ctx.ReadDataFloat(224UL, 0F);
                public float Delta => ctx.ReadDataFloat(256UL, 0F);
                public float Output => ctx.ReadDataFloat(288UL, 0F);
                public bool Saturated => ctx.ReadDataBool(1UL, false);
                public float SteeringAngleDesiredDeg => ctx.ReadDataFloat(320UL, 0F);
                public float SteeringRateDesiredDeg => ctx.ReadDataFloat(352UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(6, 0);
                }

                public bool Active
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public float SteeringAngleDeg
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float SteeringRateDeg
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float SteeringAccelDeg
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float RateSetPoint
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float AccelSetPoint
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float AccelError
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public float DelayedOutput
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public float Delta
                {
                    get => this.ReadDataFloat(256UL, 0F);
                    set => this.WriteData(256UL, value, 0F);
                }

                public float Output
                {
                    get => this.ReadDataFloat(288UL, 0F);
                    set => this.WriteData(288UL, value, 0F);
                }

                public bool Saturated
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public float SteeringAngleDesiredDeg
                {
                    get => this.ReadDataFloat(320UL, 0F);
                    set => this.WriteData(320UL, value, 0F);
                }

                public float SteeringRateDesiredDeg
                {
                    get => this.ReadDataFloat(352UL, 0F);
                    set => this.WriteData(352UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf28c5dc9e09375e3UL)]
        public class LateralPIDState : ICapnpSerializable
        {
            public const UInt64 typeId = 0xf28c5dc9e09375e3UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Active = reader.Active;
                SteeringAngleDeg = reader.SteeringAngleDeg;
                SteeringRateDeg = reader.SteeringRateDeg;
                AngleError = reader.AngleError;
                P = reader.P;
                I = reader.I;
                F = reader.F;
                Output = reader.Output;
                Saturated = reader.Saturated;
                SteeringAngleDesiredDeg = reader.SteeringAngleDesiredDeg;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Active = Active;
                writer.SteeringAngleDeg = SteeringAngleDeg;
                writer.SteeringRateDeg = SteeringRateDeg;
                writer.AngleError = AngleError;
                writer.P = P;
                writer.I = I;
                writer.F = F;
                writer.Output = Output;
                writer.Saturated = Saturated;
                writer.SteeringAngleDesiredDeg = SteeringAngleDesiredDeg;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool Active
            {
                get;
                set;
            }

            public float SteeringAngleDeg
            {
                get;
                set;
            }

            public float SteeringRateDeg
            {
                get;
                set;
            }

            public float AngleError
            {
                get;
                set;
            }

            public float P
            {
                get;
                set;
            }

            public float I
            {
                get;
                set;
            }

            public float F
            {
                get;
                set;
            }

            public float Output
            {
                get;
                set;
            }

            public bool Saturated
            {
                get;
                set;
            }

            public float SteeringAngleDesiredDeg
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
                public bool Active => ctx.ReadDataBool(0UL, false);
                public float SteeringAngleDeg => ctx.ReadDataFloat(32UL, 0F);
                public float SteeringRateDeg => ctx.ReadDataFloat(64UL, 0F);
                public float AngleError => ctx.ReadDataFloat(96UL, 0F);
                public float P => ctx.ReadDataFloat(128UL, 0F);
                public float I => ctx.ReadDataFloat(160UL, 0F);
                public float F => ctx.ReadDataFloat(192UL, 0F);
                public float Output => ctx.ReadDataFloat(224UL, 0F);
                public bool Saturated => ctx.ReadDataBool(1UL, false);
                public float SteeringAngleDesiredDeg => ctx.ReadDataFloat(256UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(5, 0);
                }

                public bool Active
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public float SteeringAngleDeg
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float SteeringRateDeg
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float AngleError
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float P
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float I
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float F
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public float Output
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public bool Saturated
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public float SteeringAngleDesiredDeg
                {
                    get => this.ReadDataFloat(256UL, 0F);
                    set => this.WriteData(256UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x9024e2d790c82adeUL)]
        public class LateralLQRState : ICapnpSerializable
        {
            public const UInt64 typeId = 0x9024e2d790c82adeUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Active = reader.Active;
                SteeringAngleDeg = reader.SteeringAngleDeg;
                I = reader.I;
                Output = reader.Output;
                LqrOutput = reader.LqrOutput;
                Saturated = reader.Saturated;
                SteeringAngleDesiredDeg = reader.SteeringAngleDesiredDeg;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Active = Active;
                writer.SteeringAngleDeg = SteeringAngleDeg;
                writer.I = I;
                writer.Output = Output;
                writer.LqrOutput = LqrOutput;
                writer.Saturated = Saturated;
                writer.SteeringAngleDesiredDeg = SteeringAngleDesiredDeg;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool Active
            {
                get;
                set;
            }

            public float SteeringAngleDeg
            {
                get;
                set;
            }

            public float I
            {
                get;
                set;
            }

            public float Output
            {
                get;
                set;
            }

            public float LqrOutput
            {
                get;
                set;
            }

            public bool Saturated
            {
                get;
                set;
            }

            public float SteeringAngleDesiredDeg
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
                public bool Active => ctx.ReadDataBool(0UL, false);
                public float SteeringAngleDeg => ctx.ReadDataFloat(32UL, 0F);
                public float I => ctx.ReadDataFloat(64UL, 0F);
                public float Output => ctx.ReadDataFloat(96UL, 0F);
                public float LqrOutput => ctx.ReadDataFloat(128UL, 0F);
                public bool Saturated => ctx.ReadDataBool(1UL, false);
                public float SteeringAngleDesiredDeg => ctx.ReadDataFloat(160UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(3, 0);
                }

                public bool Active
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public float SteeringAngleDeg
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float I
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float Output
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float LqrOutput
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public bool Saturated
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public float SteeringAngleDesiredDeg
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa2e4ea88ac9980f1UL)]
        public class LateralAngleState : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa2e4ea88ac9980f1UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Active = reader.Active;
                SteeringAngleDeg = reader.SteeringAngleDeg;
                Output = reader.Output;
                Saturated = reader.Saturated;
                SteeringAngleDesiredDeg = reader.SteeringAngleDesiredDeg;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Active = Active;
                writer.SteeringAngleDeg = SteeringAngleDeg;
                writer.Output = Output;
                writer.Saturated = Saturated;
                writer.SteeringAngleDesiredDeg = SteeringAngleDesiredDeg;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool Active
            {
                get;
                set;
            }

            public float SteeringAngleDeg
            {
                get;
                set;
            }

            public float Output
            {
                get;
                set;
            }

            public bool Saturated
            {
                get;
                set;
            }

            public float SteeringAngleDesiredDeg
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
                public bool Active => ctx.ReadDataBool(0UL, false);
                public float SteeringAngleDeg => ctx.ReadDataFloat(32UL, 0F);
                public float Output => ctx.ReadDataFloat(64UL, 0F);
                public bool Saturated => ctx.ReadDataBool(1UL, false);
                public float SteeringAngleDesiredDeg => ctx.ReadDataFloat(96UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public bool Active
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public float SteeringAngleDeg
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float Output
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public bool Saturated
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }

                public float SteeringAngleDesiredDeg
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa63a46f0f2889b2dUL)]
        public class LateralDebugState : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa63a46f0f2889b2dUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Active = reader.Active;
                SteeringAngleDeg = reader.SteeringAngleDeg;
                Output = reader.Output;
                Saturated = reader.Saturated;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Active = Active;
                writer.SteeringAngleDeg = SteeringAngleDeg;
                writer.Output = Output;
                writer.Saturated = Saturated;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public bool Active
            {
                get;
                set;
            }

            public float SteeringAngleDeg
            {
                get;
                set;
            }

            public float Output
            {
                get;
                set;
            }

            public bool Saturated
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
                public bool Active => ctx.ReadDataBool(0UL, false);
                public float SteeringAngleDeg => ctx.ReadDataFloat(32UL, 0F);
                public float Output => ctx.ReadDataFloat(64UL, 0F);
                public bool Saturated => ctx.ReadDataBool(1UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public bool Active
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public float SteeringAngleDeg
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float Output
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public bool Saturated
                {
                    get => this.ReadDataBool(1UL, false);
                    set => this.WriteData(1UL, value, false);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc4713f6b0d36abe9UL)]
    public class ModelDataV2 : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc4713f6b0d36abe9UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            FrameId = reader.FrameId;
            FrameAge = reader.FrameAge;
            FrameDropPerc = reader.FrameDropPerc;
            TimestampEof = reader.TimestampEof;
            Position = CapnpSerializable.Create<Cereal.ModelDataV2.XYZTData>(reader.Position);
            Orientation = CapnpSerializable.Create<Cereal.ModelDataV2.XYZTData>(reader.Orientation);
            Velocity = CapnpSerializable.Create<Cereal.ModelDataV2.XYZTData>(reader.Velocity);
            OrientationRate = CapnpSerializable.Create<Cereal.ModelDataV2.XYZTData>(reader.OrientationRate);
            LaneLines = reader.LaneLines?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ModelDataV2.XYZTData>(_));
            LaneLineProbs = reader.LaneLineProbs;
            RoadEdges = reader.RoadEdges?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ModelDataV2.XYZTData>(_));
            Leads = reader.Leads?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ModelDataV2.LeadDataV2>(_));
            Meta = CapnpSerializable.Create<Cereal.ModelDataV2.MetaData>(reader.Meta);
            LaneLineStds = reader.LaneLineStds;
            RoadEdgeStds = reader.RoadEdgeStds;
            ModelExecutionTime = reader.ModelExecutionTime;
            RawPredictions = reader.RawPredictions;
            GpuExecutionTime = reader.GpuExecutionTime;
            LeadsV3 = reader.LeadsV3?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ModelDataV2.LeadDataV3>(_));
            Acceleration = CapnpSerializable.Create<Cereal.ModelDataV2.XYZTData>(reader.Acceleration);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.FrameId = FrameId;
            writer.FrameAge = FrameAge;
            writer.FrameDropPerc = FrameDropPerc;
            writer.TimestampEof = TimestampEof;
            Position?.serialize(writer.Position);
            Orientation?.serialize(writer.Orientation);
            Velocity?.serialize(writer.Velocity);
            OrientationRate?.serialize(writer.OrientationRate);
            writer.LaneLines.Init(LaneLines, (_s1, _v1) => _v1?.serialize(_s1));
            writer.LaneLineProbs.Init(LaneLineProbs);
            writer.RoadEdges.Init(RoadEdges, (_s1, _v1) => _v1?.serialize(_s1));
            writer.Leads.Init(Leads, (_s1, _v1) => _v1?.serialize(_s1));
            Meta?.serialize(writer.Meta);
            writer.LaneLineStds.Init(LaneLineStds);
            writer.RoadEdgeStds.Init(RoadEdgeStds);
            writer.ModelExecutionTime = ModelExecutionTime;
            writer.RawPredictions.Init(RawPredictions);
            writer.GpuExecutionTime = GpuExecutionTime;
            writer.LeadsV3.Init(LeadsV3, (_s1, _v1) => _v1?.serialize(_s1));
            Acceleration?.serialize(writer.Acceleration);
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

        public ulong TimestampEof
        {
            get;
            set;
        }

        public Cereal.ModelDataV2.XYZTData Position
        {
            get;
            set;
        }

        public Cereal.ModelDataV2.XYZTData Orientation
        {
            get;
            set;
        }

        public Cereal.ModelDataV2.XYZTData Velocity
        {
            get;
            set;
        }

        public Cereal.ModelDataV2.XYZTData OrientationRate
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ModelDataV2.XYZTData> LaneLines
        {
            get;
            set;
        }

        public IReadOnlyList<float> LaneLineProbs
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ModelDataV2.XYZTData> RoadEdges
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ModelDataV2.LeadDataV2> Leads
        {
            get;
            set;
        }

        public Cereal.ModelDataV2.MetaData Meta
        {
            get;
            set;
        }

        public IReadOnlyList<float> LaneLineStds
        {
            get;
            set;
        }

        public IReadOnlyList<float> RoadEdgeStds
        {
            get;
            set;
        }

        public float ModelExecutionTime
        {
            get;
            set;
        }

        public IReadOnlyList<byte> RawPredictions
        {
            get;
            set;
        }

        public float GpuExecutionTime
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ModelDataV2.LeadDataV3> LeadsV3
        {
            get;
            set;
        }

        public Cereal.ModelDataV2.XYZTData Acceleration
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
            public uint FrameAge => ctx.ReadDataUInt(32UL, 0U);
            public float FrameDropPerc => ctx.ReadDataFloat(64UL, 0F);
            public ulong TimestampEof => ctx.ReadDataULong(128UL, 0UL);
            public Cereal.ModelDataV2.XYZTData.READER Position => ctx.ReadStruct(0, Cereal.ModelDataV2.XYZTData.READER.create);
            public Cereal.ModelDataV2.XYZTData.READER Orientation => ctx.ReadStruct(1, Cereal.ModelDataV2.XYZTData.READER.create);
            public Cereal.ModelDataV2.XYZTData.READER Velocity => ctx.ReadStruct(2, Cereal.ModelDataV2.XYZTData.READER.create);
            public Cereal.ModelDataV2.XYZTData.READER OrientationRate => ctx.ReadStruct(3, Cereal.ModelDataV2.XYZTData.READER.create);
            public IReadOnlyList<Cereal.ModelDataV2.XYZTData.READER> LaneLines => ctx.ReadList(4).Cast(Cereal.ModelDataV2.XYZTData.READER.create);
            public IReadOnlyList<float> LaneLineProbs => ctx.ReadList(5).CastFloat();
            public IReadOnlyList<Cereal.ModelDataV2.XYZTData.READER> RoadEdges => ctx.ReadList(6).Cast(Cereal.ModelDataV2.XYZTData.READER.create);
            public IReadOnlyList<Cereal.ModelDataV2.LeadDataV2.READER> Leads => ctx.ReadList(7).Cast(Cereal.ModelDataV2.LeadDataV2.READER.create);
            public Cereal.ModelDataV2.MetaData.READER Meta => ctx.ReadStruct(8, Cereal.ModelDataV2.MetaData.READER.create);
            public IReadOnlyList<float> LaneLineStds => ctx.ReadList(9).CastFloat();
            public IReadOnlyList<float> RoadEdgeStds => ctx.ReadList(10).CastFloat();
            public float ModelExecutionTime => ctx.ReadDataFloat(96UL, 0F);
            public IReadOnlyList<byte> RawPredictions => ctx.ReadList(11).CastByte();
            public float GpuExecutionTime => ctx.ReadDataFloat(192UL, 0F);
            public IReadOnlyList<Cereal.ModelDataV2.LeadDataV3.READER> LeadsV3 => ctx.ReadList(12).Cast(Cereal.ModelDataV2.LeadDataV3.READER.create);
            public Cereal.ModelDataV2.XYZTData.READER Acceleration => ctx.ReadStruct(13, Cereal.ModelDataV2.XYZTData.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(4, 14);
            }

            public uint FrameId
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public uint FrameAge
            {
                get => this.ReadDataUInt(32UL, 0U);
                set => this.WriteData(32UL, value, 0U);
            }

            public float FrameDropPerc
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public ulong TimestampEof
            {
                get => this.ReadDataULong(128UL, 0UL);
                set => this.WriteData(128UL, value, 0UL);
            }

            public Cereal.ModelDataV2.XYZTData.WRITER Position
            {
                get => BuildPointer<Cereal.ModelDataV2.XYZTData.WRITER>(0);
                set => Link(0, value);
            }

            public Cereal.ModelDataV2.XYZTData.WRITER Orientation
            {
                get => BuildPointer<Cereal.ModelDataV2.XYZTData.WRITER>(1);
                set => Link(1, value);
            }

            public Cereal.ModelDataV2.XYZTData.WRITER Velocity
            {
                get => BuildPointer<Cereal.ModelDataV2.XYZTData.WRITER>(2);
                set => Link(2, value);
            }

            public Cereal.ModelDataV2.XYZTData.WRITER OrientationRate
            {
                get => BuildPointer<Cereal.ModelDataV2.XYZTData.WRITER>(3);
                set => Link(3, value);
            }

            public ListOfStructsSerializer<Cereal.ModelDataV2.XYZTData.WRITER> LaneLines
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ModelDataV2.XYZTData.WRITER>>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<float> LaneLineProbs
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public ListOfStructsSerializer<Cereal.ModelDataV2.XYZTData.WRITER> RoadEdges
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ModelDataV2.XYZTData.WRITER>>(6);
                set => Link(6, value);
            }

            public ListOfStructsSerializer<Cereal.ModelDataV2.LeadDataV2.WRITER> Leads
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ModelDataV2.LeadDataV2.WRITER>>(7);
                set => Link(7, value);
            }

            public Cereal.ModelDataV2.MetaData.WRITER Meta
            {
                get => BuildPointer<Cereal.ModelDataV2.MetaData.WRITER>(8);
                set => Link(8, value);
            }

            public ListOfPrimitivesSerializer<float> LaneLineStds
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(9);
                set => Link(9, value);
            }

            public ListOfPrimitivesSerializer<float> RoadEdgeStds
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(10);
                set => Link(10, value);
            }

            public float ModelExecutionTime
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<byte> RawPredictions
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(11);
                set => Link(11, value);
            }

            public float GpuExecutionTime
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public ListOfStructsSerializer<Cereal.ModelDataV2.LeadDataV3.WRITER> LeadsV3
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ModelDataV2.LeadDataV3.WRITER>>(12);
                set => Link(12, value);
            }

            public Cereal.ModelDataV2.XYZTData.WRITER Acceleration
            {
                get => BuildPointer<Cereal.ModelDataV2.XYZTData.WRITER>(13);
                set => Link(13, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc3cbae1fd505ae80UL)]
        public class XYZTData : ICapnpSerializable
        {
            public const UInt64 typeId = 0xc3cbae1fd505ae80UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                X = reader.X;
                Y = reader.Y;
                Z = reader.Z;
                T = reader.T;
                XStd = reader.XStd;
                YStd = reader.YStd;
                ZStd = reader.ZStd;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.X.Init(X);
                writer.Y.Init(Y);
                writer.Z.Init(Z);
                writer.T.Init(T);
                writer.XStd.Init(XStd);
                writer.YStd.Init(YStd);
                writer.ZStd.Init(ZStd);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> X
            {
                get;
                set;
            }

            public IReadOnlyList<float> Y
            {
                get;
                set;
            }

            public IReadOnlyList<float> Z
            {
                get;
                set;
            }

            public IReadOnlyList<float> T
            {
                get;
                set;
            }

            public IReadOnlyList<float> XStd
            {
                get;
                set;
            }

            public IReadOnlyList<float> YStd
            {
                get;
                set;
            }

            public IReadOnlyList<float> ZStd
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
                public IReadOnlyList<float> X => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> Y => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> Z => ctx.ReadList(2).CastFloat();
                public IReadOnlyList<float> T => ctx.ReadList(3).CastFloat();
                public IReadOnlyList<float> XStd => ctx.ReadList(4).CastFloat();
                public IReadOnlyList<float> YStd => ctx.ReadList(5).CastFloat();
                public IReadOnlyList<float> ZStd => ctx.ReadList(6).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 7);
                }

                public ListOfPrimitivesSerializer<float> X
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> Y
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> Z
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public ListOfPrimitivesSerializer<float> T
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                    set => Link(3, value);
                }

                public ListOfPrimitivesSerializer<float> XStd
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                    set => Link(4, value);
                }

                public ListOfPrimitivesSerializer<float> YStd
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                    set => Link(5, value);
                }

                public ListOfPrimitivesSerializer<float> ZStd
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(6);
                    set => Link(6, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa444ed2b2187af28UL)]
        public class LeadDataV2 : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa444ed2b2187af28UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Prob = reader.Prob;
                T = reader.T;
                Xyva = reader.Xyva;
                XyvaStd = reader.XyvaStd;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Prob = Prob;
                writer.T = T;
                writer.Xyva.Init(Xyva);
                writer.XyvaStd.Init(XyvaStd);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float Prob
            {
                get;
                set;
            }

            public float T
            {
                get;
                set;
            }

            public IReadOnlyList<float> Xyva
            {
                get;
                set;
            }

            public IReadOnlyList<float> XyvaStd
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
                public float Prob => ctx.ReadDataFloat(0UL, 0F);
                public float T => ctx.ReadDataFloat(32UL, 0F);
                public IReadOnlyList<float> Xyva => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> XyvaStd => ctx.ReadList(1).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 2);
                }

                public float Prob
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float T
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<float> Xyva
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> XyvaStd
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd698881ad0ce7febUL)]
        public class LeadDataV3 : ICapnpSerializable
        {
            public const UInt64 typeId = 0xd698881ad0ce7febUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Prob = reader.Prob;
                ProbTime = reader.ProbTime;
                T = reader.T;
                X = reader.X;
                XStd = reader.XStd;
                Y = reader.Y;
                YStd = reader.YStd;
                V = reader.V;
                VStd = reader.VStd;
                A = reader.A;
                AStd = reader.AStd;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Prob = Prob;
                writer.ProbTime = ProbTime;
                writer.T.Init(T);
                writer.X.Init(X);
                writer.XStd.Init(XStd);
                writer.Y.Init(Y);
                writer.YStd.Init(YStd);
                writer.V.Init(V);
                writer.VStd.Init(VStd);
                writer.A.Init(A);
                writer.AStd.Init(AStd);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float Prob
            {
                get;
                set;
            }

            public float ProbTime
            {
                get;
                set;
            }

            public IReadOnlyList<float> T
            {
                get;
                set;
            }

            public IReadOnlyList<float> X
            {
                get;
                set;
            }

            public IReadOnlyList<float> XStd
            {
                get;
                set;
            }

            public IReadOnlyList<float> Y
            {
                get;
                set;
            }

            public IReadOnlyList<float> YStd
            {
                get;
                set;
            }

            public IReadOnlyList<float> V
            {
                get;
                set;
            }

            public IReadOnlyList<float> VStd
            {
                get;
                set;
            }

            public IReadOnlyList<float> A
            {
                get;
                set;
            }

            public IReadOnlyList<float> AStd
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
                public float Prob => ctx.ReadDataFloat(0UL, 0F);
                public float ProbTime => ctx.ReadDataFloat(32UL, 0F);
                public IReadOnlyList<float> T => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> X => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> XStd => ctx.ReadList(2).CastFloat();
                public IReadOnlyList<float> Y => ctx.ReadList(3).CastFloat();
                public IReadOnlyList<float> YStd => ctx.ReadList(4).CastFloat();
                public IReadOnlyList<float> V => ctx.ReadList(5).CastFloat();
                public IReadOnlyList<float> VStd => ctx.ReadList(6).CastFloat();
                public IReadOnlyList<float> A => ctx.ReadList(7).CastFloat();
                public IReadOnlyList<float> AStd => ctx.ReadList(8).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 9);
                }

                public float Prob
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float ProbTime
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<float> T
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> X
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> XStd
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public ListOfPrimitivesSerializer<float> Y
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                    set => Link(3, value);
                }

                public ListOfPrimitivesSerializer<float> YStd
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                    set => Link(4, value);
                }

                public ListOfPrimitivesSerializer<float> V
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                    set => Link(5, value);
                }

                public ListOfPrimitivesSerializer<float> VStd
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(6);
                    set => Link(6, value);
                }

                public ListOfPrimitivesSerializer<float> A
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(7);
                    set => Link(7, value);
                }

                public ListOfPrimitivesSerializer<float> AStd
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(8);
                    set => Link(8, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd1646ab3b45cfabdUL)]
        public class MetaData : ICapnpSerializable
        {
            public const UInt64 typeId = 0xd1646ab3b45cfabdUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                EngagedProb = reader.EngagedProb;
                DesirePrediction = reader.DesirePrediction;
                BrakeDisengageProbDEPRECATED = reader.BrakeDisengageProbDEPRECATED;
                GasDisengageProbDEPRECATED = reader.GasDisengageProbDEPRECATED;
                SteerOverrideProbDEPRECATED = reader.SteerOverrideProbDEPRECATED;
                DesireState = reader.DesireState;
                DisengagePredictions = CapnpSerializable.Create<Cereal.ModelDataV2.DisengagePredictions>(reader.DisengagePredictions);
                HardBrakePredicted = reader.HardBrakePredicted;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.EngagedProb = EngagedProb;
                writer.DesirePrediction.Init(DesirePrediction);
                writer.BrakeDisengageProbDEPRECATED = BrakeDisengageProbDEPRECATED;
                writer.GasDisengageProbDEPRECATED = GasDisengageProbDEPRECATED;
                writer.SteerOverrideProbDEPRECATED = SteerOverrideProbDEPRECATED;
                writer.DesireState.Init(DesireState);
                DisengagePredictions?.serialize(writer.DisengagePredictions);
                writer.HardBrakePredicted = HardBrakePredicted;
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

            public float BrakeDisengageProbDEPRECATED
            {
                get;
                set;
            }

            public float GasDisengageProbDEPRECATED
            {
                get;
                set;
            }

            public float SteerOverrideProbDEPRECATED
            {
                get;
                set;
            }

            public IReadOnlyList<float> DesireState
            {
                get;
                set;
            }

            public Cereal.ModelDataV2.DisengagePredictions DisengagePredictions
            {
                get;
                set;
            }

            public bool HardBrakePredicted
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
                public float BrakeDisengageProbDEPRECATED => ctx.ReadDataFloat(32UL, 0F);
                public float GasDisengageProbDEPRECATED => ctx.ReadDataFloat(64UL, 0F);
                public float SteerOverrideProbDEPRECATED => ctx.ReadDataFloat(96UL, 0F);
                public IReadOnlyList<float> DesireState => ctx.ReadList(1).CastFloat();
                public Cereal.ModelDataV2.DisengagePredictions.READER DisengagePredictions => ctx.ReadStruct(2, Cereal.ModelDataV2.DisengagePredictions.READER.create);
                public bool HardBrakePredicted => ctx.ReadDataBool(128UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(3, 3);
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

                public float BrakeDisengageProbDEPRECATED
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }

                public float GasDisengageProbDEPRECATED
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float SteerOverrideProbDEPRECATED
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public ListOfPrimitivesSerializer<float> DesireState
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public Cereal.ModelDataV2.DisengagePredictions.WRITER DisengagePredictions
                {
                    get => BuildPointer<Cereal.ModelDataV2.DisengagePredictions.WRITER>(2);
                    set => Link(2, value);
                }

                public bool HardBrakePredicted
                {
                    get => this.ReadDataBool(128UL, false);
                    set => this.WriteData(128UL, value, false);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x860aa5ddbcdc8d25UL)]
        public class DisengagePredictions : ICapnpSerializable
        {
            public const UInt64 typeId = 0x860aa5ddbcdc8d25UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                T = reader.T;
                BrakeDisengageProbs = reader.BrakeDisengageProbs;
                GasDisengageProbs = reader.GasDisengageProbs;
                SteerOverrideProbs = reader.SteerOverrideProbs;
                Brake3MetersPerSecondSquaredProbs = reader.Brake3MetersPerSecondSquaredProbs;
                Brake4MetersPerSecondSquaredProbs = reader.Brake4MetersPerSecondSquaredProbs;
                Brake5MetersPerSecondSquaredProbs = reader.Brake5MetersPerSecondSquaredProbs;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.T.Init(T);
                writer.BrakeDisengageProbs.Init(BrakeDisengageProbs);
                writer.GasDisengageProbs.Init(GasDisengageProbs);
                writer.SteerOverrideProbs.Init(SteerOverrideProbs);
                writer.Brake3MetersPerSecondSquaredProbs.Init(Brake3MetersPerSecondSquaredProbs);
                writer.Brake4MetersPerSecondSquaredProbs.Init(Brake4MetersPerSecondSquaredProbs);
                writer.Brake5MetersPerSecondSquaredProbs.Init(Brake5MetersPerSecondSquaredProbs);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> T
            {
                get;
                set;
            }

            public IReadOnlyList<float> BrakeDisengageProbs
            {
                get;
                set;
            }

            public IReadOnlyList<float> GasDisengageProbs
            {
                get;
                set;
            }

            public IReadOnlyList<float> SteerOverrideProbs
            {
                get;
                set;
            }

            public IReadOnlyList<float> Brake3MetersPerSecondSquaredProbs
            {
                get;
                set;
            }

            public IReadOnlyList<float> Brake4MetersPerSecondSquaredProbs
            {
                get;
                set;
            }

            public IReadOnlyList<float> Brake5MetersPerSecondSquaredProbs
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
                public IReadOnlyList<float> T => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> BrakeDisengageProbs => ctx.ReadList(1).CastFloat();
                public IReadOnlyList<float> GasDisengageProbs => ctx.ReadList(2).CastFloat();
                public IReadOnlyList<float> SteerOverrideProbs => ctx.ReadList(3).CastFloat();
                public IReadOnlyList<float> Brake3MetersPerSecondSquaredProbs => ctx.ReadList(4).CastFloat();
                public IReadOnlyList<float> Brake4MetersPerSecondSquaredProbs => ctx.ReadList(5).CastFloat();
                public IReadOnlyList<float> Brake5MetersPerSecondSquaredProbs => ctx.ReadList(6).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 7);
                }

                public ListOfPrimitivesSerializer<float> T
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> BrakeDisengageProbs
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }

                public ListOfPrimitivesSerializer<float> GasDisengageProbs
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                    set => Link(2, value);
                }

                public ListOfPrimitivesSerializer<float> SteerOverrideProbs
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                    set => Link(3, value);
                }

                public ListOfPrimitivesSerializer<float> Brake3MetersPerSecondSquaredProbs
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                    set => Link(4, value);
                }

                public ListOfPrimitivesSerializer<float> Brake4MetersPerSecondSquaredProbs
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                    set => Link(5, value);
                }

                public ListOfPrimitivesSerializer<float> Brake5MetersPerSecondSquaredProbs
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(6);
                    set => Link(6, value);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x89d394e3541735fcUL)]
    public class EncodeIndex : ICapnpSerializable
    {
        public const UInt64 typeId = 0x89d394e3541735fcUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            FrameId = reader.FrameId;
            TheType = reader.TheType;
            EncodeId = reader.EncodeId;
            SegmentNum = reader.SegmentNum;
            SegmentId = reader.SegmentId;
            SegmentIdEncode = reader.SegmentIdEncode;
            TimestampSof = reader.TimestampSof;
            TimestampEof = reader.TimestampEof;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.FrameId = FrameId;
            writer.TheType = TheType;
            writer.EncodeId = EncodeId;
            writer.SegmentNum = SegmentNum;
            writer.SegmentId = SegmentId;
            writer.SegmentIdEncode = SegmentIdEncode;
            writer.TimestampSof = TimestampSof;
            writer.TimestampEof = TimestampEof;
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

        public Cereal.EncodeIndex.Type TheType
        {
            get;
            set;
        }

        public uint EncodeId
        {
            get;
            set;
        }

        public int SegmentNum
        {
            get;
            set;
        }

        public uint SegmentId
        {
            get;
            set;
        }

        public uint SegmentIdEncode
        {
            get;
            set;
        }

        public ulong TimestampSof
        {
            get;
            set;
        }

        public ulong TimestampEof
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
            public Cereal.EncodeIndex.Type TheType => (Cereal.EncodeIndex.Type)ctx.ReadDataUShort(32UL, (ushort)0);
            public uint EncodeId => ctx.ReadDataUInt(64UL, 0U);
            public int SegmentNum => ctx.ReadDataInt(96UL, 0);
            public uint SegmentId => ctx.ReadDataUInt(128UL, 0U);
            public uint SegmentIdEncode => ctx.ReadDataUInt(160UL, 0U);
            public ulong TimestampSof => ctx.ReadDataULong(192UL, 0UL);
            public ulong TimestampEof => ctx.ReadDataULong(256UL, 0UL);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(5, 0);
            }

            public uint FrameId
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public Cereal.EncodeIndex.Type TheType
            {
                get => (Cereal.EncodeIndex.Type)this.ReadDataUShort(32UL, (ushort)0);
                set => this.WriteData(32UL, (ushort)value, (ushort)0);
            }

            public uint EncodeId
            {
                get => this.ReadDataUInt(64UL, 0U);
                set => this.WriteData(64UL, value, 0U);
            }

            public int SegmentNum
            {
                get => this.ReadDataInt(96UL, 0);
                set => this.WriteData(96UL, value, 0);
            }

            public uint SegmentId
            {
                get => this.ReadDataUInt(128UL, 0U);
                set => this.WriteData(128UL, value, 0U);
            }

            public uint SegmentIdEncode
            {
                get => this.ReadDataUInt(160UL, 0U);
                set => this.WriteData(160UL, value, 0U);
            }

            public ulong TimestampSof
            {
                get => this.ReadDataULong(192UL, 0UL);
                set => this.WriteData(192UL, value, 0UL);
            }

            public ulong TimestampEof
            {
                get => this.ReadDataULong(256UL, 0UL);
                set => this.WriteData(256UL, value, 0UL);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc0ad259ec157ccd3UL)]
        public enum Type : ushort
        {
            bigBoxLossless,
            fullHEVC,
            bigBoxHEVC,
            chffrAndroidH264,
            fullLosslessClip,
            front
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xea095da1894f7d85UL)]
    public class AndroidLogEntry : ICapnpSerializable
    {
        public const UInt64 typeId = 0xea095da1894f7d85UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Id = reader.Id;
            Ts = reader.Ts;
            Priority = reader.Priority;
            Pid = reader.Pid;
            Tid = reader.Tid;
            Tag = reader.Tag;
            Message = reader.Message;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Id = Id;
            writer.Ts = Ts;
            writer.Priority = Priority;
            writer.Pid = Pid;
            writer.Tid = Tid;
            writer.Tag = Tag;
            writer.Message = Message;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public byte Id
        {
            get;
            set;
        }

        public ulong Ts
        {
            get;
            set;
        }

        public byte Priority
        {
            get;
            set;
        }

        public int Pid
        {
            get;
            set;
        }

        public int Tid
        {
            get;
            set;
        }

        public string Tag
        {
            get;
            set;
        }

        public string Message
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
            public byte Id => ctx.ReadDataByte(0UL, (byte)0);
            public ulong Ts => ctx.ReadDataULong(64UL, 0UL);
            public byte Priority => ctx.ReadDataByte(8UL, (byte)0);
            public int Pid => ctx.ReadDataInt(32UL, 0);
            public int Tid => ctx.ReadDataInt(128UL, 0);
            public string Tag => ctx.ReadText(0, null);
            public string Message => ctx.ReadText(1, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(3, 2);
            }

            public byte Id
            {
                get => this.ReadDataByte(0UL, (byte)0);
                set => this.WriteData(0UL, value, (byte)0);
            }

            public ulong Ts
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public byte Priority
            {
                get => this.ReadDataByte(8UL, (byte)0);
                set => this.WriteData(8UL, value, (byte)0);
            }

            public int Pid
            {
                get => this.ReadDataInt(32UL, 0);
                set => this.WriteData(32UL, value, 0);
            }

            public int Tid
            {
                get => this.ReadDataInt(128UL, 0);
                set => this.WriteData(128UL, value, 0);
            }

            public string Tag
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string Message
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe00b5b3eba12876cUL)]
    public class LongitudinalPlan : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe00b5b3eba12876cUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            LateralValidDEPRECATED = reader.LateralValidDEPRECATED;
            DPolyDEPRECATED = reader.DPolyDEPRECATED;
            LongitudinalValidDEPRECATED = reader.LongitudinalValidDEPRECATED;
            VTargetDEPRECATED = reader.VTargetDEPRECATED;
            ATargetMinDEPRECATED = reader.ATargetMinDEPRECATED;
            ATargetMaxDEPRECATED = reader.ATargetMaxDEPRECATED;
            JerkFactorDEPRECATED = reader.JerkFactorDEPRECATED;
            HasLead = reader.HasLead;
            Fcw = reader.Fcw;
            ModelMonoTime = reader.ModelMonoTime;
            RadarStateMonoTimeDEPRECATED = reader.RadarStateMonoTimeDEPRECATED;
            LaneWidthDEPRECATED = reader.LaneWidthDEPRECATED;
            GpsTrajectoryDEPRECATED = CapnpSerializable.Create<Cereal.LongitudinalPlan.GpsTrajectory>(reader.GpsTrajectoryDEPRECATED);
            EventsDEPRECATED = reader.EventsDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CarEvent>(_));
            VTargetFutureDEPRECATED = reader.VTargetFutureDEPRECATED;
            TheLongitudinalPlanSource = reader.TheLongitudinalPlanSource;
            VCruiseDEPRECATED = reader.VCruiseDEPRECATED;
            ACruiseDEPRECATED = reader.ACruiseDEPRECATED;
            ATargetDEPRECATED = reader.ATargetDEPRECATED;
            GpsPlannerActiveDEPRECATED = reader.GpsPlannerActiveDEPRECATED;
            VMaxDEPRECATED = reader.VMaxDEPRECATED;
            VCurvatureDEPRECATED = reader.VCurvatureDEPRECATED;
            DecelForTurnDEPRECATED = reader.DecelForTurnDEPRECATED;
            HasLeftLaneDEPRECATED = reader.HasLeftLaneDEPRECATED;
            HasRightLaneDEPRECATED = reader.HasRightLaneDEPRECATED;
            MapValidDEPRECATED = reader.MapValidDEPRECATED;
            VStartDEPRECATED = reader.VStartDEPRECATED;
            AStartDEPRECATED = reader.AStartDEPRECATED;
            RadarValidDEPRECATED = reader.RadarValidDEPRECATED;
            ProcessingDelay = reader.ProcessingDelay;
            RadarCanErrorDEPRECATED = reader.RadarCanErrorDEPRECATED;
            CommIssueDEPRECATED = reader.CommIssueDEPRECATED;
            Accels = reader.Accels;
            Speeds = reader.Speeds;
            Jerks = reader.Jerks;
            SolverExecutionTime = reader.SolverExecutionTime;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.LateralValidDEPRECATED = LateralValidDEPRECATED;
            writer.DPolyDEPRECATED.Init(DPolyDEPRECATED);
            writer.LongitudinalValidDEPRECATED = LongitudinalValidDEPRECATED;
            writer.VTargetDEPRECATED = VTargetDEPRECATED;
            writer.ATargetMinDEPRECATED = ATargetMinDEPRECATED;
            writer.ATargetMaxDEPRECATED = ATargetMaxDEPRECATED;
            writer.JerkFactorDEPRECATED = JerkFactorDEPRECATED;
            writer.HasLead = HasLead;
            writer.Fcw = Fcw;
            writer.ModelMonoTime = ModelMonoTime;
            writer.RadarStateMonoTimeDEPRECATED = RadarStateMonoTimeDEPRECATED;
            writer.LaneWidthDEPRECATED = LaneWidthDEPRECATED;
            GpsTrajectoryDEPRECATED?.serialize(writer.GpsTrajectoryDEPRECATED);
            writer.EventsDEPRECATED.Init(EventsDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
            writer.VTargetFutureDEPRECATED = VTargetFutureDEPRECATED;
            writer.TheLongitudinalPlanSource = TheLongitudinalPlanSource;
            writer.VCruiseDEPRECATED = VCruiseDEPRECATED;
            writer.ACruiseDEPRECATED = ACruiseDEPRECATED;
            writer.ATargetDEPRECATED = ATargetDEPRECATED;
            writer.GpsPlannerActiveDEPRECATED = GpsPlannerActiveDEPRECATED;
            writer.VMaxDEPRECATED = VMaxDEPRECATED;
            writer.VCurvatureDEPRECATED = VCurvatureDEPRECATED;
            writer.DecelForTurnDEPRECATED = DecelForTurnDEPRECATED;
            writer.HasLeftLaneDEPRECATED = HasLeftLaneDEPRECATED;
            writer.HasRightLaneDEPRECATED = HasRightLaneDEPRECATED;
            writer.MapValidDEPRECATED = MapValidDEPRECATED;
            writer.VStartDEPRECATED = VStartDEPRECATED;
            writer.AStartDEPRECATED = AStartDEPRECATED;
            writer.RadarValidDEPRECATED = RadarValidDEPRECATED;
            writer.ProcessingDelay = ProcessingDelay;
            writer.RadarCanErrorDEPRECATED = RadarCanErrorDEPRECATED;
            writer.CommIssueDEPRECATED = CommIssueDEPRECATED;
            writer.Accels.Init(Accels);
            writer.Speeds.Init(Speeds);
            writer.Jerks.Init(Jerks);
            writer.SolverExecutionTime = SolverExecutionTime;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool LateralValidDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> DPolyDEPRECATED
        {
            get;
            set;
        }

        public bool LongitudinalValidDEPRECATED
        {
            get;
            set;
        }

        public float VTargetDEPRECATED
        {
            get;
            set;
        }

        public float ATargetMinDEPRECATED
        {
            get;
            set;
        }

        public float ATargetMaxDEPRECATED
        {
            get;
            set;
        }

        public float JerkFactorDEPRECATED
        {
            get;
            set;
        }

        public bool HasLead
        {
            get;
            set;
        }

        public bool Fcw
        {
            get;
            set;
        }

        public ulong ModelMonoTime
        {
            get;
            set;
        }

        public ulong RadarStateMonoTimeDEPRECATED
        {
            get;
            set;
        }

        public float LaneWidthDEPRECATED
        {
            get;
            set;
        }

        public Cereal.LongitudinalPlan.GpsTrajectory GpsTrajectoryDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.CarEvent> EventsDEPRECATED
        {
            get;
            set;
        }

        public float VTargetFutureDEPRECATED
        {
            get;
            set;
        }

        public Cereal.LongitudinalPlan.LongitudinalPlanSource TheLongitudinalPlanSource
        {
            get;
            set;
        }

        public float VCruiseDEPRECATED
        {
            get;
            set;
        }

        public float ACruiseDEPRECATED
        {
            get;
            set;
        }

        public float ATargetDEPRECATED
        {
            get;
            set;
        }

        public bool GpsPlannerActiveDEPRECATED
        {
            get;
            set;
        }

        public float VMaxDEPRECATED
        {
            get;
            set;
        }

        public float VCurvatureDEPRECATED
        {
            get;
            set;
        }

        public bool DecelForTurnDEPRECATED
        {
            get;
            set;
        }

        public bool HasLeftLaneDEPRECATED
        {
            get;
            set;
        }

        public bool HasRightLaneDEPRECATED
        {
            get;
            set;
        }

        public bool MapValidDEPRECATED
        {
            get;
            set;
        }

        public float VStartDEPRECATED
        {
            get;
            set;
        }

        public float AStartDEPRECATED
        {
            get;
            set;
        }

        public bool RadarValidDEPRECATED
        {
            get;
            set;
        }

        public float ProcessingDelay
        {
            get;
            set;
        }

        public bool RadarCanErrorDEPRECATED
        {
            get;
            set;
        }

        public bool CommIssueDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> Accels
        {
            get;
            set;
        }

        public IReadOnlyList<float> Speeds
        {
            get;
            set;
        }

        public IReadOnlyList<float> Jerks
        {
            get;
            set;
        }

        public float SolverExecutionTime
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
            public bool LateralValidDEPRECATED => ctx.ReadDataBool(0UL, false);
            public IReadOnlyList<float> DPolyDEPRECATED => ctx.ReadList(0).CastFloat();
            public bool LongitudinalValidDEPRECATED => ctx.ReadDataBool(1UL, false);
            public float VTargetDEPRECATED => ctx.ReadDataFloat(32UL, 0F);
            public float ATargetMinDEPRECATED => ctx.ReadDataFloat(64UL, 0F);
            public float ATargetMaxDEPRECATED => ctx.ReadDataFloat(96UL, 0F);
            public float JerkFactorDEPRECATED => ctx.ReadDataFloat(128UL, 0F);
            public bool HasLead => ctx.ReadDataBool(2UL, false);
            public bool Fcw => ctx.ReadDataBool(3UL, false);
            public ulong ModelMonoTime => ctx.ReadDataULong(192UL, 0UL);
            public ulong RadarStateMonoTimeDEPRECATED => ctx.ReadDataULong(256UL, 0UL);
            public float LaneWidthDEPRECATED => ctx.ReadDataFloat(160UL, 0F);
            public Cereal.LongitudinalPlan.GpsTrajectory.READER GpsTrajectoryDEPRECATED => ctx.ReadStruct(1, Cereal.LongitudinalPlan.GpsTrajectory.READER.create);
            public IReadOnlyList<Cereal.CarEvent.READER> EventsDEPRECATED => ctx.ReadList(2).Cast(Cereal.CarEvent.READER.create);
            public float VTargetFutureDEPRECATED => ctx.ReadDataFloat(320UL, 0F);
            public Cereal.LongitudinalPlan.LongitudinalPlanSource TheLongitudinalPlanSource => (Cereal.LongitudinalPlan.LongitudinalPlanSource)ctx.ReadDataUShort(16UL, (ushort)0);
            public float VCruiseDEPRECATED => ctx.ReadDataFloat(352UL, 0F);
            public float ACruiseDEPRECATED => ctx.ReadDataFloat(384UL, 0F);
            public float ATargetDEPRECATED => ctx.ReadDataFloat(416UL, 0F);
            public bool GpsPlannerActiveDEPRECATED => ctx.ReadDataBool(4UL, false);
            public float VMaxDEPRECATED => ctx.ReadDataFloat(448UL, 0F);
            public float VCurvatureDEPRECATED => ctx.ReadDataFloat(480UL, 0F);
            public bool DecelForTurnDEPRECATED => ctx.ReadDataBool(5UL, false);
            public bool HasLeftLaneDEPRECATED => ctx.ReadDataBool(6UL, false);
            public bool HasRightLaneDEPRECATED => ctx.ReadDataBool(7UL, false);
            public bool MapValidDEPRECATED => ctx.ReadDataBool(8UL, false);
            public float VStartDEPRECATED => ctx.ReadDataFloat(512UL, 0F);
            public float AStartDEPRECATED => ctx.ReadDataFloat(544UL, 0F);
            public bool RadarValidDEPRECATED => ctx.ReadDataBool(9UL, false);
            public float ProcessingDelay => ctx.ReadDataFloat(576UL, 0F);
            public bool RadarCanErrorDEPRECATED => ctx.ReadDataBool(10UL, false);
            public bool CommIssueDEPRECATED => ctx.ReadDataBool(11UL, false);
            public IReadOnlyList<float> Accels => ctx.ReadList(3).CastFloat();
            public IReadOnlyList<float> Speeds => ctx.ReadList(4).CastFloat();
            public IReadOnlyList<float> Jerks => ctx.ReadList(5).CastFloat();
            public float SolverExecutionTime => ctx.ReadDataFloat(608UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(10, 6);
            }

            public bool LateralValidDEPRECATED
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public ListOfPrimitivesSerializer<float> DPolyDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public bool LongitudinalValidDEPRECATED
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public float VTargetDEPRECATED
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float ATargetMinDEPRECATED
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public float ATargetMaxDEPRECATED
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public float JerkFactorDEPRECATED
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public bool HasLead
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }

            public bool Fcw
            {
                get => this.ReadDataBool(3UL, false);
                set => this.WriteData(3UL, value, false);
            }

            public ulong ModelMonoTime
            {
                get => this.ReadDataULong(192UL, 0UL);
                set => this.WriteData(192UL, value, 0UL);
            }

            public ulong RadarStateMonoTimeDEPRECATED
            {
                get => this.ReadDataULong(256UL, 0UL);
                set => this.WriteData(256UL, value, 0UL);
            }

            public float LaneWidthDEPRECATED
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public Cereal.LongitudinalPlan.GpsTrajectory.WRITER GpsTrajectoryDEPRECATED
            {
                get => BuildPointer<Cereal.LongitudinalPlan.GpsTrajectory.WRITER>(1);
                set => Link(1, value);
            }

            public ListOfStructsSerializer<Cereal.CarEvent.WRITER> EventsDEPRECATED
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.CarEvent.WRITER>>(2);
                set => Link(2, value);
            }

            public float VTargetFutureDEPRECATED
            {
                get => this.ReadDataFloat(320UL, 0F);
                set => this.WriteData(320UL, value, 0F);
            }

            public Cereal.LongitudinalPlan.LongitudinalPlanSource TheLongitudinalPlanSource
            {
                get => (Cereal.LongitudinalPlan.LongitudinalPlanSource)this.ReadDataUShort(16UL, (ushort)0);
                set => this.WriteData(16UL, (ushort)value, (ushort)0);
            }

            public float VCruiseDEPRECATED
            {
                get => this.ReadDataFloat(352UL, 0F);
                set => this.WriteData(352UL, value, 0F);
            }

            public float ACruiseDEPRECATED
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }

            public float ATargetDEPRECATED
            {
                get => this.ReadDataFloat(416UL, 0F);
                set => this.WriteData(416UL, value, 0F);
            }

            public bool GpsPlannerActiveDEPRECATED
            {
                get => this.ReadDataBool(4UL, false);
                set => this.WriteData(4UL, value, false);
            }

            public float VMaxDEPRECATED
            {
                get => this.ReadDataFloat(448UL, 0F);
                set => this.WriteData(448UL, value, 0F);
            }

            public float VCurvatureDEPRECATED
            {
                get => this.ReadDataFloat(480UL, 0F);
                set => this.WriteData(480UL, value, 0F);
            }

            public bool DecelForTurnDEPRECATED
            {
                get => this.ReadDataBool(5UL, false);
                set => this.WriteData(5UL, value, false);
            }

            public bool HasLeftLaneDEPRECATED
            {
                get => this.ReadDataBool(6UL, false);
                set => this.WriteData(6UL, value, false);
            }

            public bool HasRightLaneDEPRECATED
            {
                get => this.ReadDataBool(7UL, false);
                set => this.WriteData(7UL, value, false);
            }

            public bool MapValidDEPRECATED
            {
                get => this.ReadDataBool(8UL, false);
                set => this.WriteData(8UL, value, false);
            }

            public float VStartDEPRECATED
            {
                get => this.ReadDataFloat(512UL, 0F);
                set => this.WriteData(512UL, value, 0F);
            }

            public float AStartDEPRECATED
            {
                get => this.ReadDataFloat(544UL, 0F);
                set => this.WriteData(544UL, value, 0F);
            }

            public bool RadarValidDEPRECATED
            {
                get => this.ReadDataBool(9UL, false);
                set => this.WriteData(9UL, value, false);
            }

            public float ProcessingDelay
            {
                get => this.ReadDataFloat(576UL, 0F);
                set => this.WriteData(576UL, value, 0F);
            }

            public bool RadarCanErrorDEPRECATED
            {
                get => this.ReadDataBool(10UL, false);
                set => this.WriteData(10UL, value, false);
            }

            public bool CommIssueDEPRECATED
            {
                get => this.ReadDataBool(11UL, false);
                set => this.WriteData(11UL, value, false);
            }

            public ListOfPrimitivesSerializer<float> Accels
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public ListOfPrimitivesSerializer<float> Speeds
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<float> Jerks
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public float SolverExecutionTime
            {
                get => this.ReadDataFloat(608UL, 0F);
                set => this.WriteData(608UL, value, 0F);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb231a753cc079120UL)]
        public enum LongitudinalPlanSource : ushort
        {
            cruise,
            lead0,
            lead1,
            lead2,
            e2e
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8cfeb072f5301000UL)]
        public class GpsTrajectory : ICapnpSerializable
        {
            public const UInt64 typeId = 0x8cfeb072f5301000UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                X = reader.X;
                Y = reader.Y;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.X.Init(X);
                writer.Y.Init(Y);
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<float> X
            {
                get;
                set;
            }

            public IReadOnlyList<float> Y
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
                public IReadOnlyList<float> X => ctx.ReadList(0).CastFloat();
                public IReadOnlyList<float> Y => ctx.ReadList(1).CastFloat();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(0, 2);
                }

                public ListOfPrimitivesSerializer<float> X
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<float> Y
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                    set => Link(1, value);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe1e9318e2ae8b51eUL)]
    public class LateralPlan : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe1e9318e2ae8b51eUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            LaneWidth = reader.LaneWidth;
            DPolyDEPRECATED = reader.DPolyDEPRECATED;
            CPolyDEPRECATED = reader.CPolyDEPRECATED;
            CProbDEPRECATED = reader.CProbDEPRECATED;
            LPolyDEPRECATED = reader.LPolyDEPRECATED;
            LProb = reader.LProb;
            RPolyDEPRECATED = reader.RPolyDEPRECATED;
            RProb = reader.RProb;
            SteeringAngleDegDEPRECATED = reader.SteeringAngleDegDEPRECATED;
            MpcSolutionValid = reader.MpcSolutionValid;
            ParamsValidDEPRECATED = reader.ParamsValidDEPRECATED;
            AngleOffsetDegDEPRECATED = reader.AngleOffsetDegDEPRECATED;
            ModelValidDEPRECATED = reader.ModelValidDEPRECATED;
            SteeringRateDegDEPRECATED = reader.SteeringRateDegDEPRECATED;
            SensorValidDEPRECATED = reader.SensorValidDEPRECATED;
            CommIssueDEPRECATED = reader.CommIssueDEPRECATED;
            PosenetValidDEPRECATED = reader.PosenetValidDEPRECATED;
            TheDesire = reader.TheDesire;
            TheLaneChangeState = reader.TheLaneChangeState;
            TheLaneChangeDirection = reader.TheLaneChangeDirection;
            DPathPoints = reader.DPathPoints;
            DProb = reader.DProb;
            CurvatureDEPRECATED = reader.CurvatureDEPRECATED;
            CurvatureRateDEPRECATED = reader.CurvatureRateDEPRECATED;
            RawCurvatureDEPRECATED = reader.RawCurvatureDEPRECATED;
            RawCurvatureRateDEPRECATED = reader.RawCurvatureRateDEPRECATED;
            Psis = reader.Psis;
            Curvatures = reader.Curvatures;
            CurvatureRates = reader.CurvatureRates;
            UseLaneLines = reader.UseLaneLines;
            SolverExecutionTime = reader.SolverExecutionTime;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.LaneWidth = LaneWidth;
            writer.DPolyDEPRECATED.Init(DPolyDEPRECATED);
            writer.CPolyDEPRECATED.Init(CPolyDEPRECATED);
            writer.CProbDEPRECATED = CProbDEPRECATED;
            writer.LPolyDEPRECATED.Init(LPolyDEPRECATED);
            writer.LProb = LProb;
            writer.RPolyDEPRECATED.Init(RPolyDEPRECATED);
            writer.RProb = RProb;
            writer.SteeringAngleDegDEPRECATED = SteeringAngleDegDEPRECATED;
            writer.MpcSolutionValid = MpcSolutionValid;
            writer.ParamsValidDEPRECATED = ParamsValidDEPRECATED;
            writer.AngleOffsetDegDEPRECATED = AngleOffsetDegDEPRECATED;
            writer.ModelValidDEPRECATED = ModelValidDEPRECATED;
            writer.SteeringRateDegDEPRECATED = SteeringRateDegDEPRECATED;
            writer.SensorValidDEPRECATED = SensorValidDEPRECATED;
            writer.CommIssueDEPRECATED = CommIssueDEPRECATED;
            writer.PosenetValidDEPRECATED = PosenetValidDEPRECATED;
            writer.TheDesire = TheDesire;
            writer.TheLaneChangeState = TheLaneChangeState;
            writer.TheLaneChangeDirection = TheLaneChangeDirection;
            writer.DPathPoints.Init(DPathPoints);
            writer.DProb = DProb;
            writer.CurvatureDEPRECATED = CurvatureDEPRECATED;
            writer.CurvatureRateDEPRECATED = CurvatureRateDEPRECATED;
            writer.RawCurvatureDEPRECATED = RawCurvatureDEPRECATED;
            writer.RawCurvatureRateDEPRECATED = RawCurvatureRateDEPRECATED;
            writer.Psis.Init(Psis);
            writer.Curvatures.Init(Curvatures);
            writer.CurvatureRates.Init(CurvatureRates);
            writer.UseLaneLines = UseLaneLines;
            writer.SolverExecutionTime = SolverExecutionTime;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public float LaneWidth
        {
            get;
            set;
        }

        public IReadOnlyList<float> DPolyDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> CPolyDEPRECATED
        {
            get;
            set;
        }

        public float CProbDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> LPolyDEPRECATED
        {
            get;
            set;
        }

        public float LProb
        {
            get;
            set;
        }

        public IReadOnlyList<float> RPolyDEPRECATED
        {
            get;
            set;
        }

        public float RProb
        {
            get;
            set;
        }

        public float SteeringAngleDegDEPRECATED
        {
            get;
            set;
        }

        public bool MpcSolutionValid
        {
            get;
            set;
        }

        public bool ParamsValidDEPRECATED
        {
            get;
            set;
        }

        public float AngleOffsetDegDEPRECATED
        {
            get;
            set;
        }

        public bool ModelValidDEPRECATED
        {
            get;
            set;
        }

        public float SteeringRateDegDEPRECATED
        {
            get;
            set;
        }

        public bool SensorValidDEPRECATED
        {
            get;
            set;
        }

        public bool CommIssueDEPRECATED
        {
            get;
            set;
        }

        public bool PosenetValidDEPRECATED
        {
            get;
            set;
        }

        public Cereal.LateralPlan.Desire TheDesire
        {
            get;
            set;
        }

        public Cereal.LateralPlan.LaneChangeState TheLaneChangeState
        {
            get;
            set;
        }

        public Cereal.LateralPlan.LaneChangeDirection TheLaneChangeDirection
        {
            get;
            set;
        }

        public IReadOnlyList<float> DPathPoints
        {
            get;
            set;
        }

        public float DProb
        {
            get;
            set;
        }

        public float CurvatureDEPRECATED
        {
            get;
            set;
        }

        public float CurvatureRateDEPRECATED
        {
            get;
            set;
        }

        public float RawCurvatureDEPRECATED
        {
            get;
            set;
        }

        public float RawCurvatureRateDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> Psis
        {
            get;
            set;
        }

        public IReadOnlyList<float> Curvatures
        {
            get;
            set;
        }

        public IReadOnlyList<float> CurvatureRates
        {
            get;
            set;
        }

        public bool UseLaneLines
        {
            get;
            set;
        }

        public float SolverExecutionTime
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
            public float LaneWidth => ctx.ReadDataFloat(0UL, 0F);
            public IReadOnlyList<float> DPolyDEPRECATED => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<float> CPolyDEPRECATED => ctx.ReadList(1).CastFloat();
            public float CProbDEPRECATED => ctx.ReadDataFloat(32UL, 0F);
            public IReadOnlyList<float> LPolyDEPRECATED => ctx.ReadList(2).CastFloat();
            public float LProb => ctx.ReadDataFloat(64UL, 0F);
            public IReadOnlyList<float> RPolyDEPRECATED => ctx.ReadList(3).CastFloat();
            public float RProb => ctx.ReadDataFloat(96UL, 0F);
            public float SteeringAngleDegDEPRECATED => ctx.ReadDataFloat(128UL, 0F);
            public bool MpcSolutionValid => ctx.ReadDataBool(160UL, false);
            public bool ParamsValidDEPRECATED => ctx.ReadDataBool(161UL, false);
            public float AngleOffsetDegDEPRECATED => ctx.ReadDataFloat(192UL, 0F);
            public bool ModelValidDEPRECATED => ctx.ReadDataBool(162UL, false);
            public float SteeringRateDegDEPRECATED => ctx.ReadDataFloat(224UL, 0F);
            public bool SensorValidDEPRECATED => ctx.ReadDataBool(163UL, false);
            public bool CommIssueDEPRECATED => ctx.ReadDataBool(164UL, false);
            public bool PosenetValidDEPRECATED => ctx.ReadDataBool(165UL, false);
            public Cereal.LateralPlan.Desire TheDesire => (Cereal.LateralPlan.Desire)ctx.ReadDataUShort(176UL, (ushort)0);
            public Cereal.LateralPlan.LaneChangeState TheLaneChangeState => (Cereal.LateralPlan.LaneChangeState)ctx.ReadDataUShort(256UL, (ushort)0);
            public Cereal.LateralPlan.LaneChangeDirection TheLaneChangeDirection => (Cereal.LateralPlan.LaneChangeDirection)ctx.ReadDataUShort(272UL, (ushort)0);
            public IReadOnlyList<float> DPathPoints => ctx.ReadList(4).CastFloat();
            public float DProb => ctx.ReadDataFloat(288UL, 0F);
            public float CurvatureDEPRECATED => ctx.ReadDataFloat(320UL, 0F);
            public float CurvatureRateDEPRECATED => ctx.ReadDataFloat(352UL, 0F);
            public float RawCurvatureDEPRECATED => ctx.ReadDataFloat(384UL, 0F);
            public float RawCurvatureRateDEPRECATED => ctx.ReadDataFloat(416UL, 0F);
            public IReadOnlyList<float> Psis => ctx.ReadList(5).CastFloat();
            public IReadOnlyList<float> Curvatures => ctx.ReadList(6).CastFloat();
            public IReadOnlyList<float> CurvatureRates => ctx.ReadList(7).CastFloat();
            public bool UseLaneLines => ctx.ReadDataBool(166UL, false);
            public float SolverExecutionTime => ctx.ReadDataFloat(448UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(8, 8);
            }

            public float LaneWidth
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> DPolyDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<float> CPolyDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public float CProbDEPRECATED
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> LPolyDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public float LProb
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> RPolyDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public float RProb
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public float SteeringAngleDegDEPRECATED
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public bool MpcSolutionValid
            {
                get => this.ReadDataBool(160UL, false);
                set => this.WriteData(160UL, value, false);
            }

            public bool ParamsValidDEPRECATED
            {
                get => this.ReadDataBool(161UL, false);
                set => this.WriteData(161UL, value, false);
            }

            public float AngleOffsetDegDEPRECATED
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public bool ModelValidDEPRECATED
            {
                get => this.ReadDataBool(162UL, false);
                set => this.WriteData(162UL, value, false);
            }

            public float SteeringRateDegDEPRECATED
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public bool SensorValidDEPRECATED
            {
                get => this.ReadDataBool(163UL, false);
                set => this.WriteData(163UL, value, false);
            }

            public bool CommIssueDEPRECATED
            {
                get => this.ReadDataBool(164UL, false);
                set => this.WriteData(164UL, value, false);
            }

            public bool PosenetValidDEPRECATED
            {
                get => this.ReadDataBool(165UL, false);
                set => this.WriteData(165UL, value, false);
            }

            public Cereal.LateralPlan.Desire TheDesire
            {
                get => (Cereal.LateralPlan.Desire)this.ReadDataUShort(176UL, (ushort)0);
                set => this.WriteData(176UL, (ushort)value, (ushort)0);
            }

            public Cereal.LateralPlan.LaneChangeState TheLaneChangeState
            {
                get => (Cereal.LateralPlan.LaneChangeState)this.ReadDataUShort(256UL, (ushort)0);
                set => this.WriteData(256UL, (ushort)value, (ushort)0);
            }

            public Cereal.LateralPlan.LaneChangeDirection TheLaneChangeDirection
            {
                get => (Cereal.LateralPlan.LaneChangeDirection)this.ReadDataUShort(272UL, (ushort)0);
                set => this.WriteData(272UL, (ushort)value, (ushort)0);
            }

            public ListOfPrimitivesSerializer<float> DPathPoints
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                set => Link(4, value);
            }

            public float DProb
            {
                get => this.ReadDataFloat(288UL, 0F);
                set => this.WriteData(288UL, value, 0F);
            }

            public float CurvatureDEPRECATED
            {
                get => this.ReadDataFloat(320UL, 0F);
                set => this.WriteData(320UL, value, 0F);
            }

            public float CurvatureRateDEPRECATED
            {
                get => this.ReadDataFloat(352UL, 0F);
                set => this.WriteData(352UL, value, 0F);
            }

            public float RawCurvatureDEPRECATED
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }

            public float RawCurvatureRateDEPRECATED
            {
                get => this.ReadDataFloat(416UL, 0F);
                set => this.WriteData(416UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> Psis
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public ListOfPrimitivesSerializer<float> Curvatures
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(6);
                set => Link(6, value);
            }

            public ListOfPrimitivesSerializer<float> CurvatureRates
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(7);
                set => Link(7, value);
            }

            public bool UseLaneLines
            {
                get => this.ReadDataBool(166UL, false);
                set => this.WriteData(166UL, value, false);
            }

            public float SolverExecutionTime
            {
                get => this.ReadDataFloat(448UL, 0F);
                set => this.WriteData(448UL, value, 0F);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbb53ef3fcf2a7f0dUL)]
        public enum Desire : ushort
        {
            none,
            turnLeft,
            turnRight,
            laneChangeLeft,
            laneChangeRight,
            keepLeft,
            keepRight
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfac297f195ce56d2UL)]
        public enum LaneChangeState : ushort
        {
            off,
            preLaneChange,
            laneChangeStarting,
            laneChangeFinishing
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf7396311bcbad303UL)]
        public enum LaneChangeDirection : ushort
        {
            none,
            left,
            right
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xebc5703d1ee7c129UL)]
    public class LiveLocationKalman : ICapnpSerializable
    {
        public const UInt64 typeId = 0xebc5703d1ee7c129UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            PositionECEF = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.PositionECEF);
            PositionGeodetic = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.PositionGeodetic);
            VelocityECEF = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.VelocityECEF);
            VelocityNED = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.VelocityNED);
            VelocityDevice = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.VelocityDevice);
            AccelerationDevice = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.AccelerationDevice);
            OrientationECEF = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.OrientationECEF);
            OrientationNED = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.OrientationNED);
            AngularVelocityDevice = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.AngularVelocityDevice);
            CalibratedOrientationNED = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.CalibratedOrientationNED);
            VelocityCalibrated = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.VelocityCalibrated);
            AccelerationCalibrated = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.AccelerationCalibrated);
            AngularVelocityCalibrated = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.AngularVelocityCalibrated);
            GpsWeek = reader.GpsWeek;
            GpsTimeOfWeek = reader.GpsTimeOfWeek;
            TheStatus = reader.TheStatus;
            UnixTimestampMillis = reader.UnixTimestampMillis;
            InputsOK = reader.InputsOK;
            PosenetOK = reader.PosenetOK;
            GpsOK = reader.GpsOK;
            CalibratedOrientationECEF = CapnpSerializable.Create<Cereal.LiveLocationKalman.Measurement>(reader.CalibratedOrientationECEF);
            SensorsOK = reader.SensorsOK;
            DeviceStable = reader.DeviceStable;
            TimeSinceReset = reader.TimeSinceReset;
            ExcessiveResets = reader.ExcessiveResets;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            PositionECEF?.serialize(writer.PositionECEF);
            PositionGeodetic?.serialize(writer.PositionGeodetic);
            VelocityECEF?.serialize(writer.VelocityECEF);
            VelocityNED?.serialize(writer.VelocityNED);
            VelocityDevice?.serialize(writer.VelocityDevice);
            AccelerationDevice?.serialize(writer.AccelerationDevice);
            OrientationECEF?.serialize(writer.OrientationECEF);
            OrientationNED?.serialize(writer.OrientationNED);
            AngularVelocityDevice?.serialize(writer.AngularVelocityDevice);
            CalibratedOrientationNED?.serialize(writer.CalibratedOrientationNED);
            VelocityCalibrated?.serialize(writer.VelocityCalibrated);
            AccelerationCalibrated?.serialize(writer.AccelerationCalibrated);
            AngularVelocityCalibrated?.serialize(writer.AngularVelocityCalibrated);
            writer.GpsWeek = GpsWeek;
            writer.GpsTimeOfWeek = GpsTimeOfWeek;
            writer.TheStatus = TheStatus;
            writer.UnixTimestampMillis = UnixTimestampMillis;
            writer.InputsOK = InputsOK;
            writer.PosenetOK = PosenetOK;
            writer.GpsOK = GpsOK;
            CalibratedOrientationECEF?.serialize(writer.CalibratedOrientationECEF);
            writer.SensorsOK = SensorsOK;
            writer.DeviceStable = DeviceStable;
            writer.TimeSinceReset = TimeSinceReset;
            writer.ExcessiveResets = ExcessiveResets;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public Cereal.LiveLocationKalman.Measurement PositionECEF
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement PositionGeodetic
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement VelocityECEF
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement VelocityNED
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement VelocityDevice
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement AccelerationDevice
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement OrientationECEF
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement OrientationNED
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement AngularVelocityDevice
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement CalibratedOrientationNED
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement VelocityCalibrated
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement AccelerationCalibrated
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Measurement AngularVelocityCalibrated
        {
            get;
            set;
        }

        public int GpsWeek
        {
            get;
            set;
        }

        public double GpsTimeOfWeek
        {
            get;
            set;
        }

        public Cereal.LiveLocationKalman.Status TheStatus
        {
            get;
            set;
        }

        public long UnixTimestampMillis
        {
            get;
            set;
        }

        public bool InputsOK
        {
            get;
            set;
        }

        = true;
        public bool PosenetOK
        {
            get;
            set;
        }

        = true;
        public bool GpsOK
        {
            get;
            set;
        }

        = true;
        public Cereal.LiveLocationKalman.Measurement CalibratedOrientationECEF
        {
            get;
            set;
        }

        public bool SensorsOK
        {
            get;
            set;
        }

        = true;
        public bool DeviceStable
        {
            get;
            set;
        }

        = true;
        public double TimeSinceReset
        {
            get;
            set;
        }

        public bool ExcessiveResets
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
            public Cereal.LiveLocationKalman.Measurement.READER PositionECEF => ctx.ReadStruct(0, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER PositionGeodetic => ctx.ReadStruct(1, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER VelocityECEF => ctx.ReadStruct(2, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER VelocityNED => ctx.ReadStruct(3, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER VelocityDevice => ctx.ReadStruct(4, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER AccelerationDevice => ctx.ReadStruct(5, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER OrientationECEF => ctx.ReadStruct(6, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER OrientationNED => ctx.ReadStruct(7, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER AngularVelocityDevice => ctx.ReadStruct(8, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER CalibratedOrientationNED => ctx.ReadStruct(9, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER VelocityCalibrated => ctx.ReadStruct(10, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER AccelerationCalibrated => ctx.ReadStruct(11, Cereal.LiveLocationKalman.Measurement.READER.create);
            public Cereal.LiveLocationKalman.Measurement.READER AngularVelocityCalibrated => ctx.ReadStruct(12, Cereal.LiveLocationKalman.Measurement.READER.create);
            public int GpsWeek => ctx.ReadDataInt(0UL, 0);
            public double GpsTimeOfWeek => ctx.ReadDataDouble(64UL, 0);
            public Cereal.LiveLocationKalman.Status TheStatus => (Cereal.LiveLocationKalman.Status)ctx.ReadDataUShort(32UL, (ushort)0);
            public long UnixTimestampMillis => ctx.ReadDataLong(128UL, 0L);
            public bool InputsOK => ctx.ReadDataBool(48UL, true);
            public bool PosenetOK => ctx.ReadDataBool(49UL, true);
            public bool GpsOK => ctx.ReadDataBool(50UL, true);
            public Cereal.LiveLocationKalman.Measurement.READER CalibratedOrientationECEF => ctx.ReadStruct(13, Cereal.LiveLocationKalman.Measurement.READER.create);
            public bool SensorsOK => ctx.ReadDataBool(51UL, true);
            public bool DeviceStable => ctx.ReadDataBool(52UL, true);
            public double TimeSinceReset => ctx.ReadDataDouble(192UL, 0);
            public bool ExcessiveResets => ctx.ReadDataBool(53UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(4, 14);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER PositionECEF
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(0);
                set => Link(0, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER PositionGeodetic
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(1);
                set => Link(1, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER VelocityECEF
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(2);
                set => Link(2, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER VelocityNED
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(3);
                set => Link(3, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER VelocityDevice
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(4);
                set => Link(4, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER AccelerationDevice
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(5);
                set => Link(5, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER OrientationECEF
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(6);
                set => Link(6, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER OrientationNED
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(7);
                set => Link(7, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER AngularVelocityDevice
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(8);
                set => Link(8, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER CalibratedOrientationNED
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(9);
                set => Link(9, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER VelocityCalibrated
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(10);
                set => Link(10, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER AccelerationCalibrated
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(11);
                set => Link(11, value);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER AngularVelocityCalibrated
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(12);
                set => Link(12, value);
            }

            public int GpsWeek
            {
                get => this.ReadDataInt(0UL, 0);
                set => this.WriteData(0UL, value, 0);
            }

            public double GpsTimeOfWeek
            {
                get => this.ReadDataDouble(64UL, 0);
                set => this.WriteData(64UL, value, 0);
            }

            public Cereal.LiveLocationKalman.Status TheStatus
            {
                get => (Cereal.LiveLocationKalman.Status)this.ReadDataUShort(32UL, (ushort)0);
                set => this.WriteData(32UL, (ushort)value, (ushort)0);
            }

            public long UnixTimestampMillis
            {
                get => this.ReadDataLong(128UL, 0L);
                set => this.WriteData(128UL, value, 0L);
            }

            public bool InputsOK
            {
                get => this.ReadDataBool(48UL, true);
                set => this.WriteData(48UL, value, true);
            }

            public bool PosenetOK
            {
                get => this.ReadDataBool(49UL, true);
                set => this.WriteData(49UL, value, true);
            }

            public bool GpsOK
            {
                get => this.ReadDataBool(50UL, true);
                set => this.WriteData(50UL, value, true);
            }

            public Cereal.LiveLocationKalman.Measurement.WRITER CalibratedOrientationECEF
            {
                get => BuildPointer<Cereal.LiveLocationKalman.Measurement.WRITER>(13);
                set => Link(13, value);
            }

            public bool SensorsOK
            {
                get => this.ReadDataBool(51UL, true);
                set => this.WriteData(51UL, value, true);
            }

            public bool DeviceStable
            {
                get => this.ReadDataBool(52UL, true);
                set => this.WriteData(52UL, value, true);
            }

            public double TimeSinceReset
            {
                get => this.ReadDataDouble(192UL, 0);
                set => this.WriteData(192UL, value, 0);
            }

            public bool ExcessiveResets
            {
                get => this.ReadDataBool(53UL, false);
                set => this.WriteData(53UL, value, false);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8e4dc8cc4b51fc01UL)]
        public enum Status : ushort
        {
            uninitialized,
            uncalibrated,
            valid
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xbf23f9ed66dace1cUL)]
        public class Measurement : ICapnpSerializable
        {
            public const UInt64 typeId = 0xbf23f9ed66dace1cUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Value = reader.Value;
                Std = reader.Std;
                Valid = reader.Valid;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Value.Init(Value);
                writer.Std.Init(Std);
                writer.Valid = Valid;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<double> Value
            {
                get;
                set;
            }

            public IReadOnlyList<double> Std
            {
                get;
                set;
            }

            public bool Valid
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
                public IReadOnlyList<double> Value => ctx.ReadList(0).CastDouble();
                public IReadOnlyList<double> Std => ctx.ReadList(1).CastDouble();
                public bool Valid => ctx.ReadDataBool(0UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 2);
                }

                public ListOfPrimitivesSerializer<double> Value
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<double> Std
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(1);
                    set => Link(1, value);
                }

                public bool Valid
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xaf85387b3f681406UL)]
    public class ProcLog : ICapnpSerializable
    {
        public const UInt64 typeId = 0xaf85387b3f681406UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            CpuTimes = reader.CpuTimes?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ProcLog.CPUTimes>(_));
            TheMem = CapnpSerializable.Create<Cereal.ProcLog.Mem>(reader.TheMem);
            Procs = reader.Procs?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ProcLog.Process>(_));
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.CpuTimes.Init(CpuTimes, (_s1, _v1) => _v1?.serialize(_s1));
            TheMem?.serialize(writer.TheMem);
            writer.Procs.Init(Procs, (_s1, _v1) => _v1?.serialize(_s1));
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<Cereal.ProcLog.CPUTimes> CpuTimes
        {
            get;
            set;
        }

        public Cereal.ProcLog.Mem TheMem
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.ProcLog.Process> Procs
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
            public IReadOnlyList<Cereal.ProcLog.CPUTimes.READER> CpuTimes => ctx.ReadList(0).Cast(Cereal.ProcLog.CPUTimes.READER.create);
            public Cereal.ProcLog.Mem.READER TheMem => ctx.ReadStruct(1, Cereal.ProcLog.Mem.READER.create);
            public IReadOnlyList<Cereal.ProcLog.Process.READER> Procs => ctx.ReadList(2).Cast(Cereal.ProcLog.Process.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 3);
            }

            public ListOfStructsSerializer<Cereal.ProcLog.CPUTimes.WRITER> CpuTimes
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ProcLog.CPUTimes.WRITER>>(0);
                set => Link(0, value);
            }

            public Cereal.ProcLog.Mem.WRITER TheMem
            {
                get => BuildPointer<Cereal.ProcLog.Mem.WRITER>(1);
                set => Link(1, value);
            }

            public ListOfStructsSerializer<Cereal.ProcLog.Process.WRITER> Procs
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ProcLog.Process.WRITER>>(2);
                set => Link(2, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb0b85613f19e6d28UL)]
        public class Process : ICapnpSerializable
        {
            public const UInt64 typeId = 0xb0b85613f19e6d28UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Pid = reader.Pid;
                Name = reader.Name;
                State = reader.State;
                Ppid = reader.Ppid;
                CpuUser = reader.CpuUser;
                CpuSystem = reader.CpuSystem;
                CpuChildrenUser = reader.CpuChildrenUser;
                CpuChildrenSystem = reader.CpuChildrenSystem;
                Priority = reader.Priority;
                Nice = reader.Nice;
                NumThreads = reader.NumThreads;
                StartTime = reader.StartTime;
                MemVms = reader.MemVms;
                MemRss = reader.MemRss;
                Processor = reader.Processor;
                Cmdline = reader.Cmdline;
                Exe = reader.Exe;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Pid = Pid;
                writer.Name = Name;
                writer.State = State;
                writer.Ppid = Ppid;
                writer.CpuUser = CpuUser;
                writer.CpuSystem = CpuSystem;
                writer.CpuChildrenUser = CpuChildrenUser;
                writer.CpuChildrenSystem = CpuChildrenSystem;
                writer.Priority = Priority;
                writer.Nice = Nice;
                writer.NumThreads = NumThreads;
                writer.StartTime = StartTime;
                writer.MemVms = MemVms;
                writer.MemRss = MemRss;
                writer.Processor = Processor;
                writer.Cmdline.Init(Cmdline);
                writer.Exe = Exe;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public int Pid
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public byte State
            {
                get;
                set;
            }

            public int Ppid
            {
                get;
                set;
            }

            public float CpuUser
            {
                get;
                set;
            }

            public float CpuSystem
            {
                get;
                set;
            }

            public float CpuChildrenUser
            {
                get;
                set;
            }

            public float CpuChildrenSystem
            {
                get;
                set;
            }

            public long Priority
            {
                get;
                set;
            }

            public int Nice
            {
                get;
                set;
            }

            public int NumThreads
            {
                get;
                set;
            }

            public double StartTime
            {
                get;
                set;
            }

            public ulong MemVms
            {
                get;
                set;
            }

            public ulong MemRss
            {
                get;
                set;
            }

            public int Processor
            {
                get;
                set;
            }

            public IReadOnlyList<string> Cmdline
            {
                get;
                set;
            }

            public string Exe
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
                public int Pid => ctx.ReadDataInt(0UL, 0);
                public string Name => ctx.ReadText(0, null);
                public byte State => ctx.ReadDataByte(32UL, (byte)0);
                public int Ppid => ctx.ReadDataInt(64UL, 0);
                public float CpuUser => ctx.ReadDataFloat(96UL, 0F);
                public float CpuSystem => ctx.ReadDataFloat(128UL, 0F);
                public float CpuChildrenUser => ctx.ReadDataFloat(160UL, 0F);
                public float CpuChildrenSystem => ctx.ReadDataFloat(192UL, 0F);
                public long Priority => ctx.ReadDataLong(256UL, 0L);
                public int Nice => ctx.ReadDataInt(224UL, 0);
                public int NumThreads => ctx.ReadDataInt(320UL, 0);
                public double StartTime => ctx.ReadDataDouble(384UL, 0);
                public ulong MemVms => ctx.ReadDataULong(448UL, 0UL);
                public ulong MemRss => ctx.ReadDataULong(512UL, 0UL);
                public int Processor => ctx.ReadDataInt(352UL, 0);
                public IReadOnlyList<string> Cmdline => ctx.ReadList(1).CastText2();
                public string Exe => ctx.ReadText(2, null);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(9, 3);
                }

                public int Pid
                {
                    get => this.ReadDataInt(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public string Name
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public byte State
                {
                    get => this.ReadDataByte(32UL, (byte)0);
                    set => this.WriteData(32UL, value, (byte)0);
                }

                public int Ppid
                {
                    get => this.ReadDataInt(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public float CpuUser
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float CpuSystem
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float CpuChildrenUser
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float CpuChildrenSystem
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public long Priority
                {
                    get => this.ReadDataLong(256UL, 0L);
                    set => this.WriteData(256UL, value, 0L);
                }

                public int Nice
                {
                    get => this.ReadDataInt(224UL, 0);
                    set => this.WriteData(224UL, value, 0);
                }

                public int NumThreads
                {
                    get => this.ReadDataInt(320UL, 0);
                    set => this.WriteData(320UL, value, 0);
                }

                public double StartTime
                {
                    get => this.ReadDataDouble(384UL, 0);
                    set => this.WriteData(384UL, value, 0);
                }

                public ulong MemVms
                {
                    get => this.ReadDataULong(448UL, 0UL);
                    set => this.WriteData(448UL, value, 0UL);
                }

                public ulong MemRss
                {
                    get => this.ReadDataULong(512UL, 0UL);
                    set => this.WriteData(512UL, value, 0UL);
                }

                public int Processor
                {
                    get => this.ReadDataInt(352UL, 0);
                    set => this.WriteData(352UL, value, 0);
                }

                public ListOfTextSerializer Cmdline
                {
                    get => BuildPointer<ListOfTextSerializer>(1);
                    set => Link(1, value);
                }

                public string Exe
                {
                    get => this.ReadText(2, null);
                    set => this.WriteText(2, value, null);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf189c8c5bf2ce087UL)]
        public class CPUTimes : ICapnpSerializable
        {
            public const UInt64 typeId = 0xf189c8c5bf2ce087UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                CpuNum = reader.CpuNum;
                User = reader.User;
                Nice = reader.Nice;
                System = reader.System;
                Idle = reader.Idle;
                Iowait = reader.Iowait;
                Irq = reader.Irq;
                Softirq = reader.Softirq;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.CpuNum = CpuNum;
                writer.User = User;
                writer.Nice = Nice;
                writer.System = System;
                writer.Idle = Idle;
                writer.Iowait = Iowait;
                writer.Irq = Irq;
                writer.Softirq = Softirq;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public long CpuNum
            {
                get;
                set;
            }

            public float User
            {
                get;
                set;
            }

            public float Nice
            {
                get;
                set;
            }

            public float System
            {
                get;
                set;
            }

            public float Idle
            {
                get;
                set;
            }

            public float Iowait
            {
                get;
                set;
            }

            public float Irq
            {
                get;
                set;
            }

            public float Softirq
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
                public long CpuNum => ctx.ReadDataLong(0UL, 0L);
                public float User => ctx.ReadDataFloat(64UL, 0F);
                public float Nice => ctx.ReadDataFloat(96UL, 0F);
                public float System => ctx.ReadDataFloat(128UL, 0F);
                public float Idle => ctx.ReadDataFloat(160UL, 0F);
                public float Iowait => ctx.ReadDataFloat(192UL, 0F);
                public float Irq => ctx.ReadDataFloat(224UL, 0F);
                public float Softirq => ctx.ReadDataFloat(256UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(5, 0);
                }

                public long CpuNum
                {
                    get => this.ReadDataLong(0UL, 0L);
                    set => this.WriteData(0UL, value, 0L);
                }

                public float User
                {
                    get => this.ReadDataFloat(64UL, 0F);
                    set => this.WriteData(64UL, value, 0F);
                }

                public float Nice
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public float System
                {
                    get => this.ReadDataFloat(128UL, 0F);
                    set => this.WriteData(128UL, value, 0F);
                }

                public float Idle
                {
                    get => this.ReadDataFloat(160UL, 0F);
                    set => this.WriteData(160UL, value, 0F);
                }

                public float Iowait
                {
                    get => this.ReadDataFloat(192UL, 0F);
                    set => this.WriteData(192UL, value, 0F);
                }

                public float Irq
                {
                    get => this.ReadDataFloat(224UL, 0F);
                    set => this.WriteData(224UL, value, 0F);
                }

                public float Softirq
                {
                    get => this.ReadDataFloat(256UL, 0F);
                    set => this.WriteData(256UL, value, 0F);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfd095f94f08b3fd4UL)]
        public class Mem : ICapnpSerializable
        {
            public const UInt64 typeId = 0xfd095f94f08b3fd4UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Total = reader.Total;
                Free = reader.Free;
                Available = reader.Available;
                Buffers = reader.Buffers;
                Cached = reader.Cached;
                Active = reader.Active;
                Inactive = reader.Inactive;
                Shared = reader.Shared;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Total = Total;
                writer.Free = Free;
                writer.Available = Available;
                writer.Buffers = Buffers;
                writer.Cached = Cached;
                writer.Active = Active;
                writer.Inactive = Inactive;
                writer.Shared = Shared;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public ulong Total
            {
                get;
                set;
            }

            public ulong Free
            {
                get;
                set;
            }

            public ulong Available
            {
                get;
                set;
            }

            public ulong Buffers
            {
                get;
                set;
            }

            public ulong Cached
            {
                get;
                set;
            }

            public ulong Active
            {
                get;
                set;
            }

            public ulong Inactive
            {
                get;
                set;
            }

            public ulong Shared
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
                public ulong Total => ctx.ReadDataULong(0UL, 0UL);
                public ulong Free => ctx.ReadDataULong(64UL, 0UL);
                public ulong Available => ctx.ReadDataULong(128UL, 0UL);
                public ulong Buffers => ctx.ReadDataULong(192UL, 0UL);
                public ulong Cached => ctx.ReadDataULong(256UL, 0UL);
                public ulong Active => ctx.ReadDataULong(320UL, 0UL);
                public ulong Inactive => ctx.ReadDataULong(384UL, 0UL);
                public ulong Shared => ctx.ReadDataULong(448UL, 0UL);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(8, 0);
                }

                public ulong Total
                {
                    get => this.ReadDataULong(0UL, 0UL);
                    set => this.WriteData(0UL, value, 0UL);
                }

                public ulong Free
                {
                    get => this.ReadDataULong(64UL, 0UL);
                    set => this.WriteData(64UL, value, 0UL);
                }

                public ulong Available
                {
                    get => this.ReadDataULong(128UL, 0UL);
                    set => this.WriteData(128UL, value, 0UL);
                }

                public ulong Buffers
                {
                    get => this.ReadDataULong(192UL, 0UL);
                    set => this.WriteData(192UL, value, 0UL);
                }

                public ulong Cached
                {
                    get => this.ReadDataULong(256UL, 0UL);
                    set => this.WriteData(256UL, value, 0UL);
                }

                public ulong Active
                {
                    get => this.ReadDataULong(320UL, 0UL);
                    set => this.WriteData(320UL, value, 0UL);
                }

                public ulong Inactive
                {
                    get => this.ReadDataULong(384UL, 0UL);
                    set => this.WriteData(384UL, value, 0UL);
                }

                public ulong Shared
                {
                    get => this.ReadDataULong(448UL, 0UL);
                    set => this.WriteData(448UL, value, 0UL);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x85dddd7ce6cefa5dUL)]
    public class UbloxGnss : ICapnpSerializable
    {
        public const UInt64 typeId = 0x85dddd7ce6cefa5dUL;
        public enum WHICH : ushort
        {
            TheMeasurementReport = 0,
            TheEphemeris = 1,
            TheIonoData = 2,
            TheHwStatus = 3,
            TheHwStatus2 = 4,
            undefined = 65535
        }

        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            switch (reader.which)
            {
                case WHICH.TheMeasurementReport:
                    TheMeasurementReport = CapnpSerializable.Create<Cereal.UbloxGnss.MeasurementReport>(reader.TheMeasurementReport);
                    break;
                case WHICH.TheEphemeris:
                    TheEphemeris = CapnpSerializable.Create<Cereal.UbloxGnss.Ephemeris>(reader.TheEphemeris);
                    break;
                case WHICH.TheIonoData:
                    TheIonoData = CapnpSerializable.Create<Cereal.UbloxGnss.IonoData>(reader.TheIonoData);
                    break;
                case WHICH.TheHwStatus:
                    TheHwStatus = CapnpSerializable.Create<Cereal.UbloxGnss.HwStatus>(reader.TheHwStatus);
                    break;
                case WHICH.TheHwStatus2:
                    TheHwStatus2 = CapnpSerializable.Create<Cereal.UbloxGnss.HwStatus2>(reader.TheHwStatus2);
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
                    case WHICH.TheMeasurementReport:
                        _content = null;
                        break;
                    case WHICH.TheEphemeris:
                        _content = null;
                        break;
                    case WHICH.TheIonoData:
                        _content = null;
                        break;
                    case WHICH.TheHwStatus:
                        _content = null;
                        break;
                    case WHICH.TheHwStatus2:
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
                case WHICH.TheEphemeris:
                    TheEphemeris?.serialize(writer.TheEphemeris);
                    break;
                case WHICH.TheIonoData:
                    TheIonoData?.serialize(writer.TheIonoData);
                    break;
                case WHICH.TheHwStatus:
                    TheHwStatus?.serialize(writer.TheHwStatus);
                    break;
                case WHICH.TheHwStatus2:
                    TheHwStatus2?.serialize(writer.TheHwStatus2);
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

        public Cereal.UbloxGnss.MeasurementReport TheMeasurementReport
        {
            get => _which == WHICH.TheMeasurementReport ? (Cereal.UbloxGnss.MeasurementReport)_content : null;
            set
            {
                _which = WHICH.TheMeasurementReport;
                _content = value;
            }
        }

        public Cereal.UbloxGnss.Ephemeris TheEphemeris
        {
            get => _which == WHICH.TheEphemeris ? (Cereal.UbloxGnss.Ephemeris)_content : null;
            set
            {
                _which = WHICH.TheEphemeris;
                _content = value;
            }
        }

        public Cereal.UbloxGnss.IonoData TheIonoData
        {
            get => _which == WHICH.TheIonoData ? (Cereal.UbloxGnss.IonoData)_content : null;
            set
            {
                _which = WHICH.TheIonoData;
                _content = value;
            }
        }

        public Cereal.UbloxGnss.HwStatus TheHwStatus
        {
            get => _which == WHICH.TheHwStatus ? (Cereal.UbloxGnss.HwStatus)_content : null;
            set
            {
                _which = WHICH.TheHwStatus;
                _content = value;
            }
        }

        public Cereal.UbloxGnss.HwStatus2 TheHwStatus2
        {
            get => _which == WHICH.TheHwStatus2 ? (Cereal.UbloxGnss.HwStatus2)_content : null;
            set
            {
                _which = WHICH.TheHwStatus2;
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
            public Cereal.UbloxGnss.MeasurementReport.READER TheMeasurementReport => which == WHICH.TheMeasurementReport ? ctx.ReadStruct(0, Cereal.UbloxGnss.MeasurementReport.READER.create) : default;
            public Cereal.UbloxGnss.Ephemeris.READER TheEphemeris => which == WHICH.TheEphemeris ? ctx.ReadStruct(0, Cereal.UbloxGnss.Ephemeris.READER.create) : default;
            public Cereal.UbloxGnss.IonoData.READER TheIonoData => which == WHICH.TheIonoData ? ctx.ReadStruct(0, Cereal.UbloxGnss.IonoData.READER.create) : default;
            public Cereal.UbloxGnss.HwStatus.READER TheHwStatus => which == WHICH.TheHwStatus ? ctx.ReadStruct(0, Cereal.UbloxGnss.HwStatus.READER.create) : default;
            public Cereal.UbloxGnss.HwStatus2.READER TheHwStatus2 => which == WHICH.TheHwStatus2 ? ctx.ReadStruct(0, Cereal.UbloxGnss.HwStatus2.READER.create) : default;
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

            public Cereal.UbloxGnss.MeasurementReport.WRITER TheMeasurementReport
            {
                get => which == WHICH.TheMeasurementReport ? BuildPointer<Cereal.UbloxGnss.MeasurementReport.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.UbloxGnss.Ephemeris.WRITER TheEphemeris
            {
                get => which == WHICH.TheEphemeris ? BuildPointer<Cereal.UbloxGnss.Ephemeris.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.UbloxGnss.IonoData.WRITER TheIonoData
            {
                get => which == WHICH.TheIonoData ? BuildPointer<Cereal.UbloxGnss.IonoData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.UbloxGnss.HwStatus.WRITER TheHwStatus
            {
                get => which == WHICH.TheHwStatus ? BuildPointer<Cereal.UbloxGnss.HwStatus.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.UbloxGnss.HwStatus2.WRITER TheHwStatus2
            {
                get => which == WHICH.TheHwStatus2 ? BuildPointer<Cereal.UbloxGnss.HwStatus2.WRITER>(0) : default;
                set => Link(0, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa73ba546a29820f4UL)]
        public class MeasurementReport : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa73ba546a29820f4UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                RcvTow = reader.RcvTow;
                GpsWeek = reader.GpsWeek;
                LeapSeconds = reader.LeapSeconds;
                TheReceiverStatus = CapnpSerializable.Create<Cereal.UbloxGnss.MeasurementReport.ReceiverStatus>(reader.TheReceiverStatus);
                NumMeas = reader.NumMeas;
                Measurements = reader.Measurements?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.UbloxGnss.MeasurementReport.Measurement>(_));
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.RcvTow = RcvTow;
                writer.GpsWeek = GpsWeek;
                writer.LeapSeconds = LeapSeconds;
                TheReceiverStatus?.serialize(writer.TheReceiverStatus);
                writer.NumMeas = NumMeas;
                writer.Measurements.Init(Measurements, (_s1, _v1) => _v1?.serialize(_s1));
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public double RcvTow
            {
                get;
                set;
            }

            public ushort GpsWeek
            {
                get;
                set;
            }

            public ushort LeapSeconds
            {
                get;
                set;
            }

            public Cereal.UbloxGnss.MeasurementReport.ReceiverStatus TheReceiverStatus
            {
                get;
                set;
            }

            public byte NumMeas
            {
                get;
                set;
            }

            public IReadOnlyList<Cereal.UbloxGnss.MeasurementReport.Measurement> Measurements
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
                public double RcvTow => ctx.ReadDataDouble(0UL, 0);
                public ushort GpsWeek => ctx.ReadDataUShort(64UL, (ushort)0);
                public ushort LeapSeconds => ctx.ReadDataUShort(80UL, (ushort)0);
                public Cereal.UbloxGnss.MeasurementReport.ReceiverStatus.READER TheReceiverStatus => ctx.ReadStruct(0, Cereal.UbloxGnss.MeasurementReport.ReceiverStatus.READER.create);
                public byte NumMeas => ctx.ReadDataByte(96UL, (byte)0);
                public IReadOnlyList<Cereal.UbloxGnss.MeasurementReport.Measurement.READER> Measurements => ctx.ReadList(1).Cast(Cereal.UbloxGnss.MeasurementReport.Measurement.READER.create);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 2);
                }

                public double RcvTow
                {
                    get => this.ReadDataDouble(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public ushort GpsWeek
                {
                    get => this.ReadDataUShort(64UL, (ushort)0);
                    set => this.WriteData(64UL, value, (ushort)0);
                }

                public ushort LeapSeconds
                {
                    get => this.ReadDataUShort(80UL, (ushort)0);
                    set => this.WriteData(80UL, value, (ushort)0);
                }

                public Cereal.UbloxGnss.MeasurementReport.ReceiverStatus.WRITER TheReceiverStatus
                {
                    get => BuildPointer<Cereal.UbloxGnss.MeasurementReport.ReceiverStatus.WRITER>(0);
                    set => Link(0, value);
                }

                public byte NumMeas
                {
                    get => this.ReadDataByte(96UL, (byte)0);
                    set => this.WriteData(96UL, value, (byte)0);
                }

                public ListOfStructsSerializer<Cereal.UbloxGnss.MeasurementReport.Measurement.WRITER> Measurements
                {
                    get => BuildPointer<ListOfStructsSerializer<Cereal.UbloxGnss.MeasurementReport.Measurement.WRITER>>(1);
                    set => Link(1, value);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfbb838d65160aab6UL)]
            public class ReceiverStatus : ICapnpSerializable
            {
                public const UInt64 typeId = 0xfbb838d65160aab6UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    LeapSecValid = reader.LeapSecValid;
                    ClkReset = reader.ClkReset;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.LeapSecValid = LeapSecValid;
                    writer.ClkReset = ClkReset;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public bool LeapSecValid
                {
                    get;
                    set;
                }

                public bool ClkReset
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
                    public bool LeapSecValid => ctx.ReadDataBool(0UL, false);
                    public bool ClkReset => ctx.ReadDataBool(1UL, false);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(1, 0);
                    }

                    public bool LeapSecValid
                    {
                        get => this.ReadDataBool(0UL, false);
                        set => this.WriteData(0UL, value, false);
                    }

                    public bool ClkReset
                    {
                        get => this.ReadDataBool(1UL, false);
                        set => this.WriteData(1UL, value, false);
                    }
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x8f8a655f5e326401UL)]
            public class Measurement : ICapnpSerializable
            {
                public const UInt64 typeId = 0x8f8a655f5e326401UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    SvId = reader.SvId;
                    TheTrackingStatus = CapnpSerializable.Create<Cereal.UbloxGnss.MeasurementReport.Measurement.TrackingStatus>(reader.TheTrackingStatus);
                    Pseudorange = reader.Pseudorange;
                    CarrierCycles = reader.CarrierCycles;
                    Doppler = reader.Doppler;
                    GnssId = reader.GnssId;
                    GlonassFrequencyIndex = reader.GlonassFrequencyIndex;
                    Locktime = reader.Locktime;
                    Cno = reader.Cno;
                    PseudorangeStdev = reader.PseudorangeStdev;
                    CarrierPhaseStdev = reader.CarrierPhaseStdev;
                    DopplerStdev = reader.DopplerStdev;
                    SigId = reader.SigId;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.SvId = SvId;
                    TheTrackingStatus?.serialize(writer.TheTrackingStatus);
                    writer.Pseudorange = Pseudorange;
                    writer.CarrierCycles = CarrierCycles;
                    writer.Doppler = Doppler;
                    writer.GnssId = GnssId;
                    writer.GlonassFrequencyIndex = GlonassFrequencyIndex;
                    writer.Locktime = Locktime;
                    writer.Cno = Cno;
                    writer.PseudorangeStdev = PseudorangeStdev;
                    writer.CarrierPhaseStdev = CarrierPhaseStdev;
                    writer.DopplerStdev = DopplerStdev;
                    writer.SigId = SigId;
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

                public Cereal.UbloxGnss.MeasurementReport.Measurement.TrackingStatus TheTrackingStatus
                {
                    get;
                    set;
                }

                public double Pseudorange
                {
                    get;
                    set;
                }

                public double CarrierCycles
                {
                    get;
                    set;
                }

                public float Doppler
                {
                    get;
                    set;
                }

                public byte GnssId
                {
                    get;
                    set;
                }

                public byte GlonassFrequencyIndex
                {
                    get;
                    set;
                }

                public ushort Locktime
                {
                    get;
                    set;
                }

                public byte Cno
                {
                    get;
                    set;
                }

                public float PseudorangeStdev
                {
                    get;
                    set;
                }

                public float CarrierPhaseStdev
                {
                    get;
                    set;
                }

                public float DopplerStdev
                {
                    get;
                    set;
                }

                public byte SigId
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
                    public Cereal.UbloxGnss.MeasurementReport.Measurement.TrackingStatus.READER TheTrackingStatus => ctx.ReadStruct(0, Cereal.UbloxGnss.MeasurementReport.Measurement.TrackingStatus.READER.create);
                    public double Pseudorange => ctx.ReadDataDouble(64UL, 0);
                    public double CarrierCycles => ctx.ReadDataDouble(128UL, 0);
                    public float Doppler => ctx.ReadDataFloat(32UL, 0F);
                    public byte GnssId => ctx.ReadDataByte(8UL, (byte)0);
                    public byte GlonassFrequencyIndex => ctx.ReadDataByte(16UL, (byte)0);
                    public ushort Locktime => ctx.ReadDataUShort(192UL, (ushort)0);
                    public byte Cno => ctx.ReadDataByte(24UL, (byte)0);
                    public float PseudorangeStdev => ctx.ReadDataFloat(224UL, 0F);
                    public float CarrierPhaseStdev => ctx.ReadDataFloat(256UL, 0F);
                    public float DopplerStdev => ctx.ReadDataFloat(288UL, 0F);
                    public byte SigId => ctx.ReadDataByte(208UL, (byte)0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(5, 1);
                    }

                    public byte SvId
                    {
                        get => this.ReadDataByte(0UL, (byte)0);
                        set => this.WriteData(0UL, value, (byte)0);
                    }

                    public Cereal.UbloxGnss.MeasurementReport.Measurement.TrackingStatus.WRITER TheTrackingStatus
                    {
                        get => BuildPointer<Cereal.UbloxGnss.MeasurementReport.Measurement.TrackingStatus.WRITER>(0);
                        set => Link(0, value);
                    }

                    public double Pseudorange
                    {
                        get => this.ReadDataDouble(64UL, 0);
                        set => this.WriteData(64UL, value, 0);
                    }

                    public double CarrierCycles
                    {
                        get => this.ReadDataDouble(128UL, 0);
                        set => this.WriteData(128UL, value, 0);
                    }

                    public float Doppler
                    {
                        get => this.ReadDataFloat(32UL, 0F);
                        set => this.WriteData(32UL, value, 0F);
                    }

                    public byte GnssId
                    {
                        get => this.ReadDataByte(8UL, (byte)0);
                        set => this.WriteData(8UL, value, (byte)0);
                    }

                    public byte GlonassFrequencyIndex
                    {
                        get => this.ReadDataByte(16UL, (byte)0);
                        set => this.WriteData(16UL, value, (byte)0);
                    }

                    public ushort Locktime
                    {
                        get => this.ReadDataUShort(192UL, (ushort)0);
                        set => this.WriteData(192UL, value, (ushort)0);
                    }

                    public byte Cno
                    {
                        get => this.ReadDataByte(24UL, (byte)0);
                        set => this.WriteData(24UL, value, (byte)0);
                    }

                    public float PseudorangeStdev
                    {
                        get => this.ReadDataFloat(224UL, 0F);
                        set => this.WriteData(224UL, value, 0F);
                    }

                    public float CarrierPhaseStdev
                    {
                        get => this.ReadDataFloat(256UL, 0F);
                        set => this.WriteData(256UL, value, 0F);
                    }

                    public float DopplerStdev
                    {
                        get => this.ReadDataFloat(288UL, 0F);
                        set => this.WriteData(288UL, value, 0F);
                    }

                    public byte SigId
                    {
                        get => this.ReadDataByte(208UL, (byte)0);
                        set => this.WriteData(208UL, value, (byte)0);
                    }
                }

                [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe8efb3a802b299b2UL)]
                public class TrackingStatus : ICapnpSerializable
                {
                    public const UInt64 typeId = 0xe8efb3a802b299b2UL;
                    void ICapnpSerializable.Deserialize(DeserializerState arg_)
                    {
                        var reader = READER.create(arg_);
                        PseudorangeValid = reader.PseudorangeValid;
                        CarrierPhaseValid = reader.CarrierPhaseValid;
                        HalfCycleValid = reader.HalfCycleValid;
                        HalfCycleSubtracted = reader.HalfCycleSubtracted;
                        applyDefaults();
                    }

                    public void serialize(WRITER writer)
                    {
                        writer.PseudorangeValid = PseudorangeValid;
                        writer.CarrierPhaseValid = CarrierPhaseValid;
                        writer.HalfCycleValid = HalfCycleValid;
                        writer.HalfCycleSubtracted = HalfCycleSubtracted;
                    }

                    void ICapnpSerializable.Serialize(SerializerState arg_)
                    {
                        serialize(arg_.Rewrap<WRITER>());
                    }

                    public void applyDefaults()
                    {
                    }

                    public bool PseudorangeValid
                    {
                        get;
                        set;
                    }

                    public bool CarrierPhaseValid
                    {
                        get;
                        set;
                    }

                    public bool HalfCycleValid
                    {
                        get;
                        set;
                    }

                    public bool HalfCycleSubtracted
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
                        public bool PseudorangeValid => ctx.ReadDataBool(0UL, false);
                        public bool CarrierPhaseValid => ctx.ReadDataBool(1UL, false);
                        public bool HalfCycleValid => ctx.ReadDataBool(2UL, false);
                        public bool HalfCycleSubtracted => ctx.ReadDataBool(3UL, false);
                    }

                    public class WRITER : SerializerState
                    {
                        public WRITER()
                        {
                            this.SetStruct(1, 0);
                        }

                        public bool PseudorangeValid
                        {
                            get => this.ReadDataBool(0UL, false);
                            set => this.WriteData(0UL, value, false);
                        }

                        public bool CarrierPhaseValid
                        {
                            get => this.ReadDataBool(1UL, false);
                            set => this.WriteData(1UL, value, false);
                        }

                        public bool HalfCycleValid
                        {
                            get => this.ReadDataBool(2UL, false);
                            set => this.WriteData(2UL, value, false);
                        }

                        public bool HalfCycleSubtracted
                        {
                            get => this.ReadDataBool(3UL, false);
                            set => this.WriteData(3UL, value, false);
                        }
                    }
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd8418c788118f85cUL)]
        public class Ephemeris : ICapnpSerializable
        {
            public const UInt64 typeId = 0xd8418c788118f85cUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                SvId = reader.SvId;
                Year = reader.Year;
                Month = reader.Month;
                Day = reader.Day;
                Hour = reader.Hour;
                Minute = reader.Minute;
                Second = reader.Second;
                Af0 = reader.Af0;
                Af1 = reader.Af1;
                Af2 = reader.Af2;
                Iode = reader.Iode;
                Crs = reader.Crs;
                DeltaN = reader.DeltaN;
                M0 = reader.M0;
                Cuc = reader.Cuc;
                Ecc = reader.Ecc;
                Cus = reader.Cus;
                A = reader.A;
                Toe = reader.Toe;
                Cic = reader.Cic;
                Omega0 = reader.Omega0;
                Cis = reader.Cis;
                I0 = reader.I0;
                Crc = reader.Crc;
                Omega = reader.Omega;
                OmegaDot = reader.OmegaDot;
                IDot = reader.IDot;
                CodesL2 = reader.CodesL2;
                GpsWeek = reader.GpsWeek;
                L2 = reader.L2;
                SvAcc = reader.SvAcc;
                SvHealth = reader.SvHealth;
                Tgd = reader.Tgd;
                Iodc = reader.Iodc;
                TransmissionTime = reader.TransmissionTime;
                FitInterval = reader.FitInterval;
                Toc = reader.Toc;
                IonoCoeffsValid = reader.IonoCoeffsValid;
                IonoAlpha = reader.IonoAlpha;
                IonoBeta = reader.IonoBeta;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.SvId = SvId;
                writer.Year = Year;
                writer.Month = Month;
                writer.Day = Day;
                writer.Hour = Hour;
                writer.Minute = Minute;
                writer.Second = Second;
                writer.Af0 = Af0;
                writer.Af1 = Af1;
                writer.Af2 = Af2;
                writer.Iode = Iode;
                writer.Crs = Crs;
                writer.DeltaN = DeltaN;
                writer.M0 = M0;
                writer.Cuc = Cuc;
                writer.Ecc = Ecc;
                writer.Cus = Cus;
                writer.A = A;
                writer.Toe = Toe;
                writer.Cic = Cic;
                writer.Omega0 = Omega0;
                writer.Cis = Cis;
                writer.I0 = I0;
                writer.Crc = Crc;
                writer.Omega = Omega;
                writer.OmegaDot = OmegaDot;
                writer.IDot = IDot;
                writer.CodesL2 = CodesL2;
                writer.GpsWeek = GpsWeek;
                writer.L2 = L2;
                writer.SvAcc = SvAcc;
                writer.SvHealth = SvHealth;
                writer.Tgd = Tgd;
                writer.Iodc = Iodc;
                writer.TransmissionTime = TransmissionTime;
                writer.FitInterval = FitInterval;
                writer.Toc = Toc;
                writer.IonoCoeffsValid = IonoCoeffsValid;
                writer.IonoAlpha.Init(IonoAlpha);
                writer.IonoBeta.Init(IonoBeta);
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

            public ushort Year
            {
                get;
                set;
            }

            public ushort Month
            {
                get;
                set;
            }

            public ushort Day
            {
                get;
                set;
            }

            public ushort Hour
            {
                get;
                set;
            }

            public ushort Minute
            {
                get;
                set;
            }

            public float Second
            {
                get;
                set;
            }

            public double Af0
            {
                get;
                set;
            }

            public double Af1
            {
                get;
                set;
            }

            public double Af2
            {
                get;
                set;
            }

            public double Iode
            {
                get;
                set;
            }

            public double Crs
            {
                get;
                set;
            }

            public double DeltaN
            {
                get;
                set;
            }

            public double M0
            {
                get;
                set;
            }

            public double Cuc
            {
                get;
                set;
            }

            public double Ecc
            {
                get;
                set;
            }

            public double Cus
            {
                get;
                set;
            }

            public double A
            {
                get;
                set;
            }

            public double Toe
            {
                get;
                set;
            }

            public double Cic
            {
                get;
                set;
            }

            public double Omega0
            {
                get;
                set;
            }

            public double Cis
            {
                get;
                set;
            }

            public double I0
            {
                get;
                set;
            }

            public double Crc
            {
                get;
                set;
            }

            public double Omega
            {
                get;
                set;
            }

            public double OmegaDot
            {
                get;
                set;
            }

            public double IDot
            {
                get;
                set;
            }

            public double CodesL2
            {
                get;
                set;
            }

            public double GpsWeek
            {
                get;
                set;
            }

            public double L2
            {
                get;
                set;
            }

            public double SvAcc
            {
                get;
                set;
            }

            public double SvHealth
            {
                get;
                set;
            }

            public double Tgd
            {
                get;
                set;
            }

            public double Iodc
            {
                get;
                set;
            }

            public double TransmissionTime
            {
                get;
                set;
            }

            public double FitInterval
            {
                get;
                set;
            }

            public double Toc
            {
                get;
                set;
            }

            public bool IonoCoeffsValid
            {
                get;
                set;
            }

            public IReadOnlyList<double> IonoAlpha
            {
                get;
                set;
            }

            public IReadOnlyList<double> IonoBeta
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
                public ushort Year => ctx.ReadDataUShort(16UL, (ushort)0);
                public ushort Month => ctx.ReadDataUShort(32UL, (ushort)0);
                public ushort Day => ctx.ReadDataUShort(48UL, (ushort)0);
                public ushort Hour => ctx.ReadDataUShort(64UL, (ushort)0);
                public ushort Minute => ctx.ReadDataUShort(80UL, (ushort)0);
                public float Second => ctx.ReadDataFloat(96UL, 0F);
                public double Af0 => ctx.ReadDataDouble(128UL, 0);
                public double Af1 => ctx.ReadDataDouble(192UL, 0);
                public double Af2 => ctx.ReadDataDouble(256UL, 0);
                public double Iode => ctx.ReadDataDouble(320UL, 0);
                public double Crs => ctx.ReadDataDouble(384UL, 0);
                public double DeltaN => ctx.ReadDataDouble(448UL, 0);
                public double M0 => ctx.ReadDataDouble(512UL, 0);
                public double Cuc => ctx.ReadDataDouble(576UL, 0);
                public double Ecc => ctx.ReadDataDouble(640UL, 0);
                public double Cus => ctx.ReadDataDouble(704UL, 0);
                public double A => ctx.ReadDataDouble(768UL, 0);
                public double Toe => ctx.ReadDataDouble(832UL, 0);
                public double Cic => ctx.ReadDataDouble(896UL, 0);
                public double Omega0 => ctx.ReadDataDouble(960UL, 0);
                public double Cis => ctx.ReadDataDouble(1024UL, 0);
                public double I0 => ctx.ReadDataDouble(1088UL, 0);
                public double Crc => ctx.ReadDataDouble(1152UL, 0);
                public double Omega => ctx.ReadDataDouble(1216UL, 0);
                public double OmegaDot => ctx.ReadDataDouble(1280UL, 0);
                public double IDot => ctx.ReadDataDouble(1344UL, 0);
                public double CodesL2 => ctx.ReadDataDouble(1408UL, 0);
                public double GpsWeek => ctx.ReadDataDouble(1472UL, 0);
                public double L2 => ctx.ReadDataDouble(1536UL, 0);
                public double SvAcc => ctx.ReadDataDouble(1600UL, 0);
                public double SvHealth => ctx.ReadDataDouble(1664UL, 0);
                public double Tgd => ctx.ReadDataDouble(1728UL, 0);
                public double Iodc => ctx.ReadDataDouble(1792UL, 0);
                public double TransmissionTime => ctx.ReadDataDouble(1856UL, 0);
                public double FitInterval => ctx.ReadDataDouble(1920UL, 0);
                public double Toc => ctx.ReadDataDouble(1984UL, 0);
                public bool IonoCoeffsValid => ctx.ReadDataBool(2048UL, false);
                public IReadOnlyList<double> IonoAlpha => ctx.ReadList(0).CastDouble();
                public IReadOnlyList<double> IonoBeta => ctx.ReadList(1).CastDouble();
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(33, 2);
                }

                public ushort SvId
                {
                    get => this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, value, (ushort)0);
                }

                public ushort Year
                {
                    get => this.ReadDataUShort(16UL, (ushort)0);
                    set => this.WriteData(16UL, value, (ushort)0);
                }

                public ushort Month
                {
                    get => this.ReadDataUShort(32UL, (ushort)0);
                    set => this.WriteData(32UL, value, (ushort)0);
                }

                public ushort Day
                {
                    get => this.ReadDataUShort(48UL, (ushort)0);
                    set => this.WriteData(48UL, value, (ushort)0);
                }

                public ushort Hour
                {
                    get => this.ReadDataUShort(64UL, (ushort)0);
                    set => this.WriteData(64UL, value, (ushort)0);
                }

                public ushort Minute
                {
                    get => this.ReadDataUShort(80UL, (ushort)0);
                    set => this.WriteData(80UL, value, (ushort)0);
                }

                public float Second
                {
                    get => this.ReadDataFloat(96UL, 0F);
                    set => this.WriteData(96UL, value, 0F);
                }

                public double Af0
                {
                    get => this.ReadDataDouble(128UL, 0);
                    set => this.WriteData(128UL, value, 0);
                }

                public double Af1
                {
                    get => this.ReadDataDouble(192UL, 0);
                    set => this.WriteData(192UL, value, 0);
                }

                public double Af2
                {
                    get => this.ReadDataDouble(256UL, 0);
                    set => this.WriteData(256UL, value, 0);
                }

                public double Iode
                {
                    get => this.ReadDataDouble(320UL, 0);
                    set => this.WriteData(320UL, value, 0);
                }

                public double Crs
                {
                    get => this.ReadDataDouble(384UL, 0);
                    set => this.WriteData(384UL, value, 0);
                }

                public double DeltaN
                {
                    get => this.ReadDataDouble(448UL, 0);
                    set => this.WriteData(448UL, value, 0);
                }

                public double M0
                {
                    get => this.ReadDataDouble(512UL, 0);
                    set => this.WriteData(512UL, value, 0);
                }

                public double Cuc
                {
                    get => this.ReadDataDouble(576UL, 0);
                    set => this.WriteData(576UL, value, 0);
                }

                public double Ecc
                {
                    get => this.ReadDataDouble(640UL, 0);
                    set => this.WriteData(640UL, value, 0);
                }

                public double Cus
                {
                    get => this.ReadDataDouble(704UL, 0);
                    set => this.WriteData(704UL, value, 0);
                }

                public double A
                {
                    get => this.ReadDataDouble(768UL, 0);
                    set => this.WriteData(768UL, value, 0);
                }

                public double Toe
                {
                    get => this.ReadDataDouble(832UL, 0);
                    set => this.WriteData(832UL, value, 0);
                }

                public double Cic
                {
                    get => this.ReadDataDouble(896UL, 0);
                    set => this.WriteData(896UL, value, 0);
                }

                public double Omega0
                {
                    get => this.ReadDataDouble(960UL, 0);
                    set => this.WriteData(960UL, value, 0);
                }

                public double Cis
                {
                    get => this.ReadDataDouble(1024UL, 0);
                    set => this.WriteData(1024UL, value, 0);
                }

                public double I0
                {
                    get => this.ReadDataDouble(1088UL, 0);
                    set => this.WriteData(1088UL, value, 0);
                }

                public double Crc
                {
                    get => this.ReadDataDouble(1152UL, 0);
                    set => this.WriteData(1152UL, value, 0);
                }

                public double Omega
                {
                    get => this.ReadDataDouble(1216UL, 0);
                    set => this.WriteData(1216UL, value, 0);
                }

                public double OmegaDot
                {
                    get => this.ReadDataDouble(1280UL, 0);
                    set => this.WriteData(1280UL, value, 0);
                }

                public double IDot
                {
                    get => this.ReadDataDouble(1344UL, 0);
                    set => this.WriteData(1344UL, value, 0);
                }

                public double CodesL2
                {
                    get => this.ReadDataDouble(1408UL, 0);
                    set => this.WriteData(1408UL, value, 0);
                }

                public double GpsWeek
                {
                    get => this.ReadDataDouble(1472UL, 0);
                    set => this.WriteData(1472UL, value, 0);
                }

                public double L2
                {
                    get => this.ReadDataDouble(1536UL, 0);
                    set => this.WriteData(1536UL, value, 0);
                }

                public double SvAcc
                {
                    get => this.ReadDataDouble(1600UL, 0);
                    set => this.WriteData(1600UL, value, 0);
                }

                public double SvHealth
                {
                    get => this.ReadDataDouble(1664UL, 0);
                    set => this.WriteData(1664UL, value, 0);
                }

                public double Tgd
                {
                    get => this.ReadDataDouble(1728UL, 0);
                    set => this.WriteData(1728UL, value, 0);
                }

                public double Iodc
                {
                    get => this.ReadDataDouble(1792UL, 0);
                    set => this.WriteData(1792UL, value, 0);
                }

                public double TransmissionTime
                {
                    get => this.ReadDataDouble(1856UL, 0);
                    set => this.WriteData(1856UL, value, 0);
                }

                public double FitInterval
                {
                    get => this.ReadDataDouble(1920UL, 0);
                    set => this.WriteData(1920UL, value, 0);
                }

                public double Toc
                {
                    get => this.ReadDataDouble(1984UL, 0);
                    set => this.WriteData(1984UL, value, 0);
                }

                public bool IonoCoeffsValid
                {
                    get => this.ReadDataBool(2048UL, false);
                    set => this.WriteData(2048UL, value, false);
                }

                public ListOfPrimitivesSerializer<double> IonoAlpha
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<double> IonoBeta
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(1);
                    set => Link(1, value);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc3a3a8de519a4a26UL)]
        public class IonoData : ICapnpSerializable
        {
            public const UInt64 typeId = 0xc3a3a8de519a4a26UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                SvHealth = reader.SvHealth;
                Tow = reader.Tow;
                GpsWeek = reader.GpsWeek;
                IonoAlpha = reader.IonoAlpha;
                IonoBeta = reader.IonoBeta;
                HealthValid = reader.HealthValid;
                IonoCoeffsValid = reader.IonoCoeffsValid;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.SvHealth = SvHealth;
                writer.Tow = Tow;
                writer.GpsWeek = GpsWeek;
                writer.IonoAlpha.Init(IonoAlpha);
                writer.IonoBeta.Init(IonoBeta);
                writer.HealthValid = HealthValid;
                writer.IonoCoeffsValid = IonoCoeffsValid;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public uint SvHealth
            {
                get;
                set;
            }

            public double Tow
            {
                get;
                set;
            }

            public double GpsWeek
            {
                get;
                set;
            }

            public IReadOnlyList<double> IonoAlpha
            {
                get;
                set;
            }

            public IReadOnlyList<double> IonoBeta
            {
                get;
                set;
            }

            public bool HealthValid
            {
                get;
                set;
            }

            public bool IonoCoeffsValid
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
                public uint SvHealth => ctx.ReadDataUInt(0UL, 0U);
                public double Tow => ctx.ReadDataDouble(64UL, 0);
                public double GpsWeek => ctx.ReadDataDouble(128UL, 0);
                public IReadOnlyList<double> IonoAlpha => ctx.ReadList(0).CastDouble();
                public IReadOnlyList<double> IonoBeta => ctx.ReadList(1).CastDouble();
                public bool HealthValid => ctx.ReadDataBool(32UL, false);
                public bool IonoCoeffsValid => ctx.ReadDataBool(33UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(3, 2);
                }

                public uint SvHealth
                {
                    get => this.ReadDataUInt(0UL, 0U);
                    set => this.WriteData(0UL, value, 0U);
                }

                public double Tow
                {
                    get => this.ReadDataDouble(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public double GpsWeek
                {
                    get => this.ReadDataDouble(128UL, 0);
                    set => this.WriteData(128UL, value, 0);
                }

                public ListOfPrimitivesSerializer<double> IonoAlpha
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(0);
                    set => Link(0, value);
                }

                public ListOfPrimitivesSerializer<double> IonoBeta
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<double>>(1);
                    set => Link(1, value);
                }

                public bool HealthValid
                {
                    get => this.ReadDataBool(32UL, false);
                    set => this.WriteData(32UL, value, false);
                }

                public bool IonoCoeffsValid
                {
                    get => this.ReadDataBool(33UL, false);
                    set => this.WriteData(33UL, value, false);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xebb036b114275aa8UL)]
        public class HwStatus : ICapnpSerializable
        {
            public const UInt64 typeId = 0xebb036b114275aa8UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                NoisePerMS = reader.NoisePerMS;
                AgcCnt = reader.AgcCnt;
                AStatus = reader.AStatus;
                APower = reader.APower;
                JamInd = reader.JamInd;
                Flags = reader.Flags;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.NoisePerMS = NoisePerMS;
                writer.AgcCnt = AgcCnt;
                writer.AStatus = AStatus;
                writer.APower = APower;
                writer.JamInd = JamInd;
                writer.Flags = Flags;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public ushort NoisePerMS
            {
                get;
                set;
            }

            public ushort AgcCnt
            {
                get;
                set;
            }

            public Cereal.UbloxGnss.HwStatus.AntennaSupervisorState AStatus
            {
                get;
                set;
            }

            public Cereal.UbloxGnss.HwStatus.AntennaPowerStatus APower
            {
                get;
                set;
            }

            public byte JamInd
            {
                get;
                set;
            }

            public byte Flags
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
                public ushort NoisePerMS => ctx.ReadDataUShort(0UL, (ushort)0);
                public ushort AgcCnt => ctx.ReadDataUShort(16UL, (ushort)0);
                public Cereal.UbloxGnss.HwStatus.AntennaSupervisorState AStatus => (Cereal.UbloxGnss.HwStatus.AntennaSupervisorState)ctx.ReadDataUShort(32UL, (ushort)0);
                public Cereal.UbloxGnss.HwStatus.AntennaPowerStatus APower => (Cereal.UbloxGnss.HwStatus.AntennaPowerStatus)ctx.ReadDataUShort(48UL, (ushort)0);
                public byte JamInd => ctx.ReadDataByte(64UL, (byte)0);
                public byte Flags => ctx.ReadDataByte(72UL, (byte)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public ushort NoisePerMS
                {
                    get => this.ReadDataUShort(0UL, (ushort)0);
                    set => this.WriteData(0UL, value, (ushort)0);
                }

                public ushort AgcCnt
                {
                    get => this.ReadDataUShort(16UL, (ushort)0);
                    set => this.WriteData(16UL, value, (ushort)0);
                }

                public Cereal.UbloxGnss.HwStatus.AntennaSupervisorState AStatus
                {
                    get => (Cereal.UbloxGnss.HwStatus.AntennaSupervisorState)this.ReadDataUShort(32UL, (ushort)0);
                    set => this.WriteData(32UL, (ushort)value, (ushort)0);
                }

                public Cereal.UbloxGnss.HwStatus.AntennaPowerStatus APower
                {
                    get => (Cereal.UbloxGnss.HwStatus.AntennaPowerStatus)this.ReadDataUShort(48UL, (ushort)0);
                    set => this.WriteData(48UL, (ushort)value, (ushort)0);
                }

                public byte JamInd
                {
                    get => this.ReadDataByte(64UL, (byte)0);
                    set => this.WriteData(64UL, value, (byte)0);
                }

                public byte Flags
                {
                    get => this.ReadDataByte(72UL, (byte)0);
                    set => this.WriteData(72UL, value, (byte)0);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc23e1128ab4d5b53UL)]
            public enum AntennaSupervisorState : ushort
            {
                init,
                dontknow,
                ok,
                @short,
                open
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfe3b51a924e46559UL)]
            public enum AntennaPowerStatus : ushort
            {
                off,
                @on,
                dontknow
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xf919b410b90e53c6UL)]
        public class HwStatus2 : ICapnpSerializable
        {
            public const UInt64 typeId = 0xf919b410b90e53c6UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                OfsI = reader.OfsI;
                MagI = reader.MagI;
                OfsQ = reader.OfsQ;
                MagQ = reader.MagQ;
                CfgSource = reader.CfgSource;
                LowLevCfg = reader.LowLevCfg;
                PostStatus = reader.PostStatus;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.OfsI = OfsI;
                writer.MagI = MagI;
                writer.OfsQ = OfsQ;
                writer.MagQ = MagQ;
                writer.CfgSource = CfgSource;
                writer.LowLevCfg = LowLevCfg;
                writer.PostStatus = PostStatus;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public sbyte OfsI
            {
                get;
                set;
            }

            public byte MagI
            {
                get;
                set;
            }

            public sbyte OfsQ
            {
                get;
                set;
            }

            public byte MagQ
            {
                get;
                set;
            }

            public Cereal.UbloxGnss.HwStatus2.ConfigSource CfgSource
            {
                get;
                set;
            }

            public uint LowLevCfg
            {
                get;
                set;
            }

            public uint PostStatus
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
                public sbyte OfsI => ctx.ReadDataSByte(0UL, (sbyte)0);
                public byte MagI => ctx.ReadDataByte(8UL, (byte)0);
                public sbyte OfsQ => ctx.ReadDataSByte(16UL, (sbyte)0);
                public byte MagQ => ctx.ReadDataByte(24UL, (byte)0);
                public Cereal.UbloxGnss.HwStatus2.ConfigSource CfgSource => (Cereal.UbloxGnss.HwStatus2.ConfigSource)ctx.ReadDataUShort(32UL, (ushort)0);
                public uint LowLevCfg => ctx.ReadDataUInt(64UL, 0U);
                public uint PostStatus => ctx.ReadDataUInt(96UL, 0U);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 0);
                }

                public sbyte OfsI
                {
                    get => this.ReadDataSByte(0UL, (sbyte)0);
                    set => this.WriteData(0UL, value, (sbyte)0);
                }

                public byte MagI
                {
                    get => this.ReadDataByte(8UL, (byte)0);
                    set => this.WriteData(8UL, value, (byte)0);
                }

                public sbyte OfsQ
                {
                    get => this.ReadDataSByte(16UL, (sbyte)0);
                    set => this.WriteData(16UL, value, (sbyte)0);
                }

                public byte MagQ
                {
                    get => this.ReadDataByte(24UL, (byte)0);
                    set => this.WriteData(24UL, value, (byte)0);
                }

                public Cereal.UbloxGnss.HwStatus2.ConfigSource CfgSource
                {
                    get => (Cereal.UbloxGnss.HwStatus2.ConfigSource)this.ReadDataUShort(32UL, (ushort)0);
                    set => this.WriteData(32UL, (ushort)value, (ushort)0);
                }

                public uint LowLevCfg
                {
                    get => this.ReadDataUInt(64UL, 0U);
                    set => this.WriteData(64UL, value, 0U);
                }

                public uint PostStatus
                {
                    get => this.ReadDataUInt(96UL, 0U);
                    set => this.WriteData(96UL, value, 0U);
                }
            }

            [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb2d0985eb51c97b9UL)]
            public enum ConfigSource : ushort
            {
                undefined,
                rom,
                otp,
                configpins,
                flash
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc95fb49a7bdc4618UL)]
    public class Clocks : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc95fb49a7bdc4618UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            BootTimeNanos = reader.BootTimeNanos;
            MonotonicNanos = reader.MonotonicNanos;
            MonotonicRawNanos = reader.MonotonicRawNanos;
            WallTimeNanos = reader.WallTimeNanos;
            ModemUptimeMillis = reader.ModemUptimeMillis;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.BootTimeNanos = BootTimeNanos;
            writer.MonotonicNanos = MonotonicNanos;
            writer.MonotonicRawNanos = MonotonicRawNanos;
            writer.WallTimeNanos = WallTimeNanos;
            writer.ModemUptimeMillis = ModemUptimeMillis;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong BootTimeNanos
        {
            get;
            set;
        }

        public ulong MonotonicNanos
        {
            get;
            set;
        }

        public ulong MonotonicRawNanos
        {
            get;
            set;
        }

        public ulong WallTimeNanos
        {
            get;
            set;
        }

        public ulong ModemUptimeMillis
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
            public ulong BootTimeNanos => ctx.ReadDataULong(0UL, 0UL);
            public ulong MonotonicNanos => ctx.ReadDataULong(64UL, 0UL);
            public ulong MonotonicRawNanos => ctx.ReadDataULong(128UL, 0UL);
            public ulong WallTimeNanos => ctx.ReadDataULong(192UL, 0UL);
            public ulong ModemUptimeMillis => ctx.ReadDataULong(256UL, 0UL);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(5, 0);
            }

            public ulong BootTimeNanos
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public ulong MonotonicNanos
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public ulong MonotonicRawNanos
            {
                get => this.ReadDataULong(128UL, 0UL);
                set => this.WriteData(128UL, value, 0UL);
            }

            public ulong WallTimeNanos
            {
                get => this.ReadDataULong(192UL, 0UL);
                set => this.WriteData(192UL, value, 0UL);
            }

            public ulong ModemUptimeMillis
            {
                get => this.ReadDataULong(256UL, 0UL);
                set => this.WriteData(256UL, value, 0UL);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x92a5e332a85f32a0UL)]
    public class LiveMpcData : ICapnpSerializable
    {
        public const UInt64 typeId = 0x92a5e332a85f32a0UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            X = reader.X;
            Y = reader.Y;
            Psi = reader.Psi;
            Curvature = reader.Curvature;
            QpIterations = reader.QpIterations;
            CalculationTime = reader.CalculationTime;
            Cost = reader.Cost;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.X.Init(X);
            writer.Y.Init(Y);
            writer.Psi.Init(Psi);
            writer.Curvature.Init(Curvature);
            writer.QpIterations = QpIterations;
            writer.CalculationTime = CalculationTime;
            writer.Cost = Cost;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<float> X
        {
            get;
            set;
        }

        public IReadOnlyList<float> Y
        {
            get;
            set;
        }

        public IReadOnlyList<float> Psi
        {
            get;
            set;
        }

        public IReadOnlyList<float> Curvature
        {
            get;
            set;
        }

        public uint QpIterations
        {
            get;
            set;
        }

        public ulong CalculationTime
        {
            get;
            set;
        }

        public double Cost
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
            public IReadOnlyList<float> X => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<float> Y => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<float> Psi => ctx.ReadList(2).CastFloat();
            public IReadOnlyList<float> Curvature => ctx.ReadList(3).CastFloat();
            public uint QpIterations => ctx.ReadDataUInt(0UL, 0U);
            public ulong CalculationTime => ctx.ReadDataULong(64UL, 0UL);
            public double Cost => ctx.ReadDataDouble(128UL, 0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(3, 4);
            }

            public ListOfPrimitivesSerializer<float> X
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<float> Y
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> Psi
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public ListOfPrimitivesSerializer<float> Curvature
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public uint QpIterations
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public ulong CalculationTime
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }

            public double Cost
            {
                get => this.ReadDataDouble(128UL, 0);
                set => this.WriteData(128UL, value, 0);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe7e17c434f865ae2UL)]
    public class LiveLongitudinalMpcData : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe7e17c434f865ae2UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            XEgo = reader.XEgo;
            VEgo = reader.VEgo;
            AEgo = reader.AEgo;
            XLead = reader.XLead;
            VLead = reader.VLead;
            ALead = reader.ALead;
            ALeadTau = reader.ALeadTau;
            QpIterations = reader.QpIterations;
            MpcId = reader.MpcId;
            CalculationTime = reader.CalculationTime;
            Cost = reader.Cost;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.XEgo.Init(XEgo);
            writer.VEgo.Init(VEgo);
            writer.AEgo.Init(AEgo);
            writer.XLead.Init(XLead);
            writer.VLead.Init(VLead);
            writer.ALead.Init(ALead);
            writer.ALeadTau = ALeadTau;
            writer.QpIterations = QpIterations;
            writer.MpcId = MpcId;
            writer.CalculationTime = CalculationTime;
            writer.Cost = Cost;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<float> XEgo
        {
            get;
            set;
        }

        public IReadOnlyList<float> VEgo
        {
            get;
            set;
        }

        public IReadOnlyList<float> AEgo
        {
            get;
            set;
        }

        public IReadOnlyList<float> XLead
        {
            get;
            set;
        }

        public IReadOnlyList<float> VLead
        {
            get;
            set;
        }

        public IReadOnlyList<float> ALead
        {
            get;
            set;
        }

        public float ALeadTau
        {
            get;
            set;
        }

        public uint QpIterations
        {
            get;
            set;
        }

        public uint MpcId
        {
            get;
            set;
        }

        public ulong CalculationTime
        {
            get;
            set;
        }

        public double Cost
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
            public IReadOnlyList<float> XEgo => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<float> VEgo => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<float> AEgo => ctx.ReadList(2).CastFloat();
            public IReadOnlyList<float> XLead => ctx.ReadList(3).CastFloat();
            public IReadOnlyList<float> VLead => ctx.ReadList(4).CastFloat();
            public IReadOnlyList<float> ALead => ctx.ReadList(5).CastFloat();
            public float ALeadTau => ctx.ReadDataFloat(0UL, 0F);
            public uint QpIterations => ctx.ReadDataUInt(32UL, 0U);
            public uint MpcId => ctx.ReadDataUInt(64UL, 0U);
            public ulong CalculationTime => ctx.ReadDataULong(128UL, 0UL);
            public double Cost => ctx.ReadDataDouble(192UL, 0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(4, 6);
            }

            public ListOfPrimitivesSerializer<float> XEgo
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<float> VEgo
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> AEgo
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public ListOfPrimitivesSerializer<float> XLead
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public ListOfPrimitivesSerializer<float> VLead
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                set => Link(4, value);
            }

            public ListOfPrimitivesSerializer<float> ALead
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(5);
                set => Link(5, value);
            }

            public float ALeadTau
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }

            public uint QpIterations
            {
                get => this.ReadDataUInt(32UL, 0U);
                set => this.WriteData(32UL, value, 0U);
            }

            public uint MpcId
            {
                get => this.ReadDataUInt(64UL, 0U);
                set => this.WriteData(64UL, value, 0U);
            }

            public ulong CalculationTime
            {
                get => this.ReadDataULong(128UL, 0UL);
                set => this.WriteData(128UL, value, 0UL);
            }

            public double Cost
            {
                get => this.ReadDataDouble(192UL, 0);
                set => this.WriteData(192UL, value, 0);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xe42401658e2715e2UL)]
    public class Joystick : ICapnpSerializable
    {
        public const UInt64 typeId = 0xe42401658e2715e2UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Axes = reader.Axes;
            Buttons = reader.Buttons;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Axes.Init(Axes);
            writer.Buttons.Init(Buttons);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<float> Axes
        {
            get;
            set;
        }

        public IReadOnlyList<bool> Buttons
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
            public IReadOnlyList<float> Axes => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<bool> Buttons => ctx.ReadList(1).CastBool();
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 2);
            }

            public ListOfPrimitivesSerializer<float> Axes
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfBitsSerializer Buttons
            {
                get => BuildPointer<ListOfBitsSerializer>(1);
                set => Link(1, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb83c6cc593ed0a00UL)]
    public class DriverState : ICapnpSerializable
    {
        public const UInt64 typeId = 0xb83c6cc593ed0a00UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            FrameId = reader.FrameId;
            DescriptorDEPRECATED = reader.DescriptorDEPRECATED;
            StdDEPRECATED = reader.StdDEPRECATED;
            FaceOrientation = reader.FaceOrientation;
            FacePosition = reader.FacePosition;
            FaceProb = reader.FaceProb;
            LeftEyeProb = reader.LeftEyeProb;
            RightEyeProb = reader.RightEyeProb;
            LeftBlinkProb = reader.LeftBlinkProb;
            RightBlinkProb = reader.RightBlinkProb;
            IrPwrDEPRECATED = reader.IrPwrDEPRECATED;
            FaceOrientationStd = reader.FaceOrientationStd;
            FacePositionStd = reader.FacePositionStd;
            SunglassesProb = reader.SunglassesProb;
            ModelExecutionTime = reader.ModelExecutionTime;
            RawPredictions = reader.RawPredictions;
            DspExecutionTime = reader.DspExecutionTime;
            PoorVision = reader.PoorVision;
            PartialFace = reader.PartialFace;
            DistractedPose = reader.DistractedPose;
            DistractedEyes = reader.DistractedEyes;
            EyesOnRoad = reader.EyesOnRoad;
            PhoneUse = reader.PhoneUse;
            OccludedProb = reader.OccludedProb;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.FrameId = FrameId;
            writer.DescriptorDEPRECATED.Init(DescriptorDEPRECATED);
            writer.StdDEPRECATED = StdDEPRECATED;
            writer.FaceOrientation.Init(FaceOrientation);
            writer.FacePosition.Init(FacePosition);
            writer.FaceProb = FaceProb;
            writer.LeftEyeProb = LeftEyeProb;
            writer.RightEyeProb = RightEyeProb;
            writer.LeftBlinkProb = LeftBlinkProb;
            writer.RightBlinkProb = RightBlinkProb;
            writer.IrPwrDEPRECATED = IrPwrDEPRECATED;
            writer.FaceOrientationStd.Init(FaceOrientationStd);
            writer.FacePositionStd.Init(FacePositionStd);
            writer.SunglassesProb = SunglassesProb;
            writer.ModelExecutionTime = ModelExecutionTime;
            writer.RawPredictions.Init(RawPredictions);
            writer.DspExecutionTime = DspExecutionTime;
            writer.PoorVision = PoorVision;
            writer.PartialFace = PartialFace;
            writer.DistractedPose = DistractedPose;
            writer.DistractedEyes = DistractedEyes;
            writer.EyesOnRoad = EyesOnRoad;
            writer.PhoneUse = PhoneUse;
            writer.OccludedProb = OccludedProb;
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

        public IReadOnlyList<float> DescriptorDEPRECATED
        {
            get;
            set;
        }

        public float StdDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> FaceOrientation
        {
            get;
            set;
        }

        public IReadOnlyList<float> FacePosition
        {
            get;
            set;
        }

        public float FaceProb
        {
            get;
            set;
        }

        public float LeftEyeProb
        {
            get;
            set;
        }

        public float RightEyeProb
        {
            get;
            set;
        }

        public float LeftBlinkProb
        {
            get;
            set;
        }

        public float RightBlinkProb
        {
            get;
            set;
        }

        public float IrPwrDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<float> FaceOrientationStd
        {
            get;
            set;
        }

        public IReadOnlyList<float> FacePositionStd
        {
            get;
            set;
        }

        public float SunglassesProb
        {
            get;
            set;
        }

        public float ModelExecutionTime
        {
            get;
            set;
        }

        public IReadOnlyList<byte> RawPredictions
        {
            get;
            set;
        }

        public float DspExecutionTime
        {
            get;
            set;
        }

        public float PoorVision
        {
            get;
            set;
        }

        public float PartialFace
        {
            get;
            set;
        }

        public float DistractedPose
        {
            get;
            set;
        }

        public float DistractedEyes
        {
            get;
            set;
        }

        public float EyesOnRoad
        {
            get;
            set;
        }

        public float PhoneUse
        {
            get;
            set;
        }

        public float OccludedProb
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
            public IReadOnlyList<float> DescriptorDEPRECATED => ctx.ReadList(0).CastFloat();
            public float StdDEPRECATED => ctx.ReadDataFloat(32UL, 0F);
            public IReadOnlyList<float> FaceOrientation => ctx.ReadList(1).CastFloat();
            public IReadOnlyList<float> FacePosition => ctx.ReadList(2).CastFloat();
            public float FaceProb => ctx.ReadDataFloat(64UL, 0F);
            public float LeftEyeProb => ctx.ReadDataFloat(96UL, 0F);
            public float RightEyeProb => ctx.ReadDataFloat(128UL, 0F);
            public float LeftBlinkProb => ctx.ReadDataFloat(160UL, 0F);
            public float RightBlinkProb => ctx.ReadDataFloat(192UL, 0F);
            public float IrPwrDEPRECATED => ctx.ReadDataFloat(224UL, 0F);
            public IReadOnlyList<float> FaceOrientationStd => ctx.ReadList(3).CastFloat();
            public IReadOnlyList<float> FacePositionStd => ctx.ReadList(4).CastFloat();
            public float SunglassesProb => ctx.ReadDataFloat(256UL, 0F);
            public float ModelExecutionTime => ctx.ReadDataFloat(288UL, 0F);
            public IReadOnlyList<byte> RawPredictions => ctx.ReadList(5).CastByte();
            public float DspExecutionTime => ctx.ReadDataFloat(320UL, 0F);
            public float PoorVision => ctx.ReadDataFloat(352UL, 0F);
            public float PartialFace => ctx.ReadDataFloat(384UL, 0F);
            public float DistractedPose => ctx.ReadDataFloat(416UL, 0F);
            public float DistractedEyes => ctx.ReadDataFloat(448UL, 0F);
            public float EyesOnRoad => ctx.ReadDataFloat(480UL, 0F);
            public float PhoneUse => ctx.ReadDataFloat(512UL, 0F);
            public float OccludedProb => ctx.ReadDataFloat(544UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(9, 6);
            }

            public uint FrameId
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public ListOfPrimitivesSerializer<float> DescriptorDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public float StdDEPRECATED
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> FaceOrientation
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public ListOfPrimitivesSerializer<float> FacePosition
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(2);
                set => Link(2, value);
            }

            public float FaceProb
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public float LeftEyeProb
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public float RightEyeProb
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float LeftBlinkProb
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public float RightBlinkProb
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public float IrPwrDEPRECATED
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<float> FaceOrientationStd
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public ListOfPrimitivesSerializer<float> FacePositionStd
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                set => Link(4, value);
            }

            public float SunglassesProb
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }

            public float ModelExecutionTime
            {
                get => this.ReadDataFloat(288UL, 0F);
                set => this.WriteData(288UL, value, 0F);
            }

            public ListOfPrimitivesSerializer<byte> RawPredictions
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(5);
                set => Link(5, value);
            }

            public float DspExecutionTime
            {
                get => this.ReadDataFloat(320UL, 0F);
                set => this.WriteData(320UL, value, 0F);
            }

            public float PoorVision
            {
                get => this.ReadDataFloat(352UL, 0F);
                set => this.WriteData(352UL, value, 0F);
            }

            public float PartialFace
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }

            public float DistractedPose
            {
                get => this.ReadDataFloat(416UL, 0F);
                set => this.WriteData(416UL, value, 0F);
            }

            public float DistractedEyes
            {
                get => this.ReadDataFloat(448UL, 0F);
                set => this.WriteData(448UL, value, 0F);
            }

            public float EyesOnRoad
            {
                get => this.ReadDataFloat(480UL, 0F);
                set => this.WriteData(480UL, value, 0F);
            }

            public float PhoneUse
            {
                get => this.ReadDataFloat(512UL, 0F);
                set => this.WriteData(512UL, value, 0F);
            }

            public float OccludedProb
            {
                get => this.ReadDataFloat(544UL, 0F);
                set => this.WriteData(544UL, value, 0F);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xb83cda094a1da284UL)]
    public class DriverMonitoringState : ICapnpSerializable
    {
        public const UInt64 typeId = 0xb83cda094a1da284UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Events = reader.Events?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CarEvent>(_));
            FaceDetected = reader.FaceDetected;
            IsDistracted = reader.IsDistracted;
            AwarenessStatus = reader.AwarenessStatus;
            IsRHDDEPRECATED = reader.IsRHDDEPRECATED;
            RhdCheckedDEPRECATED = reader.RhdCheckedDEPRECATED;
            PosePitchOffset = reader.PosePitchOffset;
            PosePitchValidCount = reader.PosePitchValidCount;
            PoseYawOffset = reader.PoseYawOffset;
            PoseYawValidCount = reader.PoseYawValidCount;
            StepChange = reader.StepChange;
            AwarenessActive = reader.AwarenessActive;
            AwarenessPassive = reader.AwarenessPassive;
            IsLowStd = reader.IsLowStd;
            HiStdCount = reader.HiStdCount;
            IsPreviewDEPRECATED = reader.IsPreviewDEPRECATED;
            IsActiveMode = reader.IsActiveMode;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Events.Init(Events, (_s1, _v1) => _v1?.serialize(_s1));
            writer.FaceDetected = FaceDetected;
            writer.IsDistracted = IsDistracted;
            writer.AwarenessStatus = AwarenessStatus;
            writer.IsRHDDEPRECATED = IsRHDDEPRECATED;
            writer.RhdCheckedDEPRECATED = RhdCheckedDEPRECATED;
            writer.PosePitchOffset = PosePitchOffset;
            writer.PosePitchValidCount = PosePitchValidCount;
            writer.PoseYawOffset = PoseYawOffset;
            writer.PoseYawValidCount = PoseYawValidCount;
            writer.StepChange = StepChange;
            writer.AwarenessActive = AwarenessActive;
            writer.AwarenessPassive = AwarenessPassive;
            writer.IsLowStd = IsLowStd;
            writer.HiStdCount = HiStdCount;
            writer.IsPreviewDEPRECATED = IsPreviewDEPRECATED;
            writer.IsActiveMode = IsActiveMode;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<Cereal.CarEvent> Events
        {
            get;
            set;
        }

        public bool FaceDetected
        {
            get;
            set;
        }

        public bool IsDistracted
        {
            get;
            set;
        }

        public float AwarenessStatus
        {
            get;
            set;
        }

        public bool IsRHDDEPRECATED
        {
            get;
            set;
        }

        public bool RhdCheckedDEPRECATED
        {
            get;
            set;
        }

        public float PosePitchOffset
        {
            get;
            set;
        }

        public uint PosePitchValidCount
        {
            get;
            set;
        }

        public float PoseYawOffset
        {
            get;
            set;
        }

        public uint PoseYawValidCount
        {
            get;
            set;
        }

        public float StepChange
        {
            get;
            set;
        }

        public float AwarenessActive
        {
            get;
            set;
        }

        public float AwarenessPassive
        {
            get;
            set;
        }

        public bool IsLowStd
        {
            get;
            set;
        }

        public uint HiStdCount
        {
            get;
            set;
        }

        public bool IsPreviewDEPRECATED
        {
            get;
            set;
        }

        public bool IsActiveMode
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
            public IReadOnlyList<Cereal.CarEvent.READER> Events => ctx.ReadList(0).Cast(Cereal.CarEvent.READER.create);
            public bool FaceDetected => ctx.ReadDataBool(0UL, false);
            public bool IsDistracted => ctx.ReadDataBool(1UL, false);
            public float AwarenessStatus => ctx.ReadDataFloat(32UL, 0F);
            public bool IsRHDDEPRECATED => ctx.ReadDataBool(2UL, false);
            public bool RhdCheckedDEPRECATED => ctx.ReadDataBool(3UL, false);
            public float PosePitchOffset => ctx.ReadDataFloat(64UL, 0F);
            public uint PosePitchValidCount => ctx.ReadDataUInt(96UL, 0U);
            public float PoseYawOffset => ctx.ReadDataFloat(128UL, 0F);
            public uint PoseYawValidCount => ctx.ReadDataUInt(160UL, 0U);
            public float StepChange => ctx.ReadDataFloat(192UL, 0F);
            public float AwarenessActive => ctx.ReadDataFloat(224UL, 0F);
            public float AwarenessPassive => ctx.ReadDataFloat(256UL, 0F);
            public bool IsLowStd => ctx.ReadDataBool(4UL, false);
            public uint HiStdCount => ctx.ReadDataUInt(288UL, 0U);
            public bool IsPreviewDEPRECATED => ctx.ReadDataBool(5UL, false);
            public bool IsActiveMode => ctx.ReadDataBool(6UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(5, 1);
            }

            public ListOfStructsSerializer<Cereal.CarEvent.WRITER> Events
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.CarEvent.WRITER>>(0);
                set => Link(0, value);
            }

            public bool FaceDetected
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public bool IsDistracted
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public float AwarenessStatus
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public bool IsRHDDEPRECATED
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }

            public bool RhdCheckedDEPRECATED
            {
                get => this.ReadDataBool(3UL, false);
                set => this.WriteData(3UL, value, false);
            }

            public float PosePitchOffset
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public uint PosePitchValidCount
            {
                get => this.ReadDataUInt(96UL, 0U);
                set => this.WriteData(96UL, value, 0U);
            }

            public float PoseYawOffset
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public uint PoseYawValidCount
            {
                get => this.ReadDataUInt(160UL, 0U);
                set => this.WriteData(160UL, value, 0U);
            }

            public float StepChange
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public float AwarenessActive
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public float AwarenessPassive
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }

            public bool IsLowStd
            {
                get => this.ReadDataBool(4UL, false);
                set => this.WriteData(4UL, value, false);
            }

            public uint HiStdCount
            {
                get => this.ReadDataUInt(288UL, 0U);
                set => this.WriteData(288UL, value, 0U);
            }

            public bool IsPreviewDEPRECATED
            {
                get => this.ReadDataBool(5UL, false);
                set => this.WriteData(5UL, value, false);
            }

            public bool IsActiveMode
            {
                get => this.ReadDataBool(6UL, false);
                set => this.WriteData(6UL, value, false);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa12e8670927a2549UL)]
    public class Boot : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa12e8670927a2549UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            WallTimeNanos = reader.WallTimeNanos;
            LastKmsgDEPRECATED = reader.LastKmsgDEPRECATED;
            LastPmsgDEPRECATED = reader.LastPmsgDEPRECATED;
            LaunchLog = reader.LaunchLog;
            Pstore = CapnpSerializable.Create<Cereal.Map<string, IReadOnlyList<byte>>>(reader.Pstore);
            Commands = CapnpSerializable.Create<Cereal.Map<string, IReadOnlyList<byte>>>(reader.Commands);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.WallTimeNanos = WallTimeNanos;
            writer.LastKmsgDEPRECATED.Init(LastKmsgDEPRECATED);
            writer.LastPmsgDEPRECATED.Init(LastPmsgDEPRECATED);
            writer.LaunchLog = LaunchLog;
            Pstore?.serialize(writer.Pstore);
            Commands?.serialize(writer.Commands);
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong WallTimeNanos
        {
            get;
            set;
        }

        public IReadOnlyList<byte> LastKmsgDEPRECATED
        {
            get;
            set;
        }

        public IReadOnlyList<byte> LastPmsgDEPRECATED
        {
            get;
            set;
        }

        public string LaunchLog
        {
            get;
            set;
        }

        public Cereal.Map<string, IReadOnlyList<byte>> Pstore
        {
            get;
            set;
        }

        public Cereal.Map<string, IReadOnlyList<byte>> Commands
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
            public ulong WallTimeNanos => ctx.ReadDataULong(0UL, 0UL);
            public IReadOnlyList<byte> LastKmsgDEPRECATED => ctx.ReadList(0).CastByte();
            public IReadOnlyList<byte> LastPmsgDEPRECATED => ctx.ReadList(1).CastByte();
            public string LaunchLog => ctx.ReadText(2, null);
            public Cereal.Map<string, IReadOnlyList<byte>>.READER Pstore => ctx.ReadStruct(3, Cereal.Map<string, IReadOnlyList<byte>>.READER.create);
            public Cereal.Map<string, IReadOnlyList<byte>>.READER Commands => ctx.ReadStruct(4, Cereal.Map<string, IReadOnlyList<byte>>.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 5);
            }

            public ulong WallTimeNanos
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<byte> LastKmsgDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<byte> LastPmsgDEPRECATED
            {
                get => BuildPointer<ListOfPrimitivesSerializer<byte>>(1);
                set => Link(1, value);
            }

            public string LaunchLog
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public Cereal.Map<string, IReadOnlyList<byte>>.WRITER Pstore
            {
                get => BuildPointer<Cereal.Map<string, IReadOnlyList<byte>>.WRITER>(3);
                set => Link(3, value);
            }

            public Cereal.Map<string, IReadOnlyList<byte>>.WRITER Commands
            {
                get => BuildPointer<Cereal.Map<string, IReadOnlyList<byte>>.WRITER>(4);
                set => Link(4, value);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd9058dcb967c2753UL)]
    public class LiveParametersData : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd9058dcb967c2753UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Valid = reader.Valid;
            GyroBias = reader.GyroBias;
            AngleOffsetDeg = reader.AngleOffsetDeg;
            AngleOffsetAverageDeg = reader.AngleOffsetAverageDeg;
            StiffnessFactor = reader.StiffnessFactor;
            SteerRatio = reader.SteerRatio;
            SensorValid = reader.SensorValid;
            YawRate = reader.YawRate;
            PosenetSpeed = reader.PosenetSpeed;
            PosenetValid = reader.PosenetValid;
            AngleOffsetFastStd = reader.AngleOffsetFastStd;
            AngleOffsetAverageStd = reader.AngleOffsetAverageStd;
            StiffnessFactorStd = reader.StiffnessFactorStd;
            SteerRatioStd = reader.SteerRatioStd;
            Roll = reader.Roll;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Valid = Valid;
            writer.GyroBias = GyroBias;
            writer.AngleOffsetDeg = AngleOffsetDeg;
            writer.AngleOffsetAverageDeg = AngleOffsetAverageDeg;
            writer.StiffnessFactor = StiffnessFactor;
            writer.SteerRatio = SteerRatio;
            writer.SensorValid = SensorValid;
            writer.YawRate = YawRate;
            writer.PosenetSpeed = PosenetSpeed;
            writer.PosenetValid = PosenetValid;
            writer.AngleOffsetFastStd = AngleOffsetFastStd;
            writer.AngleOffsetAverageStd = AngleOffsetAverageStd;
            writer.StiffnessFactorStd = StiffnessFactorStd;
            writer.SteerRatioStd = SteerRatioStd;
            writer.Roll = Roll;
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

        public float GyroBias
        {
            get;
            set;
        }

        public float AngleOffsetDeg
        {
            get;
            set;
        }

        public float AngleOffsetAverageDeg
        {
            get;
            set;
        }

        public float StiffnessFactor
        {
            get;
            set;
        }

        public float SteerRatio
        {
            get;
            set;
        }

        public bool SensorValid
        {
            get;
            set;
        }

        public float YawRate
        {
            get;
            set;
        }

        public float PosenetSpeed
        {
            get;
            set;
        }

        public bool PosenetValid
        {
            get;
            set;
        }

        public float AngleOffsetFastStd
        {
            get;
            set;
        }

        public float AngleOffsetAverageStd
        {
            get;
            set;
        }

        public float StiffnessFactorStd
        {
            get;
            set;
        }

        public float SteerRatioStd
        {
            get;
            set;
        }

        public float Roll
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
            public float GyroBias => ctx.ReadDataFloat(32UL, 0F);
            public float AngleOffsetDeg => ctx.ReadDataFloat(64UL, 0F);
            public float AngleOffsetAverageDeg => ctx.ReadDataFloat(96UL, 0F);
            public float StiffnessFactor => ctx.ReadDataFloat(128UL, 0F);
            public float SteerRatio => ctx.ReadDataFloat(160UL, 0F);
            public bool SensorValid => ctx.ReadDataBool(1UL, false);
            public float YawRate => ctx.ReadDataFloat(192UL, 0F);
            public float PosenetSpeed => ctx.ReadDataFloat(224UL, 0F);
            public bool PosenetValid => ctx.ReadDataBool(2UL, false);
            public float AngleOffsetFastStd => ctx.ReadDataFloat(256UL, 0F);
            public float AngleOffsetAverageStd => ctx.ReadDataFloat(288UL, 0F);
            public float StiffnessFactorStd => ctx.ReadDataFloat(320UL, 0F);
            public float SteerRatioStd => ctx.ReadDataFloat(352UL, 0F);
            public float Roll => ctx.ReadDataFloat(384UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(7, 0);
            }

            public bool Valid
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public float GyroBias
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float AngleOffsetDeg
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public float AngleOffsetAverageDeg
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public float StiffnessFactor
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float SteerRatio
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public bool SensorValid
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public float YawRate
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public float PosenetSpeed
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public bool PosenetValid
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }

            public float AngleOffsetFastStd
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }

            public float AngleOffsetAverageStd
            {
                get => this.ReadDataFloat(288UL, 0F);
                set => this.WriteData(288UL, value, 0F);
            }

            public float StiffnessFactorStd
            {
                get => this.ReadDataFloat(320UL, 0F);
                set => this.WriteData(320UL, value, 0F);
            }

            public float SteerRatioStd
            {
                get => this.ReadDataFloat(352UL, 0F);
                set => this.WriteData(352UL, value, 0F);
            }

            public float Roll
            {
                get => this.ReadDataFloat(384UL, 0F);
                set => this.WriteData(384UL, value, 0F);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x943e268f93f711a6UL)]
    public class LiveMapDataDEPRECATED : ICapnpSerializable
    {
        public const UInt64 typeId = 0x943e268f93f711a6UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            SpeedLimitValid = reader.SpeedLimitValid;
            SpeedLimit = reader.SpeedLimit;
            CurvatureValid = reader.CurvatureValid;
            Curvature = reader.Curvature;
            WayId = reader.WayId;
            RoadX = reader.RoadX;
            RoadY = reader.RoadY;
            LastGps = CapnpSerializable.Create<Cereal.GpsLocationData>(reader.LastGps);
            RoadCurvatureX = reader.RoadCurvatureX;
            RoadCurvature = reader.RoadCurvature;
            DistToTurn = reader.DistToTurn;
            MapValid = reader.MapValid;
            SpeedAdvisoryValid = reader.SpeedAdvisoryValid;
            SpeedAdvisory = reader.SpeedAdvisory;
            SpeedLimitAheadValid = reader.SpeedLimitAheadValid;
            SpeedLimitAhead = reader.SpeedLimitAhead;
            SpeedLimitAheadDistance = reader.SpeedLimitAheadDistance;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.SpeedLimitValid = SpeedLimitValid;
            writer.SpeedLimit = SpeedLimit;
            writer.CurvatureValid = CurvatureValid;
            writer.Curvature = Curvature;
            writer.WayId = WayId;
            writer.RoadX.Init(RoadX);
            writer.RoadY.Init(RoadY);
            LastGps?.serialize(writer.LastGps);
            writer.RoadCurvatureX.Init(RoadCurvatureX);
            writer.RoadCurvature.Init(RoadCurvature);
            writer.DistToTurn = DistToTurn;
            writer.MapValid = MapValid;
            writer.SpeedAdvisoryValid = SpeedAdvisoryValid;
            writer.SpeedAdvisory = SpeedAdvisory;
            writer.SpeedLimitAheadValid = SpeedLimitAheadValid;
            writer.SpeedLimitAhead = SpeedLimitAhead;
            writer.SpeedLimitAheadDistance = SpeedLimitAheadDistance;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public bool SpeedLimitValid
        {
            get;
            set;
        }

        public float SpeedLimit
        {
            get;
            set;
        }

        public bool CurvatureValid
        {
            get;
            set;
        }

        public float Curvature
        {
            get;
            set;
        }

        public ulong WayId
        {
            get;
            set;
        }

        public IReadOnlyList<float> RoadX
        {
            get;
            set;
        }

        public IReadOnlyList<float> RoadY
        {
            get;
            set;
        }

        public Cereal.GpsLocationData LastGps
        {
            get;
            set;
        }

        public IReadOnlyList<float> RoadCurvatureX
        {
            get;
            set;
        }

        public IReadOnlyList<float> RoadCurvature
        {
            get;
            set;
        }

        public float DistToTurn
        {
            get;
            set;
        }

        public bool MapValid
        {
            get;
            set;
        }

        public bool SpeedAdvisoryValid
        {
            get;
            set;
        }

        public float SpeedAdvisory
        {
            get;
            set;
        }

        public bool SpeedLimitAheadValid
        {
            get;
            set;
        }

        public float SpeedLimitAhead
        {
            get;
            set;
        }

        public float SpeedLimitAheadDistance
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
            public bool SpeedLimitValid => ctx.ReadDataBool(0UL, false);
            public float SpeedLimit => ctx.ReadDataFloat(32UL, 0F);
            public bool CurvatureValid => ctx.ReadDataBool(1UL, false);
            public float Curvature => ctx.ReadDataFloat(64UL, 0F);
            public ulong WayId => ctx.ReadDataULong(128UL, 0UL);
            public IReadOnlyList<float> RoadX => ctx.ReadList(0).CastFloat();
            public IReadOnlyList<float> RoadY => ctx.ReadList(1).CastFloat();
            public Cereal.GpsLocationData.READER LastGps => ctx.ReadStruct(2, Cereal.GpsLocationData.READER.create);
            public IReadOnlyList<float> RoadCurvatureX => ctx.ReadList(3).CastFloat();
            public IReadOnlyList<float> RoadCurvature => ctx.ReadList(4).CastFloat();
            public float DistToTurn => ctx.ReadDataFloat(96UL, 0F);
            public bool MapValid => ctx.ReadDataBool(2UL, false);
            public bool SpeedAdvisoryValid => ctx.ReadDataBool(3UL, false);
            public float SpeedAdvisory => ctx.ReadDataFloat(192UL, 0F);
            public bool SpeedLimitAheadValid => ctx.ReadDataBool(4UL, false);
            public float SpeedLimitAhead => ctx.ReadDataFloat(224UL, 0F);
            public float SpeedLimitAheadDistance => ctx.ReadDataFloat(256UL, 0F);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(5, 5);
            }

            public bool SpeedLimitValid
            {
                get => this.ReadDataBool(0UL, false);
                set => this.WriteData(0UL, value, false);
            }

            public float SpeedLimit
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public bool CurvatureValid
            {
                get => this.ReadDataBool(1UL, false);
                set => this.WriteData(1UL, value, false);
            }

            public float Curvature
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public ulong WayId
            {
                get => this.ReadDataULong(128UL, 0UL);
                set => this.WriteData(128UL, value, 0UL);
            }

            public ListOfPrimitivesSerializer<float> RoadX
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(0);
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<float> RoadY
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(1);
                set => Link(1, value);
            }

            public Cereal.GpsLocationData.WRITER LastGps
            {
                get => BuildPointer<Cereal.GpsLocationData.WRITER>(2);
                set => Link(2, value);
            }

            public ListOfPrimitivesSerializer<float> RoadCurvatureX
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(3);
                set => Link(3, value);
            }

            public ListOfPrimitivesSerializer<float> RoadCurvature
            {
                get => BuildPointer<ListOfPrimitivesSerializer<float>>(4);
                set => Link(4, value);
            }

            public float DistToTurn
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public bool MapValid
            {
                get => this.ReadDataBool(2UL, false);
                set => this.WriteData(2UL, value, false);
            }

            public bool SpeedAdvisoryValid
            {
                get => this.ReadDataBool(3UL, false);
                set => this.WriteData(3UL, value, false);
            }

            public float SpeedAdvisory
            {
                get => this.ReadDataFloat(192UL, 0F);
                set => this.WriteData(192UL, value, 0F);
            }

            public bool SpeedLimitAheadValid
            {
                get => this.ReadDataBool(4UL, false);
                set => this.WriteData(4UL, value, false);
            }

            public float SpeedLimitAhead
            {
                get => this.ReadDataFloat(224UL, 0F);
                set => this.WriteData(224UL, value, 0F);
            }

            public float SpeedLimitAheadDistance
            {
                get => this.ReadDataFloat(256UL, 0F);
                set => this.WriteData(256UL, value, 0F);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xfa9a296b9fd41a96UL)]
    public class CameraOdometry : ICapnpSerializable
    {
        public const UInt64 typeId = 0xfa9a296b9fd41a96UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Trans = reader.Trans;
            Rot = reader.Rot;
            TransStd = reader.TransStd;
            RotStd = reader.RotStd;
            FrameId = reader.FrameId;
            TimestampEof = reader.TimestampEof;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Trans.Init(Trans);
            writer.Rot.Init(Rot);
            writer.TransStd.Init(TransStd);
            writer.RotStd.Init(RotStd);
            writer.FrameId = FrameId;
            writer.TimestampEof = TimestampEof;
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

        public uint FrameId
        {
            get;
            set;
        }

        public ulong TimestampEof
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
            public uint FrameId => ctx.ReadDataUInt(0UL, 0U);
            public ulong TimestampEof => ctx.ReadDataULong(64UL, 0UL);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(2, 4);
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

            public uint FrameId
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public ulong TimestampEof
            {
                get => this.ReadDataULong(64UL, 0UL);
                set => this.WriteData(64UL, value, 0UL);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xef0382d244f56e38UL)]
    public class Sentinel : ICapnpSerializable
    {
        public const UInt64 typeId = 0xef0382d244f56e38UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Type = reader.Type;
            Signal = reader.Signal;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Type = Type;
            writer.Signal = Signal;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public Cereal.Sentinel.SentinelType Type
        {
            get;
            set;
        }

        public int Signal
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
            public Cereal.Sentinel.SentinelType Type => (Cereal.Sentinel.SentinelType)ctx.ReadDataUShort(0UL, (ushort)0);
            public int Signal => ctx.ReadDataInt(32UL, 0);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(1, 0);
            }

            public Cereal.Sentinel.SentinelType Type
            {
                get => (Cereal.Sentinel.SentinelType)this.ReadDataUShort(0UL, (ushort)0);
                set => this.WriteData(0UL, (ushort)value, (ushort)0);
            }

            public int Signal
            {
                get => this.ReadDataInt(32UL, 0);
                set => this.WriteData(32UL, value, 0);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa2d8e61eb6f7031aUL)]
        public enum SentinelType : ushort
        {
            endOfSegment,
            endOfRoute,
            startOfSegment,
            startOfRoute
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xcf7154b31a69635bUL)]
    public class ManagerState : ICapnpSerializable
    {
        public const UInt64 typeId = 0xcf7154b31a69635bUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Processes = reader.Processes?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.ManagerState.ProcessState>(_));
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Processes.Init(Processes, (_s1, _v1) => _v1?.serialize(_s1));
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<Cereal.ManagerState.ProcessState> Processes
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
            public IReadOnlyList<Cereal.ManagerState.ProcessState.READER> Processes => ctx.ReadList(0).Cast(Cereal.ManagerState.ProcessState.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public ListOfStructsSerializer<Cereal.ManagerState.ProcessState.WRITER> Processes
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.ManagerState.ProcessState.WRITER>>(0);
                set => Link(0, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0x869a54d2708469eaUL)]
        public class ProcessState : ICapnpSerializable
        {
            public const UInt64 typeId = 0x869a54d2708469eaUL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Name = reader.Name;
                Pid = reader.Pid;
                Running = reader.Running;
                ExitCode = reader.ExitCode;
                ShouldBeRunning = reader.ShouldBeRunning;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Name = Name;
                writer.Pid = Pid;
                writer.Running = Running;
                writer.ExitCode = ExitCode;
                writer.ShouldBeRunning = ShouldBeRunning;
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

            public int Pid
            {
                get;
                set;
            }

            public bool Running
            {
                get;
                set;
            }

            public int ExitCode
            {
                get;
                set;
            }

            public bool ShouldBeRunning
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
                public int Pid => ctx.ReadDataInt(0UL, 0);
                public bool Running => ctx.ReadDataBool(32UL, false);
                public int ExitCode => ctx.ReadDataInt(64UL, 0);
                public bool ShouldBeRunning => ctx.ReadDataBool(33UL, false);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(2, 1);
                }

                public string Name
                {
                    get => this.ReadText(0, null);
                    set => this.WriteText(0, value, null);
                }

                public int Pid
                {
                    get => this.ReadDataInt(0UL, 0);
                    set => this.WriteData(0UL, value, 0);
                }

                public bool Running
                {
                    get => this.ReadDataBool(32UL, false);
                    set => this.WriteData(32UL, value, false);
                }

                public int ExitCode
                {
                    get => this.ReadDataInt(64UL, 0);
                    set => this.WriteData(64UL, value, 0);
                }

                public bool ShouldBeRunning
                {
                    get => this.ReadDataBool(33UL, false);
                    set => this.WriteData(33UL, value, false);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xde266b39b76b461eUL)]
    public class UploaderState : ICapnpSerializable
    {
        public const UInt64 typeId = 0xde266b39b76b461eUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            ImmediateQueueSize = reader.ImmediateQueueSize;
            ImmediateQueueCount = reader.ImmediateQueueCount;
            RawQueueSize = reader.RawQueueSize;
            RawQueueCount = reader.RawQueueCount;
            LastTime = reader.LastTime;
            LastSpeed = reader.LastSpeed;
            LastFilename = reader.LastFilename;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.ImmediateQueueSize = ImmediateQueueSize;
            writer.ImmediateQueueCount = ImmediateQueueCount;
            writer.RawQueueSize = RawQueueSize;
            writer.RawQueueCount = RawQueueCount;
            writer.LastTime = LastTime;
            writer.LastSpeed = LastSpeed;
            writer.LastFilename = LastFilename;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public uint ImmediateQueueSize
        {
            get;
            set;
        }

        public uint ImmediateQueueCount
        {
            get;
            set;
        }

        public uint RawQueueSize
        {
            get;
            set;
        }

        public uint RawQueueCount
        {
            get;
            set;
        }

        public float LastTime
        {
            get;
            set;
        }

        public float LastSpeed
        {
            get;
            set;
        }

        public string LastFilename
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
            public uint ImmediateQueueSize => ctx.ReadDataUInt(0UL, 0U);
            public uint ImmediateQueueCount => ctx.ReadDataUInt(32UL, 0U);
            public uint RawQueueSize => ctx.ReadDataUInt(64UL, 0U);
            public uint RawQueueCount => ctx.ReadDataUInt(96UL, 0U);
            public float LastTime => ctx.ReadDataFloat(128UL, 0F);
            public float LastSpeed => ctx.ReadDataFloat(160UL, 0F);
            public string LastFilename => ctx.ReadText(0, null);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(3, 1);
            }

            public uint ImmediateQueueSize
            {
                get => this.ReadDataUInt(0UL, 0U);
                set => this.WriteData(0UL, value, 0U);
            }

            public uint ImmediateQueueCount
            {
                get => this.ReadDataUInt(32UL, 0U);
                set => this.WriteData(32UL, value, 0U);
            }

            public uint RawQueueSize
            {
                get => this.ReadDataUInt(64UL, 0U);
                set => this.WriteData(64UL, value, 0U);
            }

            public uint RawQueueCount
            {
                get => this.ReadDataUInt(96UL, 0U);
                set => this.WriteData(96UL, value, 0U);
            }

            public float LastTime
            {
                get => this.ReadDataFloat(128UL, 0F);
                set => this.WriteData(128UL, value, 0F);
            }

            public float LastSpeed
            {
                get => this.ReadDataFloat(160UL, 0F);
                set => this.WriteData(160UL, value, 0F);
            }

            public string LastFilename
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc18216b27f8602afUL)]
    public class NavInstruction : ICapnpSerializable
    {
        public const UInt64 typeId = 0xc18216b27f8602afUL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            ManeuverPrimaryText = reader.ManeuverPrimaryText;
            ManeuverSecondaryText = reader.ManeuverSecondaryText;
            ManeuverDistance = reader.ManeuverDistance;
            ManeuverType = reader.ManeuverType;
            ManeuverModifier = reader.ManeuverModifier;
            DistanceRemaining = reader.DistanceRemaining;
            TimeRemaining = reader.TimeRemaining;
            TimeRemainingTypical = reader.TimeRemainingTypical;
            Lanes = reader.Lanes?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.NavInstruction.Lane>(_));
            ShowFull = reader.ShowFull;
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.ManeuverPrimaryText = ManeuverPrimaryText;
            writer.ManeuverSecondaryText = ManeuverSecondaryText;
            writer.ManeuverDistance = ManeuverDistance;
            writer.ManeuverType = ManeuverType;
            writer.ManeuverModifier = ManeuverModifier;
            writer.DistanceRemaining = DistanceRemaining;
            writer.TimeRemaining = TimeRemaining;
            writer.TimeRemainingTypical = TimeRemainingTypical;
            writer.Lanes.Init(Lanes, (_s1, _v1) => _v1?.serialize(_s1));
            writer.ShowFull = ShowFull;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public string ManeuverPrimaryText
        {
            get;
            set;
        }

        public string ManeuverSecondaryText
        {
            get;
            set;
        }

        public float ManeuverDistance
        {
            get;
            set;
        }

        public string ManeuverType
        {
            get;
            set;
        }

        public string ManeuverModifier
        {
            get;
            set;
        }

        public float DistanceRemaining
        {
            get;
            set;
        }

        public float TimeRemaining
        {
            get;
            set;
        }

        public float TimeRemainingTypical
        {
            get;
            set;
        }

        public IReadOnlyList<Cereal.NavInstruction.Lane> Lanes
        {
            get;
            set;
        }

        public bool ShowFull
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
            public string ManeuverPrimaryText => ctx.ReadText(0, null);
            public string ManeuverSecondaryText => ctx.ReadText(1, null);
            public float ManeuverDistance => ctx.ReadDataFloat(0UL, 0F);
            public string ManeuverType => ctx.ReadText(2, null);
            public string ManeuverModifier => ctx.ReadText(3, null);
            public float DistanceRemaining => ctx.ReadDataFloat(32UL, 0F);
            public float TimeRemaining => ctx.ReadDataFloat(64UL, 0F);
            public float TimeRemainingTypical => ctx.ReadDataFloat(96UL, 0F);
            public IReadOnlyList<Cereal.NavInstruction.Lane.READER> Lanes => ctx.ReadList(4).Cast(Cereal.NavInstruction.Lane.READER.create);
            public bool ShowFull => ctx.ReadDataBool(128UL, false);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(3, 5);
            }

            public string ManeuverPrimaryText
            {
                get => this.ReadText(0, null);
                set => this.WriteText(0, value, null);
            }

            public string ManeuverSecondaryText
            {
                get => this.ReadText(1, null);
                set => this.WriteText(1, value, null);
            }

            public float ManeuverDistance
            {
                get => this.ReadDataFloat(0UL, 0F);
                set => this.WriteData(0UL, value, 0F);
            }

            public string ManeuverType
            {
                get => this.ReadText(2, null);
                set => this.WriteText(2, value, null);
            }

            public string ManeuverModifier
            {
                get => this.ReadText(3, null);
                set => this.WriteText(3, value, null);
            }

            public float DistanceRemaining
            {
                get => this.ReadDataFloat(32UL, 0F);
                set => this.WriteData(32UL, value, 0F);
            }

            public float TimeRemaining
            {
                get => this.ReadDataFloat(64UL, 0F);
                set => this.WriteData(64UL, value, 0F);
            }

            public float TimeRemainingTypical
            {
                get => this.ReadDataFloat(96UL, 0F);
                set => this.WriteData(96UL, value, 0F);
            }

            public ListOfStructsSerializer<Cereal.NavInstruction.Lane.WRITER> Lanes
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.NavInstruction.Lane.WRITER>>(4);
                set => Link(4, value);
            }

            public bool ShowFull
            {
                get => this.ReadDataBool(128UL, false);
                set => this.WriteData(128UL, value, false);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa4cd1689c0a439d9UL)]
        public class Lane : ICapnpSerializable
        {
            public const UInt64 typeId = 0xa4cd1689c0a439d9UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Directions = reader.Directions;
                Active = reader.Active;
                ActiveDirection = reader.ActiveDirection;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Directions.Init(Directions);
                writer.Active = Active;
                writer.ActiveDirection = ActiveDirection;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public IReadOnlyList<Cereal.NavInstruction.Direction> Directions
            {
                get;
                set;
            }

            public bool Active
            {
                get;
                set;
            }

            public Cereal.NavInstruction.Direction ActiveDirection
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
                public IReadOnlyList<Cereal.NavInstruction.Direction> Directions => ctx.ReadList(0).CastEnums(_0 => (Cereal.NavInstruction.Direction)_0);
                public bool Active => ctx.ReadDataBool(0UL, false);
                public Cereal.NavInstruction.Direction ActiveDirection => (Cereal.NavInstruction.Direction)ctx.ReadDataUShort(16UL, (ushort)0);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 1);
                }

                public ListOfPrimitivesSerializer<Cereal.NavInstruction.Direction> Directions
                {
                    get => BuildPointer<ListOfPrimitivesSerializer<Cereal.NavInstruction.Direction>>(0);
                    set => Link(0, value);
                }

                public bool Active
                {
                    get => this.ReadDataBool(0UL, false);
                    set => this.WriteData(0UL, value, false);
                }

                public Cereal.NavInstruction.Direction ActiveDirection
                {
                    get => (Cereal.NavInstruction.Direction)this.ReadDataUShort(16UL, (ushort)0);
                    set => this.WriteData(16UL, (ushort)value, (ushort)0);
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xeea5b9d8c9e5c192UL)]
        public enum Direction : ushort
        {
            none,
            left,
            right,
            straight
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xa61452f6440d97d3UL)]
    public class NavRoute : ICapnpSerializable
    {
        public const UInt64 typeId = 0xa61452f6440d97d3UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            Coordinates = reader.Coordinates?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.NavRoute.Coordinate>(_));
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
            writer.Coordinates.Init(Coordinates, (_s1, _v1) => _v1?.serialize(_s1));
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public IReadOnlyList<Cereal.NavRoute.Coordinate> Coordinates
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
            public IReadOnlyList<Cereal.NavRoute.Coordinate.READER> Coordinates => ctx.ReadList(0).Cast(Cereal.NavRoute.Coordinate.READER.create);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 1);
            }

            public ListOfStructsSerializer<Cereal.NavRoute.Coordinate.WRITER> Coordinates
            {
                get => BuildPointer<ListOfStructsSerializer<Cereal.NavRoute.Coordinate.WRITER>>(0);
                set => Link(0, value);
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xc4c96f53ad1e7485UL)]
        public class Coordinate : ICapnpSerializable
        {
            public const UInt64 typeId = 0xc4c96f53ad1e7485UL;
            void ICapnpSerializable.Deserialize(DeserializerState arg_)
            {
                var reader = READER.create(arg_);
                Latitude = reader.Latitude;
                Longitude = reader.Longitude;
                applyDefaults();
            }

            public void serialize(WRITER writer)
            {
                writer.Latitude = Latitude;
                writer.Longitude = Longitude;
            }

            void ICapnpSerializable.Serialize(SerializerState arg_)
            {
                serialize(arg_.Rewrap<WRITER>());
            }

            public void applyDefaults()
            {
            }

            public float Latitude
            {
                get;
                set;
            }

            public float Longitude
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
                public float Latitude => ctx.ReadDataFloat(0UL, 0F);
                public float Longitude => ctx.ReadDataFloat(32UL, 0F);
            }

            public class WRITER : SerializerState
            {
                public WRITER()
                {
                    this.SetStruct(1, 0);
                }

                public float Latitude
                {
                    get => this.ReadDataFloat(0UL, 0F);
                    set => this.WriteData(0UL, value, 0F);
                }

                public float Longitude
                {
                    get => this.ReadDataFloat(32UL, 0F);
                    set => this.WriteData(32UL, value, 0F);
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("capnpc-csharp", "1.3.0.0"), TypeId(0xd314cfd957229c11UL)]
    public class Event : ICapnpSerializable
    {
        public const UInt64 typeId = 0xd314cfd957229c11UL;
        public enum WHICH : ushort
        {
            InitData = 0,
            RoadCameraState = 1,
            GpsNMEA = 2,
            SensorEventDEPRECATED = 3,
            Can = 4,
            DeviceState = 5,
            ControlsState = 6,
            LiveEventDEPRECATED = 7,
            Model = 8,
            FeaturesDEPRECATED = 9,
            SensorEvents = 10,
            PandaStateDEPRECATED = 11,
            RadarState = 12,
            LiveUIDEPRECATED = 13,
            RoadEncodeIdx = 14,
            LiveTracks = 15,
            Sendcan = 16,
            LogMessage = 17,
            LiveCalibration = 18,
            AndroidLog = 19,
            GpsLocationDEPRECATED = 20,
            CarState = 21,
            CarControl = 22,
            LongitudinalPlan = 23,
            LiveLocationDEPRECATED = 24,
            EthernetDataDEPRECATED = 25,
            NavUpdateDEPRECATED = 26,
            CellInfoDEPRECATED = 27,
            WifiScanDEPRECATED = 28,
            AndroidGnssDEPRECATED = 29,
            QcomGnssDEPRECATD = 30,
            LidarPtsDEPRECATED = 31,
            ProcLog = 32,
            UbloxGnss = 33,
            Clocks = 34,
            LiveMpcDEPRECATED = 35,
            LiveLongitudinalMpcDEPRECATED = 36,
            NavStatusDEPRECATED = 37,
            UbloxRaw = 38,
            GpsPlannerPointsDEPRECATED = 39,
            GpsPlannerPlanDEPRECATED = 40,
            ApplanixRawDEPRECATED = 41,
            TrafficEventsDEPRECATED = 42,
            LiveLocationTimingDEPRECATED = 43,
            OrbslamCorrectionDEPRECATED = 44,
            LiveLocationCorrectedDEPRECATED = 45,
            OrbObservationDEPRECATED = 46,
            GpsLocationExternal = 47,
            LocationDEPRECATED = 48,
            UiNavigationEventDEPRECATED = 49,
            LiveLocationKalmanDEPRECATED = 50,
            TestJoystick = 51,
            OrbOdometryDEPRECATED = 52,
            OrbFeaturesDEPRECATED = 53,
            ApplanixLocationDEPRECATED = 54,
            OrbKeyFrameDEPRECATED = 55,
            UiLayoutStateDEPRECATED = 56,
            OrbFeaturesSummaryDEPRECATED = 57,
            DriverState = 58,
            Boot = 59,
            LiveParameters = 60,
            LiveMapDataDEPRECATED = 61,
            CameraOdometry = 62,
            LateralPlan = 63,
            KalmanOdometryDEPRECATED = 64,
            Thumbnail = 65,
            CarEvents = 66,
            CarParams = 67,
            DriverCameraState = 68,
            DriverMonitoringState = 69,
            LiveLocationKalman = 70,
            Sentinel = 71,
            WideRoadCameraState = 72,
            ModelV2 = 73,
            DriverEncodeIdx = 74,
            WideRoadEncodeIdx = 75,
            ManagerState = 76,
            UploaderState = 77,
            PeripheralState = 78,
            PandaStates = 79,
            NavInstruction = 80,
            NavRoute = 81,
            NavThumbnail = 82,
            ErrorLogMessage = 83,
            undefined = 65535
        }

        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            switch (reader.which)
            {
                case WHICH.InitData:
                    InitData = CapnpSerializable.Create<Cereal.InitData>(reader.InitData);
                    break;
                case WHICH.RoadCameraState:
                    RoadCameraState = CapnpSerializable.Create<Cereal.FrameData>(reader.RoadCameraState);
                    break;
                case WHICH.GpsNMEA:
                    GpsNMEA = CapnpSerializable.Create<Cereal.GPSNMEAData>(reader.GpsNMEA);
                    break;
                case WHICH.SensorEventDEPRECATED:
                    SensorEventDEPRECATED = CapnpSerializable.Create<Cereal.SensorEventData>(reader.SensorEventDEPRECATED);
                    break;
                case WHICH.Can:
                    Can = reader.Can?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CanData>(_));
                    break;
                case WHICH.DeviceState:
                    DeviceState = CapnpSerializable.Create<Cereal.DeviceState>(reader.DeviceState);
                    break;
                case WHICH.ControlsState:
                    ControlsState = CapnpSerializable.Create<Cereal.ControlsState>(reader.ControlsState);
                    break;
                case WHICH.LiveEventDEPRECATED:
                    LiveEventDEPRECATED = reader.LiveEventDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.LiveEventData>(_));
                    break;
                case WHICH.Model:
                    Model = CapnpSerializable.Create<Cereal.ModelData>(reader.Model);
                    break;
                case WHICH.FeaturesDEPRECATED:
                    FeaturesDEPRECATED = CapnpSerializable.Create<Cereal.CalibrationFeatures>(reader.FeaturesDEPRECATED);
                    break;
                case WHICH.SensorEvents:
                    SensorEvents = reader.SensorEvents?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.SensorEventData>(_));
                    break;
                case WHICH.PandaStateDEPRECATED:
                    PandaStateDEPRECATED = CapnpSerializable.Create<Cereal.PandaState>(reader.PandaStateDEPRECATED);
                    break;
                case WHICH.RadarState:
                    RadarState = CapnpSerializable.Create<Cereal.RadarState>(reader.RadarState);
                    break;
                case WHICH.LiveUIDEPRECATED:
                    LiveUIDEPRECATED = CapnpSerializable.Create<Cereal.LiveUI>(reader.LiveUIDEPRECATED);
                    break;
                case WHICH.RoadEncodeIdx:
                    RoadEncodeIdx = CapnpSerializable.Create<Cereal.EncodeIndex>(reader.RoadEncodeIdx);
                    break;
                case WHICH.LiveTracks:
                    LiveTracks = reader.LiveTracks?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.LiveTracks>(_));
                    break;
                case WHICH.Sendcan:
                    Sendcan = reader.Sendcan?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CanData>(_));
                    break;
                case WHICH.LogMessage:
                    LogMessage = reader.LogMessage;
                    break;
                case WHICH.LiveCalibration:
                    LiveCalibration = CapnpSerializable.Create<Cereal.LiveCalibrationData>(reader.LiveCalibration);
                    break;
                case WHICH.AndroidLog:
                    AndroidLog = CapnpSerializable.Create<Cereal.AndroidLogEntry>(reader.AndroidLog);
                    break;
                case WHICH.GpsLocationDEPRECATED:
                    GpsLocationDEPRECATED = CapnpSerializable.Create<Cereal.GpsLocationData>(reader.GpsLocationDEPRECATED);
                    break;
                case WHICH.CarState:
                    CarState = CapnpSerializable.Create<Cereal.CarState>(reader.CarState);
                    break;
                case WHICH.CarControl:
                    CarControl = CapnpSerializable.Create<Cereal.CarControl>(reader.CarControl);
                    break;
                case WHICH.LongitudinalPlan:
                    LongitudinalPlan = CapnpSerializable.Create<Cereal.LongitudinalPlan>(reader.LongitudinalPlan);
                    break;
                case WHICH.LiveLocationDEPRECATED:
                    LiveLocationDEPRECATED = CapnpSerializable.Create<Cereal.LiveLocationData>(reader.LiveLocationDEPRECATED);
                    break;
                case WHICH.EthernetDataDEPRECATED:
                    EthernetDataDEPRECATED = reader.EthernetDataDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.EthernetPacket>(_));
                    break;
                case WHICH.NavUpdateDEPRECATED:
                    NavUpdateDEPRECATED = CapnpSerializable.Create<Cereal.NavUpdate>(reader.NavUpdateDEPRECATED);
                    break;
                case WHICH.CellInfoDEPRECATED:
                    CellInfoDEPRECATED = reader.CellInfoDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CellInfo>(_));
                    break;
                case WHICH.WifiScanDEPRECATED:
                    WifiScanDEPRECATED = reader.WifiScanDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.WifiScan>(_));
                    break;
                case WHICH.AndroidGnssDEPRECATED:
                    AndroidGnssDEPRECATED = CapnpSerializable.Create<Cereal.AndroidGnss>(reader.AndroidGnssDEPRECATED);
                    break;
                case WHICH.QcomGnssDEPRECATD:
                    QcomGnssDEPRECATD = CapnpSerializable.Create<Cereal.QcomGnss>(reader.QcomGnssDEPRECATD);
                    break;
                case WHICH.LidarPtsDEPRECATED:
                    LidarPtsDEPRECATED = CapnpSerializable.Create<Cereal.LidarPts>(reader.LidarPtsDEPRECATED);
                    break;
                case WHICH.ProcLog:
                    ProcLog = CapnpSerializable.Create<Cereal.ProcLog>(reader.ProcLog);
                    break;
                case WHICH.UbloxGnss:
                    UbloxGnss = CapnpSerializable.Create<Cereal.UbloxGnss>(reader.UbloxGnss);
                    break;
                case WHICH.Clocks:
                    Clocks = CapnpSerializable.Create<Cereal.Clocks>(reader.Clocks);
                    break;
                case WHICH.LiveMpcDEPRECATED:
                    LiveMpcDEPRECATED = CapnpSerializable.Create<Cereal.LiveMpcData>(reader.LiveMpcDEPRECATED);
                    break;
                case WHICH.LiveLongitudinalMpcDEPRECATED:
                    LiveLongitudinalMpcDEPRECATED = CapnpSerializable.Create<Cereal.LiveLongitudinalMpcData>(reader.LiveLongitudinalMpcDEPRECATED);
                    break;
                case WHICH.NavStatusDEPRECATED:
                    NavStatusDEPRECATED = CapnpSerializable.Create<Cereal.NavStatus>(reader.NavStatusDEPRECATED);
                    break;
                case WHICH.UbloxRaw:
                    UbloxRaw = reader.UbloxRaw;
                    break;
                case WHICH.GpsPlannerPointsDEPRECATED:
                    GpsPlannerPointsDEPRECATED = CapnpSerializable.Create<Cereal.GPSPlannerPoints>(reader.GpsPlannerPointsDEPRECATED);
                    break;
                case WHICH.GpsPlannerPlanDEPRECATED:
                    GpsPlannerPlanDEPRECATED = CapnpSerializable.Create<Cereal.GPSPlannerPlan>(reader.GpsPlannerPlanDEPRECATED);
                    break;
                case WHICH.ApplanixRawDEPRECATED:
                    ApplanixRawDEPRECATED = reader.ApplanixRawDEPRECATED;
                    break;
                case WHICH.TrafficEventsDEPRECATED:
                    TrafficEventsDEPRECATED = reader.TrafficEventsDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.TrafficEvent>(_));
                    break;
                case WHICH.LiveLocationTimingDEPRECATED:
                    LiveLocationTimingDEPRECATED = CapnpSerializable.Create<Cereal.LiveLocationData>(reader.LiveLocationTimingDEPRECATED);
                    break;
                case WHICH.OrbslamCorrectionDEPRECATED:
                    OrbslamCorrectionDEPRECATED = CapnpSerializable.Create<Cereal.OrbslamCorrection>(reader.OrbslamCorrectionDEPRECATED);
                    break;
                case WHICH.LiveLocationCorrectedDEPRECATED:
                    LiveLocationCorrectedDEPRECATED = CapnpSerializable.Create<Cereal.LiveLocationData>(reader.LiveLocationCorrectedDEPRECATED);
                    break;
                case WHICH.OrbObservationDEPRECATED:
                    OrbObservationDEPRECATED = reader.OrbObservationDEPRECATED?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.OrbObservation>(_));
                    break;
                case WHICH.GpsLocationExternal:
                    GpsLocationExternal = CapnpSerializable.Create<Cereal.GpsLocationData>(reader.GpsLocationExternal);
                    break;
                case WHICH.LocationDEPRECATED:
                    LocationDEPRECATED = CapnpSerializable.Create<Cereal.LiveLocationData>(reader.LocationDEPRECATED);
                    break;
                case WHICH.UiNavigationEventDEPRECATED:
                    UiNavigationEventDEPRECATED = CapnpSerializable.Create<Cereal.UiNavigationEvent>(reader.UiNavigationEventDEPRECATED);
                    break;
                case WHICH.LiveLocationKalmanDEPRECATED:
                    LiveLocationKalmanDEPRECATED = CapnpSerializable.Create<Cereal.LiveLocationData>(reader.LiveLocationKalmanDEPRECATED);
                    break;
                case WHICH.TestJoystick:
                    TestJoystick = CapnpSerializable.Create<Cereal.Joystick>(reader.TestJoystick);
                    break;
                case WHICH.OrbOdometryDEPRECATED:
                    OrbOdometryDEPRECATED = CapnpSerializable.Create<Cereal.OrbOdometry>(reader.OrbOdometryDEPRECATED);
                    break;
                case WHICH.OrbFeaturesDEPRECATED:
                    OrbFeaturesDEPRECATED = CapnpSerializable.Create<Cereal.OrbFeatures>(reader.OrbFeaturesDEPRECATED);
                    break;
                case WHICH.ApplanixLocationDEPRECATED:
                    ApplanixLocationDEPRECATED = CapnpSerializable.Create<Cereal.LiveLocationData>(reader.ApplanixLocationDEPRECATED);
                    break;
                case WHICH.OrbKeyFrameDEPRECATED:
                    OrbKeyFrameDEPRECATED = CapnpSerializable.Create<Cereal.OrbKeyFrame>(reader.OrbKeyFrameDEPRECATED);
                    break;
                case WHICH.UiLayoutStateDEPRECATED:
                    UiLayoutStateDEPRECATED = CapnpSerializable.Create<Cereal.UiLayoutState>(reader.UiLayoutStateDEPRECATED);
                    break;
                case WHICH.OrbFeaturesSummaryDEPRECATED:
                    OrbFeaturesSummaryDEPRECATED = CapnpSerializable.Create<Cereal.OrbFeaturesSummary>(reader.OrbFeaturesSummaryDEPRECATED);
                    break;
                case WHICH.DriverState:
                    DriverState = CapnpSerializable.Create<Cereal.DriverState>(reader.DriverState);
                    break;
                case WHICH.Boot:
                    Boot = CapnpSerializable.Create<Cereal.Boot>(reader.Boot);
                    break;
                case WHICH.LiveParameters:
                    LiveParameters = CapnpSerializable.Create<Cereal.LiveParametersData>(reader.LiveParameters);
                    break;
                case WHICH.LiveMapDataDEPRECATED:
                    LiveMapDataDEPRECATED = CapnpSerializable.Create<Cereal.LiveMapDataDEPRECATED>(reader.LiveMapDataDEPRECATED);
                    break;
                case WHICH.CameraOdometry:
                    CameraOdometry = CapnpSerializable.Create<Cereal.CameraOdometry>(reader.CameraOdometry);
                    break;
                case WHICH.LateralPlan:
                    LateralPlan = CapnpSerializable.Create<Cereal.LateralPlan>(reader.LateralPlan);
                    break;
                case WHICH.KalmanOdometryDEPRECATED:
                    KalmanOdometryDEPRECATED = CapnpSerializable.Create<Cereal.KalmanOdometry>(reader.KalmanOdometryDEPRECATED);
                    break;
                case WHICH.Thumbnail:
                    Thumbnail = CapnpSerializable.Create<Cereal.Thumbnail>(reader.Thumbnail);
                    break;
                case WHICH.CarEvents:
                    CarEvents = reader.CarEvents?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.CarEvent>(_));
                    break;
                case WHICH.CarParams:
                    CarParams = CapnpSerializable.Create<Cereal.CarParams>(reader.CarParams);
                    break;
                case WHICH.DriverCameraState:
                    DriverCameraState = CapnpSerializable.Create<Cereal.FrameData>(reader.DriverCameraState);
                    break;
                case WHICH.DriverMonitoringState:
                    DriverMonitoringState = CapnpSerializable.Create<Cereal.DriverMonitoringState>(reader.DriverMonitoringState);
                    break;
                case WHICH.LiveLocationKalman:
                    LiveLocationKalman = CapnpSerializable.Create<Cereal.LiveLocationKalman>(reader.LiveLocationKalman);
                    break;
                case WHICH.Sentinel:
                    Sentinel = CapnpSerializable.Create<Cereal.Sentinel>(reader.Sentinel);
                    break;
                case WHICH.WideRoadCameraState:
                    WideRoadCameraState = CapnpSerializable.Create<Cereal.FrameData>(reader.WideRoadCameraState);
                    break;
                case WHICH.ModelV2:
                    ModelV2 = CapnpSerializable.Create<Cereal.ModelDataV2>(reader.ModelV2);
                    break;
                case WHICH.DriverEncodeIdx:
                    DriverEncodeIdx = CapnpSerializable.Create<Cereal.EncodeIndex>(reader.DriverEncodeIdx);
                    break;
                case WHICH.WideRoadEncodeIdx:
                    WideRoadEncodeIdx = CapnpSerializable.Create<Cereal.EncodeIndex>(reader.WideRoadEncodeIdx);
                    break;
                case WHICH.ManagerState:
                    ManagerState = CapnpSerializable.Create<Cereal.ManagerState>(reader.ManagerState);
                    break;
                case WHICH.UploaderState:
                    UploaderState = CapnpSerializable.Create<Cereal.UploaderState>(reader.UploaderState);
                    break;
                case WHICH.PeripheralState:
                    PeripheralState = CapnpSerializable.Create<Cereal.PeripheralState>(reader.PeripheralState);
                    break;
                case WHICH.PandaStates:
                    PandaStates = reader.PandaStates?.ToReadOnlyList(_ => CapnpSerializable.Create<Cereal.PandaState>(_));
                    break;
                case WHICH.NavInstruction:
                    NavInstruction = CapnpSerializable.Create<Cereal.NavInstruction>(reader.NavInstruction);
                    break;
                case WHICH.NavRoute:
                    NavRoute = CapnpSerializable.Create<Cereal.NavRoute>(reader.NavRoute);
                    break;
                case WHICH.NavThumbnail:
                    NavThumbnail = CapnpSerializable.Create<Cereal.Thumbnail>(reader.NavThumbnail);
                    break;
                case WHICH.ErrorLogMessage:
                    ErrorLogMessage = reader.ErrorLogMessage;
                    break;
            }

            LogMonoTime = reader.LogMonoTime;
            Valid = reader.Valid;
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
                    case WHICH.InitData:
                        _content = null;
                        break;
                    case WHICH.RoadCameraState:
                        _content = null;
                        break;
                    case WHICH.GpsNMEA:
                        _content = null;
                        break;
                    case WHICH.SensorEventDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.Can:
                        _content = null;
                        break;
                    case WHICH.DeviceState:
                        _content = null;
                        break;
                    case WHICH.ControlsState:
                        _content = null;
                        break;
                    case WHICH.LiveEventDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.Model:
                        _content = null;
                        break;
                    case WHICH.FeaturesDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.SensorEvents:
                        _content = null;
                        break;
                    case WHICH.PandaStateDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.RadarState:
                        _content = null;
                        break;
                    case WHICH.LiveUIDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.RoadEncodeIdx:
                        _content = null;
                        break;
                    case WHICH.LiveTracks:
                        _content = null;
                        break;
                    case WHICH.Sendcan:
                        _content = null;
                        break;
                    case WHICH.LogMessage:
                        _content = null;
                        break;
                    case WHICH.LiveCalibration:
                        _content = null;
                        break;
                    case WHICH.AndroidLog:
                        _content = null;
                        break;
                    case WHICH.GpsLocationDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.CarState:
                        _content = null;
                        break;
                    case WHICH.CarControl:
                        _content = null;
                        break;
                    case WHICH.LongitudinalPlan:
                        _content = null;
                        break;
                    case WHICH.LiveLocationDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.EthernetDataDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.NavUpdateDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.CellInfoDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.WifiScanDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.AndroidGnssDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.QcomGnssDEPRECATD:
                        _content = null;
                        break;
                    case WHICH.LidarPtsDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.ProcLog:
                        _content = null;
                        break;
                    case WHICH.UbloxGnss:
                        _content = null;
                        break;
                    case WHICH.Clocks:
                        _content = null;
                        break;
                    case WHICH.LiveMpcDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.LiveLongitudinalMpcDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.NavStatusDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.UbloxRaw:
                        _content = null;
                        break;
                    case WHICH.GpsPlannerPointsDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.GpsPlannerPlanDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.ApplanixRawDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.TrafficEventsDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.LiveLocationTimingDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.OrbslamCorrectionDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.LiveLocationCorrectedDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.OrbObservationDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.GpsLocationExternal:
                        _content = null;
                        break;
                    case WHICH.LocationDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.UiNavigationEventDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.LiveLocationKalmanDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.TestJoystick:
                        _content = null;
                        break;
                    case WHICH.OrbOdometryDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.OrbFeaturesDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.ApplanixLocationDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.OrbKeyFrameDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.UiLayoutStateDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.OrbFeaturesSummaryDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.DriverState:
                        _content = null;
                        break;
                    case WHICH.Boot:
                        _content = null;
                        break;
                    case WHICH.LiveParameters:
                        _content = null;
                        break;
                    case WHICH.LiveMapDataDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.CameraOdometry:
                        _content = null;
                        break;
                    case WHICH.LateralPlan:
                        _content = null;
                        break;
                    case WHICH.KalmanOdometryDEPRECATED:
                        _content = null;
                        break;
                    case WHICH.Thumbnail:
                        _content = null;
                        break;
                    case WHICH.CarEvents:
                        _content = null;
                        break;
                    case WHICH.CarParams:
                        _content = null;
                        break;
                    case WHICH.DriverCameraState:
                        _content = null;
                        break;
                    case WHICH.DriverMonitoringState:
                        _content = null;
                        break;
                    case WHICH.LiveLocationKalman:
                        _content = null;
                        break;
                    case WHICH.Sentinel:
                        _content = null;
                        break;
                    case WHICH.WideRoadCameraState:
                        _content = null;
                        break;
                    case WHICH.ModelV2:
                        _content = null;
                        break;
                    case WHICH.DriverEncodeIdx:
                        _content = null;
                        break;
                    case WHICH.WideRoadEncodeIdx:
                        _content = null;
                        break;
                    case WHICH.ManagerState:
                        _content = null;
                        break;
                    case WHICH.UploaderState:
                        _content = null;
                        break;
                    case WHICH.PeripheralState:
                        _content = null;
                        break;
                    case WHICH.PandaStates:
                        _content = null;
                        break;
                    case WHICH.NavInstruction:
                        _content = null;
                        break;
                    case WHICH.NavRoute:
                        _content = null;
                        break;
                    case WHICH.NavThumbnail:
                        _content = null;
                        break;
                    case WHICH.ErrorLogMessage:
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
                case WHICH.InitData:
                    InitData?.serialize(writer.InitData);
                    break;
                case WHICH.RoadCameraState:
                    RoadCameraState?.serialize(writer.RoadCameraState);
                    break;
                case WHICH.GpsNMEA:
                    GpsNMEA?.serialize(writer.GpsNMEA);
                    break;
                case WHICH.SensorEventDEPRECATED:
                    SensorEventDEPRECATED?.serialize(writer.SensorEventDEPRECATED);
                    break;
                case WHICH.Can:
                    writer.Can.Init(Can, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.DeviceState:
                    DeviceState?.serialize(writer.DeviceState);
                    break;
                case WHICH.ControlsState:
                    ControlsState?.serialize(writer.ControlsState);
                    break;
                case WHICH.LiveEventDEPRECATED:
                    writer.LiveEventDEPRECATED.Init(LiveEventDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.Model:
                    Model?.serialize(writer.Model);
                    break;
                case WHICH.FeaturesDEPRECATED:
                    FeaturesDEPRECATED?.serialize(writer.FeaturesDEPRECATED);
                    break;
                case WHICH.SensorEvents:
                    writer.SensorEvents.Init(SensorEvents, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.PandaStateDEPRECATED:
                    PandaStateDEPRECATED?.serialize(writer.PandaStateDEPRECATED);
                    break;
                case WHICH.RadarState:
                    RadarState?.serialize(writer.RadarState);
                    break;
                case WHICH.LiveUIDEPRECATED:
                    LiveUIDEPRECATED?.serialize(writer.LiveUIDEPRECATED);
                    break;
                case WHICH.RoadEncodeIdx:
                    RoadEncodeIdx?.serialize(writer.RoadEncodeIdx);
                    break;
                case WHICH.LiveTracks:
                    writer.LiveTracks.Init(LiveTracks, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.Sendcan:
                    writer.Sendcan.Init(Sendcan, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.LogMessage:
                    writer.LogMessage = LogMessage;
                    break;
                case WHICH.LiveCalibration:
                    LiveCalibration?.serialize(writer.LiveCalibration);
                    break;
                case WHICH.AndroidLog:
                    AndroidLog?.serialize(writer.AndroidLog);
                    break;
                case WHICH.GpsLocationDEPRECATED:
                    GpsLocationDEPRECATED?.serialize(writer.GpsLocationDEPRECATED);
                    break;
                case WHICH.CarState:
                    CarState?.serialize(writer.CarState);
                    break;
                case WHICH.CarControl:
                    CarControl?.serialize(writer.CarControl);
                    break;
                case WHICH.LongitudinalPlan:
                    LongitudinalPlan?.serialize(writer.LongitudinalPlan);
                    break;
                case WHICH.LiveLocationDEPRECATED:
                    LiveLocationDEPRECATED?.serialize(writer.LiveLocationDEPRECATED);
                    break;
                case WHICH.EthernetDataDEPRECATED:
                    writer.EthernetDataDEPRECATED.Init(EthernetDataDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.NavUpdateDEPRECATED:
                    NavUpdateDEPRECATED?.serialize(writer.NavUpdateDEPRECATED);
                    break;
                case WHICH.CellInfoDEPRECATED:
                    writer.CellInfoDEPRECATED.Init(CellInfoDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.WifiScanDEPRECATED:
                    writer.WifiScanDEPRECATED.Init(WifiScanDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.AndroidGnssDEPRECATED:
                    AndroidGnssDEPRECATED?.serialize(writer.AndroidGnssDEPRECATED);
                    break;
                case WHICH.QcomGnssDEPRECATD:
                    QcomGnssDEPRECATD?.serialize(writer.QcomGnssDEPRECATD);
                    break;
                case WHICH.LidarPtsDEPRECATED:
                    LidarPtsDEPRECATED?.serialize(writer.LidarPtsDEPRECATED);
                    break;
                case WHICH.ProcLog:
                    ProcLog?.serialize(writer.ProcLog);
                    break;
                case WHICH.UbloxGnss:
                    UbloxGnss?.serialize(writer.UbloxGnss);
                    break;
                case WHICH.Clocks:
                    Clocks?.serialize(writer.Clocks);
                    break;
                case WHICH.LiveMpcDEPRECATED:
                    LiveMpcDEPRECATED?.serialize(writer.LiveMpcDEPRECATED);
                    break;
                case WHICH.LiveLongitudinalMpcDEPRECATED:
                    LiveLongitudinalMpcDEPRECATED?.serialize(writer.LiveLongitudinalMpcDEPRECATED);
                    break;
                case WHICH.NavStatusDEPRECATED:
                    NavStatusDEPRECATED?.serialize(writer.NavStatusDEPRECATED);
                    break;
                case WHICH.UbloxRaw:
                    writer.UbloxRaw.Init(UbloxRaw);
                    break;
                case WHICH.GpsPlannerPointsDEPRECATED:
                    GpsPlannerPointsDEPRECATED?.serialize(writer.GpsPlannerPointsDEPRECATED);
                    break;
                case WHICH.GpsPlannerPlanDEPRECATED:
                    GpsPlannerPlanDEPRECATED?.serialize(writer.GpsPlannerPlanDEPRECATED);
                    break;
                case WHICH.ApplanixRawDEPRECATED:
                    writer.ApplanixRawDEPRECATED.Init(ApplanixRawDEPRECATED);
                    break;
                case WHICH.TrafficEventsDEPRECATED:
                    writer.TrafficEventsDEPRECATED.Init(TrafficEventsDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.LiveLocationTimingDEPRECATED:
                    LiveLocationTimingDEPRECATED?.serialize(writer.LiveLocationTimingDEPRECATED);
                    break;
                case WHICH.OrbslamCorrectionDEPRECATED:
                    OrbslamCorrectionDEPRECATED?.serialize(writer.OrbslamCorrectionDEPRECATED);
                    break;
                case WHICH.LiveLocationCorrectedDEPRECATED:
                    LiveLocationCorrectedDEPRECATED?.serialize(writer.LiveLocationCorrectedDEPRECATED);
                    break;
                case WHICH.OrbObservationDEPRECATED:
                    writer.OrbObservationDEPRECATED.Init(OrbObservationDEPRECATED, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.GpsLocationExternal:
                    GpsLocationExternal?.serialize(writer.GpsLocationExternal);
                    break;
                case WHICH.LocationDEPRECATED:
                    LocationDEPRECATED?.serialize(writer.LocationDEPRECATED);
                    break;
                case WHICH.UiNavigationEventDEPRECATED:
                    UiNavigationEventDEPRECATED?.serialize(writer.UiNavigationEventDEPRECATED);
                    break;
                case WHICH.LiveLocationKalmanDEPRECATED:
                    LiveLocationKalmanDEPRECATED?.serialize(writer.LiveLocationKalmanDEPRECATED);
                    break;
                case WHICH.TestJoystick:
                    TestJoystick?.serialize(writer.TestJoystick);
                    break;
                case WHICH.OrbOdometryDEPRECATED:
                    OrbOdometryDEPRECATED?.serialize(writer.OrbOdometryDEPRECATED);
                    break;
                case WHICH.OrbFeaturesDEPRECATED:
                    OrbFeaturesDEPRECATED?.serialize(writer.OrbFeaturesDEPRECATED);
                    break;
                case WHICH.ApplanixLocationDEPRECATED:
                    ApplanixLocationDEPRECATED?.serialize(writer.ApplanixLocationDEPRECATED);
                    break;
                case WHICH.OrbKeyFrameDEPRECATED:
                    OrbKeyFrameDEPRECATED?.serialize(writer.OrbKeyFrameDEPRECATED);
                    break;
                case WHICH.UiLayoutStateDEPRECATED:
                    UiLayoutStateDEPRECATED?.serialize(writer.UiLayoutStateDEPRECATED);
                    break;
                case WHICH.OrbFeaturesSummaryDEPRECATED:
                    OrbFeaturesSummaryDEPRECATED?.serialize(writer.OrbFeaturesSummaryDEPRECATED);
                    break;
                case WHICH.DriverState:
                    DriverState?.serialize(writer.DriverState);
                    break;
                case WHICH.Boot:
                    Boot?.serialize(writer.Boot);
                    break;
                case WHICH.LiveParameters:
                    LiveParameters?.serialize(writer.LiveParameters);
                    break;
                case WHICH.LiveMapDataDEPRECATED:
                    LiveMapDataDEPRECATED?.serialize(writer.LiveMapDataDEPRECATED);
                    break;
                case WHICH.CameraOdometry:
                    CameraOdometry?.serialize(writer.CameraOdometry);
                    break;
                case WHICH.LateralPlan:
                    LateralPlan?.serialize(writer.LateralPlan);
                    break;
                case WHICH.KalmanOdometryDEPRECATED:
                    KalmanOdometryDEPRECATED?.serialize(writer.KalmanOdometryDEPRECATED);
                    break;
                case WHICH.Thumbnail:
                    Thumbnail?.serialize(writer.Thumbnail);
                    break;
                case WHICH.CarEvents:
                    writer.CarEvents.Init(CarEvents, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.CarParams:
                    CarParams?.serialize(writer.CarParams);
                    break;
                case WHICH.DriverCameraState:
                    DriverCameraState?.serialize(writer.DriverCameraState);
                    break;
                case WHICH.DriverMonitoringState:
                    DriverMonitoringState?.serialize(writer.DriverMonitoringState);
                    break;
                case WHICH.LiveLocationKalman:
                    LiveLocationKalman?.serialize(writer.LiveLocationKalman);
                    break;
                case WHICH.Sentinel:
                    Sentinel?.serialize(writer.Sentinel);
                    break;
                case WHICH.WideRoadCameraState:
                    WideRoadCameraState?.serialize(writer.WideRoadCameraState);
                    break;
                case WHICH.ModelV2:
                    ModelV2?.serialize(writer.ModelV2);
                    break;
                case WHICH.DriverEncodeIdx:
                    DriverEncodeIdx?.serialize(writer.DriverEncodeIdx);
                    break;
                case WHICH.WideRoadEncodeIdx:
                    WideRoadEncodeIdx?.serialize(writer.WideRoadEncodeIdx);
                    break;
                case WHICH.ManagerState:
                    ManagerState?.serialize(writer.ManagerState);
                    break;
                case WHICH.UploaderState:
                    UploaderState?.serialize(writer.UploaderState);
                    break;
                case WHICH.PeripheralState:
                    PeripheralState?.serialize(writer.PeripheralState);
                    break;
                case WHICH.PandaStates:
                    writer.PandaStates.Init(PandaStates, (_s1, _v1) => _v1?.serialize(_s1));
                    break;
                case WHICH.NavInstruction:
                    NavInstruction?.serialize(writer.NavInstruction);
                    break;
                case WHICH.NavRoute:
                    NavRoute?.serialize(writer.NavRoute);
                    break;
                case WHICH.NavThumbnail:
                    NavThumbnail?.serialize(writer.NavThumbnail);
                    break;
                case WHICH.ErrorLogMessage:
                    writer.ErrorLogMessage = ErrorLogMessage;
                    break;
            }

            writer.LogMonoTime = LogMonoTime;
            writer.Valid = Valid;
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public ulong LogMonoTime
        {
            get;
            set;
        }

        public Cereal.InitData InitData
        {
            get => _which == WHICH.InitData ? (Cereal.InitData)_content : null;
            set
            {
                _which = WHICH.InitData;
                _content = value;
            }
        }

        public Cereal.FrameData RoadCameraState
        {
            get => _which == WHICH.RoadCameraState ? (Cereal.FrameData)_content : null;
            set
            {
                _which = WHICH.RoadCameraState;
                _content = value;
            }
        }

        public Cereal.GPSNMEAData GpsNMEA
        {
            get => _which == WHICH.GpsNMEA ? (Cereal.GPSNMEAData)_content : null;
            set
            {
                _which = WHICH.GpsNMEA;
                _content = value;
            }
        }

        public Cereal.SensorEventData SensorEventDEPRECATED
        {
            get => _which == WHICH.SensorEventDEPRECATED ? (Cereal.SensorEventData)_content : null;
            set
            {
                _which = WHICH.SensorEventDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.CanData> Can
        {
            get => _which == WHICH.Can ? (IReadOnlyList<Cereal.CanData>)_content : null;
            set
            {
                _which = WHICH.Can;
                _content = value;
            }
        }

        public Cereal.DeviceState DeviceState
        {
            get => _which == WHICH.DeviceState ? (Cereal.DeviceState)_content : null;
            set
            {
                _which = WHICH.DeviceState;
                _content = value;
            }
        }

        public Cereal.ControlsState ControlsState
        {
            get => _which == WHICH.ControlsState ? (Cereal.ControlsState)_content : null;
            set
            {
                _which = WHICH.ControlsState;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.LiveEventData> LiveEventDEPRECATED
        {
            get => _which == WHICH.LiveEventDEPRECATED ? (IReadOnlyList<Cereal.LiveEventData>)_content : null;
            set
            {
                _which = WHICH.LiveEventDEPRECATED;
                _content = value;
            }
        }

        public Cereal.ModelData Model
        {
            get => _which == WHICH.Model ? (Cereal.ModelData)_content : null;
            set
            {
                _which = WHICH.Model;
                _content = value;
            }
        }

        public Cereal.CalibrationFeatures FeaturesDEPRECATED
        {
            get => _which == WHICH.FeaturesDEPRECATED ? (Cereal.CalibrationFeatures)_content : null;
            set
            {
                _which = WHICH.FeaturesDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.SensorEventData> SensorEvents
        {
            get => _which == WHICH.SensorEvents ? (IReadOnlyList<Cereal.SensorEventData>)_content : null;
            set
            {
                _which = WHICH.SensorEvents;
                _content = value;
            }
        }

        public Cereal.PandaState PandaStateDEPRECATED
        {
            get => _which == WHICH.PandaStateDEPRECATED ? (Cereal.PandaState)_content : null;
            set
            {
                _which = WHICH.PandaStateDEPRECATED;
                _content = value;
            }
        }

        public Cereal.RadarState RadarState
        {
            get => _which == WHICH.RadarState ? (Cereal.RadarState)_content : null;
            set
            {
                _which = WHICH.RadarState;
                _content = value;
            }
        }

        public Cereal.LiveUI LiveUIDEPRECATED
        {
            get => _which == WHICH.LiveUIDEPRECATED ? (Cereal.LiveUI)_content : null;
            set
            {
                _which = WHICH.LiveUIDEPRECATED;
                _content = value;
            }
        }

        public Cereal.EncodeIndex RoadEncodeIdx
        {
            get => _which == WHICH.RoadEncodeIdx ? (Cereal.EncodeIndex)_content : null;
            set
            {
                _which = WHICH.RoadEncodeIdx;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.LiveTracks> LiveTracks
        {
            get => _which == WHICH.LiveTracks ? (IReadOnlyList<Cereal.LiveTracks>)_content : null;
            set
            {
                _which = WHICH.LiveTracks;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.CanData> Sendcan
        {
            get => _which == WHICH.Sendcan ? (IReadOnlyList<Cereal.CanData>)_content : null;
            set
            {
                _which = WHICH.Sendcan;
                _content = value;
            }
        }

        public string LogMessage
        {
            get => _which == WHICH.LogMessage ? (string)_content : null;
            set
            {
                _which = WHICH.LogMessage;
                _content = value;
            }
        }

        public Cereal.LiveCalibrationData LiveCalibration
        {
            get => _which == WHICH.LiveCalibration ? (Cereal.LiveCalibrationData)_content : null;
            set
            {
                _which = WHICH.LiveCalibration;
                _content = value;
            }
        }

        public Cereal.AndroidLogEntry AndroidLog
        {
            get => _which == WHICH.AndroidLog ? (Cereal.AndroidLogEntry)_content : null;
            set
            {
                _which = WHICH.AndroidLog;
                _content = value;
            }
        }

        public Cereal.GpsLocationData GpsLocationDEPRECATED
        {
            get => _which == WHICH.GpsLocationDEPRECATED ? (Cereal.GpsLocationData)_content : null;
            set
            {
                _which = WHICH.GpsLocationDEPRECATED;
                _content = value;
            }
        }

        public Cereal.CarState CarState
        {
            get => _which == WHICH.CarState ? (Cereal.CarState)_content : null;
            set
            {
                _which = WHICH.CarState;
                _content = value;
            }
        }

        public Cereal.CarControl CarControl
        {
            get => _which == WHICH.CarControl ? (Cereal.CarControl)_content : null;
            set
            {
                _which = WHICH.CarControl;
                _content = value;
            }
        }

        public Cereal.LongitudinalPlan LongitudinalPlan
        {
            get => _which == WHICH.LongitudinalPlan ? (Cereal.LongitudinalPlan)_content : null;
            set
            {
                _which = WHICH.LongitudinalPlan;
                _content = value;
            }
        }

        public Cereal.LiveLocationData LiveLocationDEPRECATED
        {
            get => _which == WHICH.LiveLocationDEPRECATED ? (Cereal.LiveLocationData)_content : null;
            set
            {
                _which = WHICH.LiveLocationDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.EthernetPacket> EthernetDataDEPRECATED
        {
            get => _which == WHICH.EthernetDataDEPRECATED ? (IReadOnlyList<Cereal.EthernetPacket>)_content : null;
            set
            {
                _which = WHICH.EthernetDataDEPRECATED;
                _content = value;
            }
        }

        public Cereal.NavUpdate NavUpdateDEPRECATED
        {
            get => _which == WHICH.NavUpdateDEPRECATED ? (Cereal.NavUpdate)_content : null;
            set
            {
                _which = WHICH.NavUpdateDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.CellInfo> CellInfoDEPRECATED
        {
            get => _which == WHICH.CellInfoDEPRECATED ? (IReadOnlyList<Cereal.CellInfo>)_content : null;
            set
            {
                _which = WHICH.CellInfoDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.WifiScan> WifiScanDEPRECATED
        {
            get => _which == WHICH.WifiScanDEPRECATED ? (IReadOnlyList<Cereal.WifiScan>)_content : null;
            set
            {
                _which = WHICH.WifiScanDEPRECATED;
                _content = value;
            }
        }

        public Cereal.AndroidGnss AndroidGnssDEPRECATED
        {
            get => _which == WHICH.AndroidGnssDEPRECATED ? (Cereal.AndroidGnss)_content : null;
            set
            {
                _which = WHICH.AndroidGnssDEPRECATED;
                _content = value;
            }
        }

        public Cereal.QcomGnss QcomGnssDEPRECATD
        {
            get => _which == WHICH.QcomGnssDEPRECATD ? (Cereal.QcomGnss)_content : null;
            set
            {
                _which = WHICH.QcomGnssDEPRECATD;
                _content = value;
            }
        }

        public Cereal.LidarPts LidarPtsDEPRECATED
        {
            get => _which == WHICH.LidarPtsDEPRECATED ? (Cereal.LidarPts)_content : null;
            set
            {
                _which = WHICH.LidarPtsDEPRECATED;
                _content = value;
            }
        }

        public Cereal.ProcLog ProcLog
        {
            get => _which == WHICH.ProcLog ? (Cereal.ProcLog)_content : null;
            set
            {
                _which = WHICH.ProcLog;
                _content = value;
            }
        }

        public Cereal.UbloxGnss UbloxGnss
        {
            get => _which == WHICH.UbloxGnss ? (Cereal.UbloxGnss)_content : null;
            set
            {
                _which = WHICH.UbloxGnss;
                _content = value;
            }
        }

        public Cereal.Clocks Clocks
        {
            get => _which == WHICH.Clocks ? (Cereal.Clocks)_content : null;
            set
            {
                _which = WHICH.Clocks;
                _content = value;
            }
        }

        public Cereal.LiveMpcData LiveMpcDEPRECATED
        {
            get => _which == WHICH.LiveMpcDEPRECATED ? (Cereal.LiveMpcData)_content : null;
            set
            {
                _which = WHICH.LiveMpcDEPRECATED;
                _content = value;
            }
        }

        public Cereal.LiveLongitudinalMpcData LiveLongitudinalMpcDEPRECATED
        {
            get => _which == WHICH.LiveLongitudinalMpcDEPRECATED ? (Cereal.LiveLongitudinalMpcData)_content : null;
            set
            {
                _which = WHICH.LiveLongitudinalMpcDEPRECATED;
                _content = value;
            }
        }

        public Cereal.NavStatus NavStatusDEPRECATED
        {
            get => _which == WHICH.NavStatusDEPRECATED ? (Cereal.NavStatus)_content : null;
            set
            {
                _which = WHICH.NavStatusDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<byte> UbloxRaw
        {
            get => _which == WHICH.UbloxRaw ? (IReadOnlyList<byte>)_content : null;
            set
            {
                _which = WHICH.UbloxRaw;
                _content = value;
            }
        }

        public Cereal.GPSPlannerPoints GpsPlannerPointsDEPRECATED
        {
            get => _which == WHICH.GpsPlannerPointsDEPRECATED ? (Cereal.GPSPlannerPoints)_content : null;
            set
            {
                _which = WHICH.GpsPlannerPointsDEPRECATED;
                _content = value;
            }
        }

        public Cereal.GPSPlannerPlan GpsPlannerPlanDEPRECATED
        {
            get => _which == WHICH.GpsPlannerPlanDEPRECATED ? (Cereal.GPSPlannerPlan)_content : null;
            set
            {
                _which = WHICH.GpsPlannerPlanDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<byte> ApplanixRawDEPRECATED
        {
            get => _which == WHICH.ApplanixRawDEPRECATED ? (IReadOnlyList<byte>)_content : null;
            set
            {
                _which = WHICH.ApplanixRawDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.TrafficEvent> TrafficEventsDEPRECATED
        {
            get => _which == WHICH.TrafficEventsDEPRECATED ? (IReadOnlyList<Cereal.TrafficEvent>)_content : null;
            set
            {
                _which = WHICH.TrafficEventsDEPRECATED;
                _content = value;
            }
        }

        public Cereal.LiveLocationData LiveLocationTimingDEPRECATED
        {
            get => _which == WHICH.LiveLocationTimingDEPRECATED ? (Cereal.LiveLocationData)_content : null;
            set
            {
                _which = WHICH.LiveLocationTimingDEPRECATED;
                _content = value;
            }
        }

        public Cereal.OrbslamCorrection OrbslamCorrectionDEPRECATED
        {
            get => _which == WHICH.OrbslamCorrectionDEPRECATED ? (Cereal.OrbslamCorrection)_content : null;
            set
            {
                _which = WHICH.OrbslamCorrectionDEPRECATED;
                _content = value;
            }
        }

        public Cereal.LiveLocationData LiveLocationCorrectedDEPRECATED
        {
            get => _which == WHICH.LiveLocationCorrectedDEPRECATED ? (Cereal.LiveLocationData)_content : null;
            set
            {
                _which = WHICH.LiveLocationCorrectedDEPRECATED;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.OrbObservation> OrbObservationDEPRECATED
        {
            get => _which == WHICH.OrbObservationDEPRECATED ? (IReadOnlyList<Cereal.OrbObservation>)_content : null;
            set
            {
                _which = WHICH.OrbObservationDEPRECATED;
                _content = value;
            }
        }

        public Cereal.GpsLocationData GpsLocationExternal
        {
            get => _which == WHICH.GpsLocationExternal ? (Cereal.GpsLocationData)_content : null;
            set
            {
                _which = WHICH.GpsLocationExternal;
                _content = value;
            }
        }

        public Cereal.LiveLocationData LocationDEPRECATED
        {
            get => _which == WHICH.LocationDEPRECATED ? (Cereal.LiveLocationData)_content : null;
            set
            {
                _which = WHICH.LocationDEPRECATED;
                _content = value;
            }
        }

        public Cereal.UiNavigationEvent UiNavigationEventDEPRECATED
        {
            get => _which == WHICH.UiNavigationEventDEPRECATED ? (Cereal.UiNavigationEvent)_content : null;
            set
            {
                _which = WHICH.UiNavigationEventDEPRECATED;
                _content = value;
            }
        }

        public Cereal.LiveLocationData LiveLocationKalmanDEPRECATED
        {
            get => _which == WHICH.LiveLocationKalmanDEPRECATED ? (Cereal.LiveLocationData)_content : null;
            set
            {
                _which = WHICH.LiveLocationKalmanDEPRECATED;
                _content = value;
            }
        }

        public Cereal.Joystick TestJoystick
        {
            get => _which == WHICH.TestJoystick ? (Cereal.Joystick)_content : null;
            set
            {
                _which = WHICH.TestJoystick;
                _content = value;
            }
        }

        public Cereal.OrbOdometry OrbOdometryDEPRECATED
        {
            get => _which == WHICH.OrbOdometryDEPRECATED ? (Cereal.OrbOdometry)_content : null;
            set
            {
                _which = WHICH.OrbOdometryDEPRECATED;
                _content = value;
            }
        }

        public Cereal.OrbFeatures OrbFeaturesDEPRECATED
        {
            get => _which == WHICH.OrbFeaturesDEPRECATED ? (Cereal.OrbFeatures)_content : null;
            set
            {
                _which = WHICH.OrbFeaturesDEPRECATED;
                _content = value;
            }
        }

        public Cereal.LiveLocationData ApplanixLocationDEPRECATED
        {
            get => _which == WHICH.ApplanixLocationDEPRECATED ? (Cereal.LiveLocationData)_content : null;
            set
            {
                _which = WHICH.ApplanixLocationDEPRECATED;
                _content = value;
            }
        }

        public Cereal.OrbKeyFrame OrbKeyFrameDEPRECATED
        {
            get => _which == WHICH.OrbKeyFrameDEPRECATED ? (Cereal.OrbKeyFrame)_content : null;
            set
            {
                _which = WHICH.OrbKeyFrameDEPRECATED;
                _content = value;
            }
        }

        public Cereal.UiLayoutState UiLayoutStateDEPRECATED
        {
            get => _which == WHICH.UiLayoutStateDEPRECATED ? (Cereal.UiLayoutState)_content : null;
            set
            {
                _which = WHICH.UiLayoutStateDEPRECATED;
                _content = value;
            }
        }

        public Cereal.OrbFeaturesSummary OrbFeaturesSummaryDEPRECATED
        {
            get => _which == WHICH.OrbFeaturesSummaryDEPRECATED ? (Cereal.OrbFeaturesSummary)_content : null;
            set
            {
                _which = WHICH.OrbFeaturesSummaryDEPRECATED;
                _content = value;
            }
        }

        public Cereal.DriverState DriverState
        {
            get => _which == WHICH.DriverState ? (Cereal.DriverState)_content : null;
            set
            {
                _which = WHICH.DriverState;
                _content = value;
            }
        }

        public Cereal.Boot Boot
        {
            get => _which == WHICH.Boot ? (Cereal.Boot)_content : null;
            set
            {
                _which = WHICH.Boot;
                _content = value;
            }
        }

        public Cereal.LiveParametersData LiveParameters
        {
            get => _which == WHICH.LiveParameters ? (Cereal.LiveParametersData)_content : null;
            set
            {
                _which = WHICH.LiveParameters;
                _content = value;
            }
        }

        public Cereal.LiveMapDataDEPRECATED LiveMapDataDEPRECATED
        {
            get => _which == WHICH.LiveMapDataDEPRECATED ? (Cereal.LiveMapDataDEPRECATED)_content : null;
            set
            {
                _which = WHICH.LiveMapDataDEPRECATED;
                _content = value;
            }
        }

        public Cereal.CameraOdometry CameraOdometry
        {
            get => _which == WHICH.CameraOdometry ? (Cereal.CameraOdometry)_content : null;
            set
            {
                _which = WHICH.CameraOdometry;
                _content = value;
            }
        }

        public Cereal.LateralPlan LateralPlan
        {
            get => _which == WHICH.LateralPlan ? (Cereal.LateralPlan)_content : null;
            set
            {
                _which = WHICH.LateralPlan;
                _content = value;
            }
        }

        public Cereal.KalmanOdometry KalmanOdometryDEPRECATED
        {
            get => _which == WHICH.KalmanOdometryDEPRECATED ? (Cereal.KalmanOdometry)_content : null;
            set
            {
                _which = WHICH.KalmanOdometryDEPRECATED;
                _content = value;
            }
        }

        public Cereal.Thumbnail Thumbnail
        {
            get => _which == WHICH.Thumbnail ? (Cereal.Thumbnail)_content : null;
            set
            {
                _which = WHICH.Thumbnail;
                _content = value;
            }
        }

        public bool Valid
        {
            get;
            set;
        }

        = true;
        public IReadOnlyList<Cereal.CarEvent> CarEvents
        {
            get => _which == WHICH.CarEvents ? (IReadOnlyList<Cereal.CarEvent>)_content : null;
            set
            {
                _which = WHICH.CarEvents;
                _content = value;
            }
        }

        public Cereal.CarParams CarParams
        {
            get => _which == WHICH.CarParams ? (Cereal.CarParams)_content : null;
            set
            {
                _which = WHICH.CarParams;
                _content = value;
            }
        }

        public Cereal.FrameData DriverCameraState
        {
            get => _which == WHICH.DriverCameraState ? (Cereal.FrameData)_content : null;
            set
            {
                _which = WHICH.DriverCameraState;
                _content = value;
            }
        }

        public Cereal.DriverMonitoringState DriverMonitoringState
        {
            get => _which == WHICH.DriverMonitoringState ? (Cereal.DriverMonitoringState)_content : null;
            set
            {
                _which = WHICH.DriverMonitoringState;
                _content = value;
            }
        }

        public Cereal.LiveLocationKalman LiveLocationKalman
        {
            get => _which == WHICH.LiveLocationKalman ? (Cereal.LiveLocationKalman)_content : null;
            set
            {
                _which = WHICH.LiveLocationKalman;
                _content = value;
            }
        }

        public Cereal.Sentinel Sentinel
        {
            get => _which == WHICH.Sentinel ? (Cereal.Sentinel)_content : null;
            set
            {
                _which = WHICH.Sentinel;
                _content = value;
            }
        }

        public Cereal.FrameData WideRoadCameraState
        {
            get => _which == WHICH.WideRoadCameraState ? (Cereal.FrameData)_content : null;
            set
            {
                _which = WHICH.WideRoadCameraState;
                _content = value;
            }
        }

        public Cereal.ModelDataV2 ModelV2
        {
            get => _which == WHICH.ModelV2 ? (Cereal.ModelDataV2)_content : null;
            set
            {
                _which = WHICH.ModelV2;
                _content = value;
            }
        }

        public Cereal.EncodeIndex DriverEncodeIdx
        {
            get => _which == WHICH.DriverEncodeIdx ? (Cereal.EncodeIndex)_content : null;
            set
            {
                _which = WHICH.DriverEncodeIdx;
                _content = value;
            }
        }

        public Cereal.EncodeIndex WideRoadEncodeIdx
        {
            get => _which == WHICH.WideRoadEncodeIdx ? (Cereal.EncodeIndex)_content : null;
            set
            {
                _which = WHICH.WideRoadEncodeIdx;
                _content = value;
            }
        }

        public Cereal.ManagerState ManagerState
        {
            get => _which == WHICH.ManagerState ? (Cereal.ManagerState)_content : null;
            set
            {
                _which = WHICH.ManagerState;
                _content = value;
            }
        }

        public Cereal.UploaderState UploaderState
        {
            get => _which == WHICH.UploaderState ? (Cereal.UploaderState)_content : null;
            set
            {
                _which = WHICH.UploaderState;
                _content = value;
            }
        }

        public Cereal.PeripheralState PeripheralState
        {
            get => _which == WHICH.PeripheralState ? (Cereal.PeripheralState)_content : null;
            set
            {
                _which = WHICH.PeripheralState;
                _content = value;
            }
        }

        public IReadOnlyList<Cereal.PandaState> PandaStates
        {
            get => _which == WHICH.PandaStates ? (IReadOnlyList<Cereal.PandaState>)_content : null;
            set
            {
                _which = WHICH.PandaStates;
                _content = value;
            }
        }

        public Cereal.NavInstruction NavInstruction
        {
            get => _which == WHICH.NavInstruction ? (Cereal.NavInstruction)_content : null;
            set
            {
                _which = WHICH.NavInstruction;
                _content = value;
            }
        }

        public Cereal.NavRoute NavRoute
        {
            get => _which == WHICH.NavRoute ? (Cereal.NavRoute)_content : null;
            set
            {
                _which = WHICH.NavRoute;
                _content = value;
            }
        }

        public Cereal.Thumbnail NavThumbnail
        {
            get => _which == WHICH.NavThumbnail ? (Cereal.Thumbnail)_content : null;
            set
            {
                _which = WHICH.NavThumbnail;
                _content = value;
            }
        }

        public string ErrorLogMessage
        {
            get => _which == WHICH.ErrorLogMessage ? (string)_content : null;
            set
            {
                _which = WHICH.ErrorLogMessage;
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
            public ulong LogMonoTime => ctx.ReadDataULong(0UL, 0UL);
            public Cereal.InitData.READER InitData => which == WHICH.InitData ? ctx.ReadStruct(0, Cereal.InitData.READER.create) : default;
            public Cereal.FrameData.READER RoadCameraState => which == WHICH.RoadCameraState ? ctx.ReadStruct(0, Cereal.FrameData.READER.create) : default;
            public Cereal.GPSNMEAData.READER GpsNMEA => which == WHICH.GpsNMEA ? ctx.ReadStruct(0, Cereal.GPSNMEAData.READER.create) : default;
            public Cereal.SensorEventData.READER SensorEventDEPRECATED => which == WHICH.SensorEventDEPRECATED ? ctx.ReadStruct(0, Cereal.SensorEventData.READER.create) : default;
            public IReadOnlyList<Cereal.CanData.READER> Can => which == WHICH.Can ? ctx.ReadList(0).Cast(Cereal.CanData.READER.create) : default;
            public Cereal.DeviceState.READER DeviceState => which == WHICH.DeviceState ? ctx.ReadStruct(0, Cereal.DeviceState.READER.create) : default;
            public Cereal.ControlsState.READER ControlsState => which == WHICH.ControlsState ? ctx.ReadStruct(0, Cereal.ControlsState.READER.create) : default;
            public IReadOnlyList<Cereal.LiveEventData.READER> LiveEventDEPRECATED => which == WHICH.LiveEventDEPRECATED ? ctx.ReadList(0).Cast(Cereal.LiveEventData.READER.create) : default;
            public Cereal.ModelData.READER Model => which == WHICH.Model ? ctx.ReadStruct(0, Cereal.ModelData.READER.create) : default;
            public Cereal.CalibrationFeatures.READER FeaturesDEPRECATED => which == WHICH.FeaturesDEPRECATED ? ctx.ReadStruct(0, Cereal.CalibrationFeatures.READER.create) : default;
            public IReadOnlyList<Cereal.SensorEventData.READER> SensorEvents => which == WHICH.SensorEvents ? ctx.ReadList(0).Cast(Cereal.SensorEventData.READER.create) : default;
            public Cereal.PandaState.READER PandaStateDEPRECATED => which == WHICH.PandaStateDEPRECATED ? ctx.ReadStruct(0, Cereal.PandaState.READER.create) : default;
            public Cereal.RadarState.READER RadarState => which == WHICH.RadarState ? ctx.ReadStruct(0, Cereal.RadarState.READER.create) : default;
            public Cereal.LiveUI.READER LiveUIDEPRECATED => which == WHICH.LiveUIDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveUI.READER.create) : default;
            public Cereal.EncodeIndex.READER RoadEncodeIdx => which == WHICH.RoadEncodeIdx ? ctx.ReadStruct(0, Cereal.EncodeIndex.READER.create) : default;
            public IReadOnlyList<Cereal.LiveTracks.READER> LiveTracks => which == WHICH.LiveTracks ? ctx.ReadList(0).Cast(Cereal.LiveTracks.READER.create) : default;
            public IReadOnlyList<Cereal.CanData.READER> Sendcan => which == WHICH.Sendcan ? ctx.ReadList(0).Cast(Cereal.CanData.READER.create) : default;
            public string LogMessage => which == WHICH.LogMessage ? ctx.ReadText(0, null) : default;
            public Cereal.LiveCalibrationData.READER LiveCalibration => which == WHICH.LiveCalibration ? ctx.ReadStruct(0, Cereal.LiveCalibrationData.READER.create) : default;
            public Cereal.AndroidLogEntry.READER AndroidLog => which == WHICH.AndroidLog ? ctx.ReadStruct(0, Cereal.AndroidLogEntry.READER.create) : default;
            public Cereal.GpsLocationData.READER GpsLocationDEPRECATED => which == WHICH.GpsLocationDEPRECATED ? ctx.ReadStruct(0, Cereal.GpsLocationData.READER.create) : default;
            public Cereal.CarState.READER CarState => which == WHICH.CarState ? ctx.ReadStruct(0, Cereal.CarState.READER.create) : default;
            public Cereal.CarControl.READER CarControl => which == WHICH.CarControl ? ctx.ReadStruct(0, Cereal.CarControl.READER.create) : default;
            public Cereal.LongitudinalPlan.READER LongitudinalPlan => which == WHICH.LongitudinalPlan ? ctx.ReadStruct(0, Cereal.LongitudinalPlan.READER.create) : default;
            public Cereal.LiveLocationData.READER LiveLocationDEPRECATED => which == WHICH.LiveLocationDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveLocationData.READER.create) : default;
            public IReadOnlyList<Cereal.EthernetPacket.READER> EthernetDataDEPRECATED => which == WHICH.EthernetDataDEPRECATED ? ctx.ReadList(0).Cast(Cereal.EthernetPacket.READER.create) : default;
            public Cereal.NavUpdate.READER NavUpdateDEPRECATED => which == WHICH.NavUpdateDEPRECATED ? ctx.ReadStruct(0, Cereal.NavUpdate.READER.create) : default;
            public IReadOnlyList<Cereal.CellInfo.READER> CellInfoDEPRECATED => which == WHICH.CellInfoDEPRECATED ? ctx.ReadList(0).Cast(Cereal.CellInfo.READER.create) : default;
            public IReadOnlyList<Cereal.WifiScan.READER> WifiScanDEPRECATED => which == WHICH.WifiScanDEPRECATED ? ctx.ReadList(0).Cast(Cereal.WifiScan.READER.create) : default;
            public Cereal.AndroidGnss.READER AndroidGnssDEPRECATED => which == WHICH.AndroidGnssDEPRECATED ? ctx.ReadStruct(0, Cereal.AndroidGnss.READER.create) : default;
            public Cereal.QcomGnss.READER QcomGnssDEPRECATD => which == WHICH.QcomGnssDEPRECATD ? ctx.ReadStruct(0, Cereal.QcomGnss.READER.create) : default;
            public Cereal.LidarPts.READER LidarPtsDEPRECATED => which == WHICH.LidarPtsDEPRECATED ? ctx.ReadStruct(0, Cereal.LidarPts.READER.create) : default;
            public Cereal.ProcLog.READER ProcLog => which == WHICH.ProcLog ? ctx.ReadStruct(0, Cereal.ProcLog.READER.create) : default;
            public Cereal.UbloxGnss.READER UbloxGnss => which == WHICH.UbloxGnss ? ctx.ReadStruct(0, Cereal.UbloxGnss.READER.create) : default;
            public Cereal.Clocks.READER Clocks => which == WHICH.Clocks ? ctx.ReadStruct(0, Cereal.Clocks.READER.create) : default;
            public Cereal.LiveMpcData.READER LiveMpcDEPRECATED => which == WHICH.LiveMpcDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveMpcData.READER.create) : default;
            public Cereal.LiveLongitudinalMpcData.READER LiveLongitudinalMpcDEPRECATED => which == WHICH.LiveLongitudinalMpcDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveLongitudinalMpcData.READER.create) : default;
            public Cereal.NavStatus.READER NavStatusDEPRECATED => which == WHICH.NavStatusDEPRECATED ? ctx.ReadStruct(0, Cereal.NavStatus.READER.create) : default;
            public IReadOnlyList<byte> UbloxRaw => which == WHICH.UbloxRaw ? ctx.ReadList(0).CastByte() : default;
            public Cereal.GPSPlannerPoints.READER GpsPlannerPointsDEPRECATED => which == WHICH.GpsPlannerPointsDEPRECATED ? ctx.ReadStruct(0, Cereal.GPSPlannerPoints.READER.create) : default;
            public Cereal.GPSPlannerPlan.READER GpsPlannerPlanDEPRECATED => which == WHICH.GpsPlannerPlanDEPRECATED ? ctx.ReadStruct(0, Cereal.GPSPlannerPlan.READER.create) : default;
            public IReadOnlyList<byte> ApplanixRawDEPRECATED => which == WHICH.ApplanixRawDEPRECATED ? ctx.ReadList(0).CastByte() : default;
            public IReadOnlyList<Cereal.TrafficEvent.READER> TrafficEventsDEPRECATED => which == WHICH.TrafficEventsDEPRECATED ? ctx.ReadList(0).Cast(Cereal.TrafficEvent.READER.create) : default;
            public Cereal.LiveLocationData.READER LiveLocationTimingDEPRECATED => which == WHICH.LiveLocationTimingDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveLocationData.READER.create) : default;
            public Cereal.OrbslamCorrection.READER OrbslamCorrectionDEPRECATED => which == WHICH.OrbslamCorrectionDEPRECATED ? ctx.ReadStruct(0, Cereal.OrbslamCorrection.READER.create) : default;
            public Cereal.LiveLocationData.READER LiveLocationCorrectedDEPRECATED => which == WHICH.LiveLocationCorrectedDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveLocationData.READER.create) : default;
            public IReadOnlyList<Cereal.OrbObservation.READER> OrbObservationDEPRECATED => which == WHICH.OrbObservationDEPRECATED ? ctx.ReadList(0).Cast(Cereal.OrbObservation.READER.create) : default;
            public Cereal.GpsLocationData.READER GpsLocationExternal => which == WHICH.GpsLocationExternal ? ctx.ReadStruct(0, Cereal.GpsLocationData.READER.create) : default;
            public Cereal.LiveLocationData.READER LocationDEPRECATED => which == WHICH.LocationDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveLocationData.READER.create) : default;
            public Cereal.UiNavigationEvent.READER UiNavigationEventDEPRECATED => which == WHICH.UiNavigationEventDEPRECATED ? ctx.ReadStruct(0, Cereal.UiNavigationEvent.READER.create) : default;
            public Cereal.LiveLocationData.READER LiveLocationKalmanDEPRECATED => which == WHICH.LiveLocationKalmanDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveLocationData.READER.create) : default;
            public Cereal.Joystick.READER TestJoystick => which == WHICH.TestJoystick ? ctx.ReadStruct(0, Cereal.Joystick.READER.create) : default;
            public Cereal.OrbOdometry.READER OrbOdometryDEPRECATED => which == WHICH.OrbOdometryDEPRECATED ? ctx.ReadStruct(0, Cereal.OrbOdometry.READER.create) : default;
            public Cereal.OrbFeatures.READER OrbFeaturesDEPRECATED => which == WHICH.OrbFeaturesDEPRECATED ? ctx.ReadStruct(0, Cereal.OrbFeatures.READER.create) : default;
            public Cereal.LiveLocationData.READER ApplanixLocationDEPRECATED => which == WHICH.ApplanixLocationDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveLocationData.READER.create) : default;
            public Cereal.OrbKeyFrame.READER OrbKeyFrameDEPRECATED => which == WHICH.OrbKeyFrameDEPRECATED ? ctx.ReadStruct(0, Cereal.OrbKeyFrame.READER.create) : default;
            public Cereal.UiLayoutState.READER UiLayoutStateDEPRECATED => which == WHICH.UiLayoutStateDEPRECATED ? ctx.ReadStruct(0, Cereal.UiLayoutState.READER.create) : default;
            public Cereal.OrbFeaturesSummary.READER OrbFeaturesSummaryDEPRECATED => which == WHICH.OrbFeaturesSummaryDEPRECATED ? ctx.ReadStruct(0, Cereal.OrbFeaturesSummary.READER.create) : default;
            public Cereal.DriverState.READER DriverState => which == WHICH.DriverState ? ctx.ReadStruct(0, Cereal.DriverState.READER.create) : default;
            public Cereal.Boot.READER Boot => which == WHICH.Boot ? ctx.ReadStruct(0, Cereal.Boot.READER.create) : default;
            public Cereal.LiveParametersData.READER LiveParameters => which == WHICH.LiveParameters ? ctx.ReadStruct(0, Cereal.LiveParametersData.READER.create) : default;
            public Cereal.LiveMapDataDEPRECATED.READER LiveMapDataDEPRECATED => which == WHICH.LiveMapDataDEPRECATED ? ctx.ReadStruct(0, Cereal.LiveMapDataDEPRECATED.READER.create) : default;
            public Cereal.CameraOdometry.READER CameraOdometry => which == WHICH.CameraOdometry ? ctx.ReadStruct(0, Cereal.CameraOdometry.READER.create) : default;
            public Cereal.LateralPlan.READER LateralPlan => which == WHICH.LateralPlan ? ctx.ReadStruct(0, Cereal.LateralPlan.READER.create) : default;
            public Cereal.KalmanOdometry.READER KalmanOdometryDEPRECATED => which == WHICH.KalmanOdometryDEPRECATED ? ctx.ReadStruct(0, Cereal.KalmanOdometry.READER.create) : default;
            public Cereal.Thumbnail.READER Thumbnail => which == WHICH.Thumbnail ? ctx.ReadStruct(0, Cereal.Thumbnail.READER.create) : default;
            public bool Valid => ctx.ReadDataBool(80UL, true);
            public IReadOnlyList<Cereal.CarEvent.READER> CarEvents => which == WHICH.CarEvents ? ctx.ReadList(0).Cast(Cereal.CarEvent.READER.create) : default;
            public Cereal.CarParams.READER CarParams => which == WHICH.CarParams ? ctx.ReadStruct(0, Cereal.CarParams.READER.create) : default;
            public Cereal.FrameData.READER DriverCameraState => which == WHICH.DriverCameraState ? ctx.ReadStruct(0, Cereal.FrameData.READER.create) : default;
            public Cereal.DriverMonitoringState.READER DriverMonitoringState => which == WHICH.DriverMonitoringState ? ctx.ReadStruct(0, Cereal.DriverMonitoringState.READER.create) : default;
            public Cereal.LiveLocationKalman.READER LiveLocationKalman => which == WHICH.LiveLocationKalman ? ctx.ReadStruct(0, Cereal.LiveLocationKalman.READER.create) : default;
            public Cereal.Sentinel.READER Sentinel => which == WHICH.Sentinel ? ctx.ReadStruct(0, Cereal.Sentinel.READER.create) : default;
            public Cereal.FrameData.READER WideRoadCameraState => which == WHICH.WideRoadCameraState ? ctx.ReadStruct(0, Cereal.FrameData.READER.create) : default;
            public Cereal.ModelDataV2.READER ModelV2 => which == WHICH.ModelV2 ? ctx.ReadStruct(0, Cereal.ModelDataV2.READER.create) : default;
            public Cereal.EncodeIndex.READER DriverEncodeIdx => which == WHICH.DriverEncodeIdx ? ctx.ReadStruct(0, Cereal.EncodeIndex.READER.create) : default;
            public Cereal.EncodeIndex.READER WideRoadEncodeIdx => which == WHICH.WideRoadEncodeIdx ? ctx.ReadStruct(0, Cereal.EncodeIndex.READER.create) : default;
            public Cereal.ManagerState.READER ManagerState => which == WHICH.ManagerState ? ctx.ReadStruct(0, Cereal.ManagerState.READER.create) : default;
            public Cereal.UploaderState.READER UploaderState => which == WHICH.UploaderState ? ctx.ReadStruct(0, Cereal.UploaderState.READER.create) : default;
            public Cereal.PeripheralState.READER PeripheralState => which == WHICH.PeripheralState ? ctx.ReadStruct(0, Cereal.PeripheralState.READER.create) : default;
            public IReadOnlyList<Cereal.PandaState.READER> PandaStates => which == WHICH.PandaStates ? ctx.ReadList(0).Cast(Cereal.PandaState.READER.create) : default;
            public Cereal.NavInstruction.READER NavInstruction => which == WHICH.NavInstruction ? ctx.ReadStruct(0, Cereal.NavInstruction.READER.create) : default;
            public Cereal.NavRoute.READER NavRoute => which == WHICH.NavRoute ? ctx.ReadStruct(0, Cereal.NavRoute.READER.create) : default;
            public Cereal.Thumbnail.READER NavThumbnail => which == WHICH.NavThumbnail ? ctx.ReadStruct(0, Cereal.Thumbnail.READER.create) : default;
            public string ErrorLogMessage => which == WHICH.ErrorLogMessage ? ctx.ReadText(0, null) : default;
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

            public ulong LogMonoTime
            {
                get => this.ReadDataULong(0UL, 0UL);
                set => this.WriteData(0UL, value, 0UL);
            }

            public Cereal.InitData.WRITER InitData
            {
                get => which == WHICH.InitData ? BuildPointer<Cereal.InitData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.FrameData.WRITER RoadCameraState
            {
                get => which == WHICH.RoadCameraState ? BuildPointer<Cereal.FrameData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.GPSNMEAData.WRITER GpsNMEA
            {
                get => which == WHICH.GpsNMEA ? BuildPointer<Cereal.GPSNMEAData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.SensorEventData.WRITER SensorEventDEPRECATED
            {
                get => which == WHICH.SensorEventDEPRECATED ? BuildPointer<Cereal.SensorEventData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.CanData.WRITER> Can
            {
                get => which == WHICH.Can ? BuildPointer<ListOfStructsSerializer<Cereal.CanData.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.DeviceState.WRITER DeviceState
            {
                get => which == WHICH.DeviceState ? BuildPointer<Cereal.DeviceState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.ControlsState.WRITER ControlsState
            {
                get => which == WHICH.ControlsState ? BuildPointer<Cereal.ControlsState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.LiveEventData.WRITER> LiveEventDEPRECATED
            {
                get => which == WHICH.LiveEventDEPRECATED ? BuildPointer<ListOfStructsSerializer<Cereal.LiveEventData.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.ModelData.WRITER Model
            {
                get => which == WHICH.Model ? BuildPointer<Cereal.ModelData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.CalibrationFeatures.WRITER FeaturesDEPRECATED
            {
                get => which == WHICH.FeaturesDEPRECATED ? BuildPointer<Cereal.CalibrationFeatures.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.SensorEventData.WRITER> SensorEvents
            {
                get => which == WHICH.SensorEvents ? BuildPointer<ListOfStructsSerializer<Cereal.SensorEventData.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.PandaState.WRITER PandaStateDEPRECATED
            {
                get => which == WHICH.PandaStateDEPRECATED ? BuildPointer<Cereal.PandaState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.RadarState.WRITER RadarState
            {
                get => which == WHICH.RadarState ? BuildPointer<Cereal.RadarState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveUI.WRITER LiveUIDEPRECATED
            {
                get => which == WHICH.LiveUIDEPRECATED ? BuildPointer<Cereal.LiveUI.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.EncodeIndex.WRITER RoadEncodeIdx
            {
                get => which == WHICH.RoadEncodeIdx ? BuildPointer<Cereal.EncodeIndex.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.LiveTracks.WRITER> LiveTracks
            {
                get => which == WHICH.LiveTracks ? BuildPointer<ListOfStructsSerializer<Cereal.LiveTracks.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.CanData.WRITER> Sendcan
            {
                get => which == WHICH.Sendcan ? BuildPointer<ListOfStructsSerializer<Cereal.CanData.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public string LogMessage
            {
                get => which == WHICH.LogMessage ? this.ReadText(0, null) : default;
                set => this.WriteText(0, value, null);
            }

            public Cereal.LiveCalibrationData.WRITER LiveCalibration
            {
                get => which == WHICH.LiveCalibration ? BuildPointer<Cereal.LiveCalibrationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.AndroidLogEntry.WRITER AndroidLog
            {
                get => which == WHICH.AndroidLog ? BuildPointer<Cereal.AndroidLogEntry.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.GpsLocationData.WRITER GpsLocationDEPRECATED
            {
                get => which == WHICH.GpsLocationDEPRECATED ? BuildPointer<Cereal.GpsLocationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.CarState.WRITER CarState
            {
                get => which == WHICH.CarState ? BuildPointer<Cereal.CarState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.CarControl.WRITER CarControl
            {
                get => which == WHICH.CarControl ? BuildPointer<Cereal.CarControl.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LongitudinalPlan.WRITER LongitudinalPlan
            {
                get => which == WHICH.LongitudinalPlan ? BuildPointer<Cereal.LongitudinalPlan.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveLocationData.WRITER LiveLocationDEPRECATED
            {
                get => which == WHICH.LiveLocationDEPRECATED ? BuildPointer<Cereal.LiveLocationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.EthernetPacket.WRITER> EthernetDataDEPRECATED
            {
                get => which == WHICH.EthernetDataDEPRECATED ? BuildPointer<ListOfStructsSerializer<Cereal.EthernetPacket.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.NavUpdate.WRITER NavUpdateDEPRECATED
            {
                get => which == WHICH.NavUpdateDEPRECATED ? BuildPointer<Cereal.NavUpdate.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.CellInfo.WRITER> CellInfoDEPRECATED
            {
                get => which == WHICH.CellInfoDEPRECATED ? BuildPointer<ListOfStructsSerializer<Cereal.CellInfo.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.WifiScan.WRITER> WifiScanDEPRECATED
            {
                get => which == WHICH.WifiScanDEPRECATED ? BuildPointer<ListOfStructsSerializer<Cereal.WifiScan.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.AndroidGnss.WRITER AndroidGnssDEPRECATED
            {
                get => which == WHICH.AndroidGnssDEPRECATED ? BuildPointer<Cereal.AndroidGnss.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.QcomGnss.WRITER QcomGnssDEPRECATD
            {
                get => which == WHICH.QcomGnssDEPRECATD ? BuildPointer<Cereal.QcomGnss.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LidarPts.WRITER LidarPtsDEPRECATED
            {
                get => which == WHICH.LidarPtsDEPRECATED ? BuildPointer<Cereal.LidarPts.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.ProcLog.WRITER ProcLog
            {
                get => which == WHICH.ProcLog ? BuildPointer<Cereal.ProcLog.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.UbloxGnss.WRITER UbloxGnss
            {
                get => which == WHICH.UbloxGnss ? BuildPointer<Cereal.UbloxGnss.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.Clocks.WRITER Clocks
            {
                get => which == WHICH.Clocks ? BuildPointer<Cereal.Clocks.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveMpcData.WRITER LiveMpcDEPRECATED
            {
                get => which == WHICH.LiveMpcDEPRECATED ? BuildPointer<Cereal.LiveMpcData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveLongitudinalMpcData.WRITER LiveLongitudinalMpcDEPRECATED
            {
                get => which == WHICH.LiveLongitudinalMpcDEPRECATED ? BuildPointer<Cereal.LiveLongitudinalMpcData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.NavStatus.WRITER NavStatusDEPRECATED
            {
                get => which == WHICH.NavStatusDEPRECATED ? BuildPointer<Cereal.NavStatus.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<byte> UbloxRaw
            {
                get => which == WHICH.UbloxRaw ? BuildPointer<ListOfPrimitivesSerializer<byte>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.GPSPlannerPoints.WRITER GpsPlannerPointsDEPRECATED
            {
                get => which == WHICH.GpsPlannerPointsDEPRECATED ? BuildPointer<Cereal.GPSPlannerPoints.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.GPSPlannerPlan.WRITER GpsPlannerPlanDEPRECATED
            {
                get => which == WHICH.GpsPlannerPlanDEPRECATED ? BuildPointer<Cereal.GPSPlannerPlan.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfPrimitivesSerializer<byte> ApplanixRawDEPRECATED
            {
                get => which == WHICH.ApplanixRawDEPRECATED ? BuildPointer<ListOfPrimitivesSerializer<byte>>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.TrafficEvent.WRITER> TrafficEventsDEPRECATED
            {
                get => which == WHICH.TrafficEventsDEPRECATED ? BuildPointer<ListOfStructsSerializer<Cereal.TrafficEvent.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveLocationData.WRITER LiveLocationTimingDEPRECATED
            {
                get => which == WHICH.LiveLocationTimingDEPRECATED ? BuildPointer<Cereal.LiveLocationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.OrbslamCorrection.WRITER OrbslamCorrectionDEPRECATED
            {
                get => which == WHICH.OrbslamCorrectionDEPRECATED ? BuildPointer<Cereal.OrbslamCorrection.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveLocationData.WRITER LiveLocationCorrectedDEPRECATED
            {
                get => which == WHICH.LiveLocationCorrectedDEPRECATED ? BuildPointer<Cereal.LiveLocationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.OrbObservation.WRITER> OrbObservationDEPRECATED
            {
                get => which == WHICH.OrbObservationDEPRECATED ? BuildPointer<ListOfStructsSerializer<Cereal.OrbObservation.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.GpsLocationData.WRITER GpsLocationExternal
            {
                get => which == WHICH.GpsLocationExternal ? BuildPointer<Cereal.GpsLocationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveLocationData.WRITER LocationDEPRECATED
            {
                get => which == WHICH.LocationDEPRECATED ? BuildPointer<Cereal.LiveLocationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.UiNavigationEvent.WRITER UiNavigationEventDEPRECATED
            {
                get => which == WHICH.UiNavigationEventDEPRECATED ? BuildPointer<Cereal.UiNavigationEvent.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveLocationData.WRITER LiveLocationKalmanDEPRECATED
            {
                get => which == WHICH.LiveLocationKalmanDEPRECATED ? BuildPointer<Cereal.LiveLocationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.Joystick.WRITER TestJoystick
            {
                get => which == WHICH.TestJoystick ? BuildPointer<Cereal.Joystick.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.OrbOdometry.WRITER OrbOdometryDEPRECATED
            {
                get => which == WHICH.OrbOdometryDEPRECATED ? BuildPointer<Cereal.OrbOdometry.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.OrbFeatures.WRITER OrbFeaturesDEPRECATED
            {
                get => which == WHICH.OrbFeaturesDEPRECATED ? BuildPointer<Cereal.OrbFeatures.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveLocationData.WRITER ApplanixLocationDEPRECATED
            {
                get => which == WHICH.ApplanixLocationDEPRECATED ? BuildPointer<Cereal.LiveLocationData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.OrbKeyFrame.WRITER OrbKeyFrameDEPRECATED
            {
                get => which == WHICH.OrbKeyFrameDEPRECATED ? BuildPointer<Cereal.OrbKeyFrame.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.UiLayoutState.WRITER UiLayoutStateDEPRECATED
            {
                get => which == WHICH.UiLayoutStateDEPRECATED ? BuildPointer<Cereal.UiLayoutState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.OrbFeaturesSummary.WRITER OrbFeaturesSummaryDEPRECATED
            {
                get => which == WHICH.OrbFeaturesSummaryDEPRECATED ? BuildPointer<Cereal.OrbFeaturesSummary.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.DriverState.WRITER DriverState
            {
                get => which == WHICH.DriverState ? BuildPointer<Cereal.DriverState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.Boot.WRITER Boot
            {
                get => which == WHICH.Boot ? BuildPointer<Cereal.Boot.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveParametersData.WRITER LiveParameters
            {
                get => which == WHICH.LiveParameters ? BuildPointer<Cereal.LiveParametersData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveMapDataDEPRECATED.WRITER LiveMapDataDEPRECATED
            {
                get => which == WHICH.LiveMapDataDEPRECATED ? BuildPointer<Cereal.LiveMapDataDEPRECATED.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.CameraOdometry.WRITER CameraOdometry
            {
                get => which == WHICH.CameraOdometry ? BuildPointer<Cereal.CameraOdometry.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LateralPlan.WRITER LateralPlan
            {
                get => which == WHICH.LateralPlan ? BuildPointer<Cereal.LateralPlan.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.KalmanOdometry.WRITER KalmanOdometryDEPRECATED
            {
                get => which == WHICH.KalmanOdometryDEPRECATED ? BuildPointer<Cereal.KalmanOdometry.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.Thumbnail.WRITER Thumbnail
            {
                get => which == WHICH.Thumbnail ? BuildPointer<Cereal.Thumbnail.WRITER>(0) : default;
                set => Link(0, value);
            }

            public bool Valid
            {
                get => this.ReadDataBool(80UL, true);
                set => this.WriteData(80UL, value, true);
            }

            public ListOfStructsSerializer<Cereal.CarEvent.WRITER> CarEvents
            {
                get => which == WHICH.CarEvents ? BuildPointer<ListOfStructsSerializer<Cereal.CarEvent.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.CarParams.WRITER CarParams
            {
                get => which == WHICH.CarParams ? BuildPointer<Cereal.CarParams.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.FrameData.WRITER DriverCameraState
            {
                get => which == WHICH.DriverCameraState ? BuildPointer<Cereal.FrameData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.DriverMonitoringState.WRITER DriverMonitoringState
            {
                get => which == WHICH.DriverMonitoringState ? BuildPointer<Cereal.DriverMonitoringState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.LiveLocationKalman.WRITER LiveLocationKalman
            {
                get => which == WHICH.LiveLocationKalman ? BuildPointer<Cereal.LiveLocationKalman.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.Sentinel.WRITER Sentinel
            {
                get => which == WHICH.Sentinel ? BuildPointer<Cereal.Sentinel.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.FrameData.WRITER WideRoadCameraState
            {
                get => which == WHICH.WideRoadCameraState ? BuildPointer<Cereal.FrameData.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.ModelDataV2.WRITER ModelV2
            {
                get => which == WHICH.ModelV2 ? BuildPointer<Cereal.ModelDataV2.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.EncodeIndex.WRITER DriverEncodeIdx
            {
                get => which == WHICH.DriverEncodeIdx ? BuildPointer<Cereal.EncodeIndex.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.EncodeIndex.WRITER WideRoadEncodeIdx
            {
                get => which == WHICH.WideRoadEncodeIdx ? BuildPointer<Cereal.EncodeIndex.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.ManagerState.WRITER ManagerState
            {
                get => which == WHICH.ManagerState ? BuildPointer<Cereal.ManagerState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.UploaderState.WRITER UploaderState
            {
                get => which == WHICH.UploaderState ? BuildPointer<Cereal.UploaderState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.PeripheralState.WRITER PeripheralState
            {
                get => which == WHICH.PeripheralState ? BuildPointer<Cereal.PeripheralState.WRITER>(0) : default;
                set => Link(0, value);
            }

            public ListOfStructsSerializer<Cereal.PandaState.WRITER> PandaStates
            {
                get => which == WHICH.PandaStates ? BuildPointer<ListOfStructsSerializer<Cereal.PandaState.WRITER>>(0) : default;
                set => Link(0, value);
            }

            public Cereal.NavInstruction.WRITER NavInstruction
            {
                get => which == WHICH.NavInstruction ? BuildPointer<Cereal.NavInstruction.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.NavRoute.WRITER NavRoute
            {
                get => which == WHICH.NavRoute ? BuildPointer<Cereal.NavRoute.WRITER>(0) : default;
                set => Link(0, value);
            }

            public Cereal.Thumbnail.WRITER NavThumbnail
            {
                get => which == WHICH.NavThumbnail ? BuildPointer<Cereal.Thumbnail.WRITER>(0) : default;
                set => Link(0, value);
            }

            public string ErrorLogMessage
            {
                get => which == WHICH.ErrorLogMessage ? this.ReadText(0, null) : default;
                set => this.WriteText(0, value, null);
            }
        }
    }
}