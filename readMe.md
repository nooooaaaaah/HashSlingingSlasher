# HashSlingingSlasher

HashSlingingSlasher is a password hashing library for .NET Core applications. It provides methods for generating and verifying password hashes using the SHA256 algorithm.

## Installation

To use HashSlingingSlasher in your .NET Core application, you can add the following package reference to your project file:

```xml
<PackageReference Include="HashSlingingSlasher" Version="1.0.0" />
```

## Usage

To use HashSlingingSlasher in your application, you can create an instance of the `PasswordHasher` class and call its methods:

```csharp
using HashSlingingSlasher;

// Generate a password hash and salt
byte[] passwordHash, passwordSalt;
PasswordHasher.CreatePasswordHash("password123", out passwordHash, out passwordSalt);

// Verify a password hash and salt
bool isValid = PasswordHasher.VerifyPasswordHash("password123", passwordHash, passwordSalt);
```

## Features

HashSlingingSlasher provides the following features:

- Generate a random salt of a specified length
- Create a password hash and salt from a plaintext password
- Verify a password hash and salt against a plaintext password

## Contributing

Contributions to HashSlingingSlasher are welcome! To contribute, please follow these steps:

1. Fork the repository
2. Create a new branch for your feature or bug fix
3. Write tests for your changes
4. Implement your changes
5. Run the tests and ensure they pass
6. Submit a pull request

## License

HashSlingingSlasher is released under the MIT License. See [LICENSE](LICENSE) for details.

This README file includes information on how to install and use the library, as well as a list of its features and instructions for contributing to the project. It also includes licensing information. You can customize this template to fit your project's specific needs.
