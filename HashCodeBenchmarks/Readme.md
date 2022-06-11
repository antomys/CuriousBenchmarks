[See mini article on StackOverflow](https://stackoverflow.com/a/56539595)

# What Makes a Good Algorithm?
## Performance
The algorithm that calculates a hash code needs to be fast. A simple algorithm is usually going to be a faster one. One that does not allocate extra memory will also reduce need for garbage collection, which will in turn also improve performance.

In C# hash functions specifically, you often use the `unchecked` keyword which stops overflow checking to improve performance.

## Deterministic
The hashing algorithm needs to be [deterministic](https://en.wikipedia.org/wiki/Deterministic_algorithm) i.e. given the same input it must always produce the same output.

## Reduce Collisions
The algorithm that calculates a hash code needs to keep [hash collisions](https://freemanlaw.com/hash-collisions-explained/) to a minimum. A hash collision is a situation that occurs when two calls to GetHashCode on two different objects produce identical hash codes. Note that collisions are allowed (some have the misconceptions that they are not) but they should be kept to a minimum.

A lot of hash functions contain magic numbers like `17` or `23`. These are special [prime numbers](https://en.wikipedia.org/wiki/Prime_number) which due to their mathematical properties help to reduce hash collisions as compared to using non-prime numbers.

## Hash Uniformity
A good hash function should map the expected inputs as evenly as possible over its output range i.e. it should output a wide range of hashes based on its inputs that are evenly spread. It should have hash uniformity.

## Prevents DoS
In .NET Core each time you restart an application you will get different hash codes. This is a security feature to prevent Denial of Service attacks (DoS). For .NET Framework you **should** enable this feature by adding the following App.config file:

    <?xml version ="1.0"?>  
    <configuration>  
       <runtime>  
          <UseRandomizedStringHashAlgorithm enabled="1" />  
       </runtime>  
    </configuration>

Because of this feature, hash codes should never be used outside of the application domain in which they were created, they should never be used as key fields in a collection and they should never be persisted.

Read more about this [here](https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/).

# Cryptographically Secure?
The algorithm does not have to be a [Cryptographic hash function](https://en.wikipedia.org/wiki/Cryptographic_hash_function). Meaning it does not have to satisfy the following conditions:

- It is infeasible to generate a message that yields a given hash value.
- It is infeasible to find two different messages with the same hash value.
- A small change to a message should change the hash value so extensively that the new hash value appears uncorrelated with the old hash value (avalanche effect).

# Results

|                 Method |       Mean |     Error |    StdDev |    StdErr |     Median |        Min |        Max |         Q1 |         Q3 |            Op/s | Ratio | RatioSD | Rank | Allocated |
|----------------------- |-----------:|----------:|----------:|----------:|-----------:|-----------:|-----------:|-----------:|-----------:|----------------:|------:|--------:|-----:|----------:|
|     GetHashCodeDefault |  0.3368 ns | 0.0531 ns | 0.1073 ns | 0.0152 ns |  0.3292 ns |  0.0276 ns |  0.5682 ns |  0.2736 ns |  0.3902 ns | 2,969,551,471.1 |  1.00 |    0.00 |    1 |         - |
|          GetHashCodeV5 | 11.4119 ns | 0.1414 ns | 0.1104 ns | 0.0319 ns | 11.3830 ns | 11.2832 ns | 11.6369 ns | 11.3424 ns | 11.4741 ns |    87,627,588.2 | 28.23 |    6.78 |    2 |         - |
|          GetHashCodeV3 | 12.7635 ns | 0.3789 ns | 1.0993 ns | 0.1116 ns | 12.5827 ns | 10.9953 ns | 15.5410 ns | 11.8319 ns | 13.5011 ns |    78,348,480.7 | 50.43 |   72.51 |    3 |         - |
|          GetHashCodeV6 | 13.2869 ns | 0.6168 ns | 1.7397 ns | 0.1814 ns | 12.8632 ns | 11.1475 ns | 18.5678 ns | 11.8863 ns | 14.1070 ns |    75,261,954.2 | 52.27 |   62.77 |    3 |         - |
| GetHashCodeHashCombine | 14.1596 ns | 0.1356 ns | 0.1268 ns | 0.0327 ns | 14.1472 ns | 13.9283 ns | 14.3521 ns | 14.0877 ns | 14.2767 ns |    70,623,529.6 | 36.56 |    9.36 |    4 |         - |
|          GetHashCodeV4 | 20.7986 ns | 0.7887 ns | 2.3006 ns | 0.2324 ns | 20.1041 ns | 17.5693 ns | 26.8629 ns | 18.8799 ns | 22.0289 ns |    48,080,082.8 | 83.73 |  114.67 |    5 |         - |

## Conclusion : 

Do not make your head blow and use default `GetHashCode` method :).