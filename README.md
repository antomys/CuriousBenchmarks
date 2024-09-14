<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a id="readme-top"></a>


<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]


<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/antomys/CuriousBenchmarks">
    <img src="assets/icon.png" alt="Logo" width="175" height="175">
  </a>

<h3 align="center">Curious Benchmarks</h3>

  <p align="center">
    A repository housing targeted investigations and performance analyses of various .NET development approaches, offering developers insights into optimization techniques and architectural decisions.
    <br />
    <a href="https://github.com/antomys/CuriousBenchmarks"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/antomys/CuriousBenchmarks">View Documentation</a>
    ·
    <a href="https://github.com/antomys/CuriousBenchmarks/issues/new?labels=bug&template=bug-report---.md">Report Bug</a>
    ·
    <a href="https://github.com/antomys/CuriousBenchmarks/issues/new?labels=enhancement&template=feature-request---.md">Request Feature</a>
  </p>
</div>


<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<details>
   <summary>Benchmarks Table of Contents</summary>
   <ol>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Enum/Readme.md">Enum boxing-unboxing benchmarks</a>
         <ul>
            <li>
               <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Enum/Readme.md#benchmarks">Benchmarks</a>
               <ul>
                  <li>
                     <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Enum/Readme.md#benchmarks">Getting value as string from Enum</a>
                  </li>
                  <li>
                     <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Enum/Readme.md#benchmarks">Getting name of Enum</a>
                  </li>
               </ul>
            </li>
         </ul>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.CollectionSize/Readme.md">Comparison Length check methods of collections</a>
         <ul>
            <li>
               <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.CollectionSize/Readme.md#benchmarks">Benchmarks</a>
               <ul>
                  <li>
                     <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.CollectionSize/Readme.md#getting-size-by-count">Getting Size by '.Count'</a>
                  </li>
                  <li>
                     <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.CollectionSize/Readme.md#getting-size-by-any-method">Getting Size by '.Any()' method</a>
                  </li>
               </ul>
            </li>
         </ul>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.GroupByVsDistinct/Readme.md">Comparing GroupBy/Distinct/DistinctBy for getting unique items</a>
         <ul>
            <li>
               <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.GroupByVsDistinct/Readme.md#benchmarks">Benchmarks</a>
            </li>
         </ul>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Iterators/Readme.md">Comparing different iterators (for,foreach, linq, ref foreach, etc.)</a>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.String/Readme.md">Comparing different string link formatting, dashing for dash view, concatenating and generating unique string</a>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Serializers.Json/Readme.md">Json Serialization/Deserialization</a>
         <ul>
            <li>
               <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Serializers.Json/Readme.md#benchmarks">Benchmarks</a>
               <ul>
                  <li>
                     <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Serializers.Json/Readme.md#json-serialization">Serialization</a>
                  </li>
                  <li>
                     <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Serializers.Json/Readme.md#json-deserialization">Deserialization</a>
                  </li>
               </ul>
            </li>
         </ul>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Serializers.Binary/Readme.md">Binary Serialization/Deserialization</a>
         <ul>
            <li>
               <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Serializers.Binary/Readme.md#benchmarks">Benchmarks</a>
               <ul>
                  <li>
                     <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Serializers.Binary/Readme.md#binary-serialization">Serialization</a>
                  </li>
                  <li>
                     <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.Serializers.Binary/Readme.md#binary-deserialization">Deserialization</a>
                  </li>
               </ul>
            </li>
         </ul>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.SortArrayByArray/readme.md">Sort array of T by ids from string array</a>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.String/Readme.md">[WIP] String Manipulations</a>
      </li>
      <li>
         <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.QueryBuilder/readme.md">URL Concat and Query building</a>
         <ul>
            <li>
               <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.QueryBuilder/readme.md#url-concatenation">URL Concatenation</a>
            </li>
            <li>
               <a href="https://github.com/antomys/CuriousBenchmarks/blob/master/src/main/Benchmarks.QueryBuilder/readme.md#query-building-approaches">Query Building</a>
            </li>
         </ul>
      </li>
   </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

