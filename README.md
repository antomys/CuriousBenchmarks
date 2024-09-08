# Curious benchmarks

Updated : 4/10/2024 (10.04.2024)

[![.NET CI](https://github.com/nogic1008/dotnet-ci-example/actions/workflows/dotnet-ci.yml/badge.svg)](https://github.com/antomys/CuriousBenchmarks/actions/workflows/ci.yml)
[![License](https://img.shields.io/github/license/nogic1008/dotnet-ci-example)](LICENSE)

Here are collected some benchmarks for different approaches of solving problems. I've decided to do this to select most suitable and fast solutions and research of different approaches.

Have fun!

### Table of content
- [Enum boxing-unboxing benchmarks](src/main/Benchmarks.Enum/Readme.md)
  - [Benchmarks](src/main/Benchmarks.Enum/Readme.md#benchmarks)
      - [Getting value as string from Enum](src/main/Benchmarks.Enum/Readme.md#getting-name-or-value-of-enum)
      - [Getting name of Enum](src/main/Benchmarks.Enum/Readme.md#getting-name-of-enum)
- [Comparison Length check methods of collections](src/main/Benchmarks.CollectionSize/Readme.md)
  - [Benchmarks](src/main/Benchmarks.CollectionSize/Readme.md#benchmarks)
    - [Getting Size by '.Count'](src/main/Benchmarks.CollectionSize/Readme.md#getting-size-by-count)
    - [Getting Size by '.Any()' method](src/main/Benchmarks.CollectionSize/Readme.md#getting-size-by-any-method)
- [Comparing GroupBy/Distinct/DistinctBy for getting unique items](src/main/Benchmarks.GroupByVsDistinct/Readme.md)
  - [Benchmarks](src/main/Benchmarks.GroupByVsDistinct/Readme.md#benchmarks)
- [Comparing different iterators (for,foreach, linq, ref foreach, etc.)](src/main/Benchmarks.Iterators/Readme.md)
- [Comparing different string link formatting, dashing for dash view, concatenating and generating unique string](src/main/Benchmarks.String/Readme.md)
- [Json Serialization/Deserialization](src/main/Benchmarks.Serializers.Json/Readme.md)
  - [Benchmarks](src/main/Benchmarks.Serializers.Json/Readme.md#benchmarks)
    - [Serialization](src/main/Benchmarks.Serializers.Json/Readme.md#json-serialization)
    - [Deserialization](src/main/Benchmarks.Serializers.Json/Readme.md#json-deserialization)
- [Binary Serialization/Deserialization](src/main/Benchmarks.Serializers.Binary/Readme.md)
  - [Benchmarks](src/main/Benchmarks.Serializers.Binary/Readme.md#benchmarks)
    - [Serialization](src/main/Benchmarks.Serializers.Binary/Readme.md#binary-serialization)
    - [Deserialization](src/main/Benchmarks.Serializers.Binary/Readme.md#binary-deserialization)
- [Sort array of T by ids from string array](src/main/Benchmarks.SortArrayByArray/readme.md)
- [WIP][String Manipulations](src/main/Benchmarks.String/Readme.md)
- [WIP] [URL Concat and Query building](src/main/Benchmarks.QueryBuilder/readme.md)
  - [WIP] [URL Concatenation](src/main/Benchmarks.QueryBuilder/readme.md#url-concatenation)
  - [WIP] [Query Building](src/main/Benchmarks.QueryBuilder/readme.md#query-building-approaches)

## Disclaimer

To see benchmark, just proceed to folder which benchmarks you would like to see. Or click on links above
