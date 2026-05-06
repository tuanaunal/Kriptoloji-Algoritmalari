# Cryptography Algorithms and Secure Messaging Application
This project is a comprehensive desktop application developed in C# that implements various classical and modern symmetric encryption algorithms. The application focuses on manual implementation of cryptographic logic using modular arithmetic and matrix transformations, specifically optimized for the 29-character Turkish alphabet.

### Core Features
Manual Algorithm Logic: All cryptographic methods, including Hill and Four-Square, are implemented from scratch using matrix manipulation and custom loops without external libraries.
Turkish Alphabet Integration: Specialized support for the 29-character Turkish alphabet (including Ç, Ğ, İ, Ö, Ş, Ü), ensuring accurate modular calculations and character mapping.
Integrated Secure Messaging: Built-in SMTP configuration using System.Net.Mail to transmit encrypted payloads directly to recipients via email.
Data Sanitization: Automated input cleaning to ensure compatibility with the defined cryptographic alphabet and prevent indexing errors.

### Implemented Algorithms
Substitution Ciphers:
Atbash Cipher: Fixed substitution mapping the alphabet to its reverse.
Shift (Caesar) Cipher: Basic substitution based on modular addition.
Affine (Linear) Cipher: Advanced substitution using linear functions $(ax + b) \pmod{29}$.
Vigenere Cipher: Polyalphabetic substitution using keyword-based shifting.
Transposition Ciphers:
Zigzag (Rail Fence): Character rearrangement based on rail patterns.
Permutation: Block-based character position swapping.
Route (Reverse): Geometric transposition by reversing the string.
Matrix-Based Ciphers:
Hill Cipher: Matrix-based encryption using $2 \times 2$ linear transformations and modular inverse matrices.
Four-Square Cipher: Polygraphic substitution using specialized $5 \times 6$ matrix grids.

### Technical Specifications
Language: C# (.NET Framework)
Architecture: Windows Forms (WinForms)
Network: SMTP protocol for secure transmission.
Database: None (All operations are performed in-memory for real-time processing).

### Setup and Installation
Clone the repository and open the .sln file in Visual Studio.
Ensure all UI components in Form1.Designer.cs are correctly linked to the event handlers.
Build the solution and run the application (F5).
Select an algorithm, enter the required key (numeric or text), and perform encryption or decryption.
