// using BenchmarkDotNet.Attributes;
// using Benchmarks.Serializers.Json.Models;
// using Benchmarks.Serializers.Json.Services;
//
// namespace Benchmarks.Serializers.Json.Benchmarks.Deserialization.Simple;
//
// /// <summary>
// ///     Deserialization from stream.
// /// </summary>
// public class AsyncStreamDeserializationSimpleBenchmarks: JsonSimpleBenchmark
// {
//     private Stream _testMsgPackClassicStream = null!;
//     private Stream _testZeroFormatterStream = null!;
//     private Stream _testServiceStackStream = null!;
//     private Stream _testMsgPackLz4Stream = null!;
//     private Stream _protobufStream = null!;
//     private Stream _testStream = null!;
//
//     /// <summary>
//     ///     Override of setup.
//     /// </summary>
//     [GlobalSetup]
//     public new void Setup()
//     {
//         base.Setup();
//
//         _testMsgPackClassicStream = new MemoryStream(MsgPackService.ClassicSerializeBytes(SimpleModels));
//         _testZeroFormatterStream = new MemoryStream(ZeroFormatterService.SerializeBytes(SimpleModels));
//         _testMsgPackLz4Stream = new MemoryStream(MsgPackService.Lz4BlockSerializeBytes(SimpleModels));
//         _testStream = new MemoryStream(SystemTextJsonService.SerializeBytes(SimpleModels));
//         _protobufStream = new MemoryStream(ProtobufService.SerializeBytes(SimpleModels));
//
//         using var tempStream = ServiceStackService.SerializeStream(SimpleModels);
//         _testServiceStackStream = new MemoryStream(tempStream.ToArray());
//     }
//     
//     /// <summary>
//     ///     Deserialize with System.Text.Json.
//     /// </summary>
//     [Benchmark(Baseline = true)]
//     public ValueTask<ICollection<SimpleModel>?> SystemTextJson()
//     {
//         return SystemTextJsonService.DeserializeAsync<ICollection<SimpleModel>>(_testStream);
//     }
//
//     /// <summary>
//     ///     Deserialize with System.Text.Json source gen.
//     /// </summary>
//     [Benchmark]
//     public ValueTask<ICollection<SimpleModel>?> SystemTextJsonSourceGen()
//     {
//         return SystemTextJsonGeneratedService.SimpleDeserializeArrayAsync(_testStream);
//     }
//
//     /// <summary>
//     ///     Deserialize with Utf8Json.
//     /// </summary>
//     [Benchmark]
//     public Task<ICollection<SimpleModel>> Utf8Json()
//     {
//         return Utf8JsonService.DeserializeStreamAsync<ICollection<SimpleModel>>(_testStream);
//     }
//
//     /// <summary>
//     ///     Deserialize with SpanJson.
//     /// </summary>
//     [Benchmark]
//     public ValueTask<ICollection<SimpleModel>> SpanJson()
//     {
//         return SpanJsonService.DeserializeStreamAsync<ICollection<SimpleModel>>(_testStream);
//     }
//
//     /// <summary>
//     ///     Deserialize with Protobuf.
//     /// </summary>
//     [Benchmark]
//     public ValueTask<ICollection<SimpleModel>> Protobuf()
//     {
//         return ProtobufService.DeserializeStreamAsync<ICollection<SimpleModel>>(_protobufStream);
//     }
//     
//     /// <summary>
//     ///     Deserialize with MsgPackClassic.
//     /// </summary>
//     [Benchmark]
//     public ValueTask<ICollection<SimpleModel>> MsgPackClassic()
//     {
//         return MsgPackService.ClassicDeserializeAsync<ICollection<SimpleModel>>(_testMsgPackClassicStream);
//     }
//     
//     /// <summary>
//     ///     Deserialize with MsgPackLz4.
//     /// </summary>
//     [Benchmark]
//     public ValueTask<ICollection<SimpleModel>> MsgPackLz4()
//     {
//         return MsgPackService.Lz4BlockDeserializeAsync<ICollection<SimpleModel>>(_testMsgPackLz4Stream);
//     }
//     
//     /// <summary>
//     ///     Deserialize with ServiceStack.
//     /// </summary>
//     [Benchmark]
//     public Task<ICollection<SimpleModel>> ServiceStack()
//     {
//         return ServiceStackService.DeserializeStreamAsync<ICollection<SimpleModel>>(_testServiceStackStream);
//     }
//     
//     /// <summary>
//     ///     Closing streams.
//     /// </summary>
//     [GlobalCleanup]
//     public void Cleanup()
//     {
//         _testStream.Close();
//         _testStream.Dispose();
//
//         _testMsgPackClassicStream.Close();
//         _testMsgPackClassicStream.Dispose();
//        
//         _testZeroFormatterStream.Close();
//         _testZeroFormatterStream.Dispose();
//         
//         _testServiceStackStream.Close();
//         _testServiceStackStream.Dispose();
//         
//         _testMsgPackLz4Stream.Close();
//         _testMsgPackLz4Stream.Dispose();
//         
//         _protobufStream.Close();
//         _protobufStream.Dispose();
//     }
// }