A curated collection of in-depth studies exploring various .NET development approaches, focusing on performance optimization and best practices. This repository houses detailed investigations into different techniques, architectural patterns, and implementation strategies within the .NET ecosystem. Each analysis aims to provide developers with valuable insights to enhance application efficiency and make informed decisions when designing .NET solutions.
<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [![.NET][.NET]][.NET]

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

Welcome to the Curious Benchmarks! This repository is designed to help you explore and understand performance characteristics of various .NET approaches. Follow these steps to get started:
### Prerequisites

- Install [.NET SDK](https://dotnet.microsoft.com/en-us/download) (version 8.0 or later)
- Install [BenchmarkDotNet](https://benchmarkdotnet.org/articles/overview.html) (**Included** in the project)


### Installation

1. **Clone the Repository**
    ```shell
   git clone https://github.com/antomys/CuriousBenchmarks.git
   cd .\src\main
   ```


2. **Build the Solution**
    ```shell
   dotnet build
   ```

3. **Run Benchmarks.** Navigate to a specific benchmark project and run:
    ```shell
   dotnet run -c Release
   ```
<p align="right">(<a href="#readme-top">back to top</a>)</p>

4. Interpret Results 
   - Benchmark results will be displayed in the console;
   - Detailed reports are generated in the `BenchmarkDotNet.Artifacts` folder.

5. Explore and Contribute 
   - Check out different benchmark projects in the repository 
   - Feel free to add your own benchmarks or improve existing ones 
   - Submit pull requests for any enhancements or new investigations


Happy benchmarking! If you have any questions or suggestions, please open an issue in the repository.


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact

Ihor Volokhovych - [@incomingwebhook](https://t.me/incomingwebhook) - igorvolokhovych@gmail.com

Project Link: [https://github.com/antomys/CuriousBenchmarks](https://github.com/antomys/CuriousBenchmarks)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [Volodymyr Lyshenko](https://github.com/vovche)
   - Volodymyr has been instrumental in expanding the scope of our performance analyses by proposing numerous innovative and insightful benchmark scenarios. His suggestions have led to the inclusion of several new benchmarks that explore previously unexamined aspects of .NET performance. 
   - Through creative input, Volodymyr has helped broaden the range of .NET approaches and techniques covered in this repository, making it a more comprehensive resource for the developer community.
* [pro.net Telegram chat](https://t.me/pro_net)
   - The members of [pro.net Telegram chat](https://t.me/pro_net) have provided thorough reviews of benchmarks, offering critical insights that have significantly improved the quality and reliability of performance analyses. 
   - Their innovative suggestions have led to the inclusion of new benchmark scenarios and the refinement of existing ones, broadening the scope and relevance of our investigations. 
   - On numerous occasions, [pro.net Telegram chat](https://t.me/pro_net) experts have shared their deep knowledge of .NET internals, helping us understand and explain complex performance behaviors observed in our benchmarks.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/antomys/CuriousBenchmarks.svg?style=for-the-badge
[contributors-url]: https://github.com/antomys/CuriousBenchmarks/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/antomys/CuriousBenchmarks.svg?style=for-the-badge
[forks-url]: https://github.com/antomys/CuriousBenchmarks/network/members
[stars-shield]: https://img.shields.io/github/stars/antomys/CuriousBenchmarks.svg?style=for-the-badge
[stars-url]: https://github.com/antomys/CuriousBenchmarks/stargazers
[issues-shield]: https://img.shields.io/github/issues/antomys/CuriousBenchmarks.svg?style=for-the-badge
[issues-url]: https://github.com/antomys/CuriousBenchmarks/issues
[license-shield]: https://img.shields.io/github/license/antomys/CuriousBenchmarks.svg?style=for-the-badge
[license-url]: https://github.com/antomys/CuriousBenchmarks/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/ihor-volokhovych-23875217a/
[.NET]: https://img.shields.io/badge/-.NET%208.0-blueviolet