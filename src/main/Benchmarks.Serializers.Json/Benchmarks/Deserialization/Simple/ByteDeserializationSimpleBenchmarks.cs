// using BenchmarkDotNet.Attributes;
// using Json.Models;
// using Json.Models.SrcGen;
// using Json.Services;
//
// namespace Json.Benchmarks.Serializers.Simple;
//
// /// <summary>
// ///     Serializers from string as byte array benchmarks.
// /// </summary>
// public class ByteDeserializationSimpleBenchmarks: JsonSimpleBenchmark
// {
//     private byte[] _testByteArray = default!;
//     private byte[] _testMsgPackClassicByteArray = default!;
//     private byte[] _testMsgPackLz4ByteArray = default!;
//     private byte[] _testJilByteArray = default!;
//     private byte[] _zeroFormatterByteArray = default!;
//     private byte[] _protobufBytes = default!;
//
//     /// <summary>
//     ///     Override of global setup.
//     /// </summary>
//     [GlobalSetup]
//     public new void Setup()
//     {
//         base.Setup();
//
//         _testMsgPackClassicByteArray = MsgPackService.ClassicSerializeBytes(SimpleModels);
//         _zeroFormatterByteArray = ZeroFormatterService.SerializeBytes(SimpleModels);
//         _testMsgPackLz4ByteArray = MsgPackService.Lz4BlockSerializeBytes(SimpleModels);
//         _testByteArray = SystemTextJsonService.SerializeBytes(SimpleModels);
//         _protobufBytes = ProtobufService.SerializeBytes(SimpleModels);
//         _testJilByteArray = JilService.SerializeBytes(SimpleModels);
//     }
//     
//     /// <summary>
//     ///     Deserialize with System.Text.Json.
//     /// </summary>
//     [Benchmark(Baseline = true)]
//     public ICollection<SimpleModel> SystemTextJson()
//     {
//         return SystemTextJsonService.DeserializeBytes<ICollection<SimpleModel>>(_testByteArray);
//     }
//
//     /// <summary>
//     ///     Deserialize with System.Text.Json source gen.
//     /// </summary>
//     [Benchmark]
//     public ICollection<SimpleModel> SystemTextJsonSourceGen()
//     {
//         return SystemTextJsonGeneratedService.SimpleDeserializeBytesArray(_testByteArray);
//     }
//
//     /// <summary>
//     ///     Deserialize with Utf8Json.
//     /// </summary>
//     [Benchmark]
//     public ICollection<SimpleModel> Utf8Json()
//     {
//         return Utf8JsonService.DeserializeBytes<ICollection<SimpleModel>>(_testByteArray);
//     }
//     
//     /// <summary>
//     ///     Deserialize with SpanJson.
//     /// </summary>
//     [Benchmark]
//     public ICollection<SimpleModel> SpanJson()
//     {
//         return SpanJsonService.DeserializeBytes<ICollection<SimpleModel>>(_testByteArray);
//     }
//     
//     /// <summary>
//     ///     Deserialize with Jil.
//     /// </summary>
//     [Benchmark]
//     public ICollection<SimpleModel> Jil()
//     {
//         return JilService.DeserializeBytes<ICollection<SimpleModel>>(_testJilByteArray);
//     }
//     
//     /// <summary>
//     ///     Deserialize with ZeroFormatter.
//     /// </summary>
//     [Benchmark]
//     public ICollection<SimpleModel> ZeroFormatter()
//     {
//         return ZeroFormatterService.DeserializeBytes<ICollection<SimpleModel>>(_zeroFormatterByteArray);
//     }
//     
//     /// <summary>
//     ///     Deserialize with Protobuf.
//     /// </summary>
//     [Benchmark]
//     public ICollection<SimpleModel> Protobuf()
//     {
//         return ProtobufService.DeserializeBytes<ICollection<SimpleModel>>(_protobufBytes);
//     }
//     
//     /// <summary>
//     ///     Deserialize with MsgPack.
//     /// </summary>
//     [Benchmark]
//     public ICollection<SimpleModel> MsgPackClassic()
//     {
//         return MsgPackService.ClassicDeserializeBytes<ICollection<SimpleModel>>(_testMsgPackClassicByteArray);
//     }
//     
//     /// <summary>
//     ///     Deserialize with MsgPack.
//     /// </summary>
//     [Benchmark]
//     public ICollection<SimpleModel> MsgPackLz4()
//     {
//         return MsgPackService.Lz4BlockDeserializeBytes<ICollection<SimpleModel>>(_testMsgPackLz4ByteArray);
//     }
//     
//     /// <summary>
//     ///     Deserialize with ServiceStack.
//     /// </summary>
//     [Benchmark]
//     public ComplexSrcGenModel[] JsonSrcGen()
//     {
//         return JsonSrcGenService.ComplexDeserializeBytesArray(_testByteArray);
//     }
// }

