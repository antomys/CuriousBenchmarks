// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;

namespace Benchmarks.QueryBuilder.Services.Query;

// The IEnumerable interface is required for the collection initialization syntax: new QueryBuilder() { { "key", "value" } };
public sealed class QueryValueStringBuilder : IEnumerable<KeyValuePair<string, string>>
{
    private readonly IList<KeyValuePair<string, string>> _params;

    public QueryValueStringBuilder()
    {
        _params = new List<KeyValuePair<string, string>>();
    }

    public QueryValueStringBuilder(IEnumerable<KeyValuePair<string, string>> parameters)
    {
        _params = new List<KeyValuePair<string, string>>(parameters);
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return _params.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _params.GetEnumerator();
    }

    public void Add(string key, IEnumerable<string> values)
    {
        foreach (var value in values) _params.Add(new KeyValuePair<string, string>(key, value));
    }

    public void Add(string key, string value)
    {
        _params.Add(new KeyValuePair<string, string>(key, value));
    }

    public override string ToString()
    {
        var builder = new ValueStringBuilder();
        var first = true;

        for (var i = 0; i < _params.Count; i++)
        {
            var pair = _params[i];
            builder.Append(first ? "?" : "&");
            first = false;
            builder.Append(UrlEncoder.Default.Encode(pair.Key));
            builder.Append("=");
            builder.Append(UrlEncoder.Default.Encode(pair.Value));
        }

        return builder.ToString();
    }

    public QueryString ToQueryString()
    {
        return new QueryString(ToString());
    }

    public override int GetHashCode()
    {
        return ToQueryString().GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return ToQueryString().Equals(obj);
    }
}