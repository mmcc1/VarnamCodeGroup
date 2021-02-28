# Vernam CodeGroup

An implementation of the Vernam Cipher.  This implementation also provides an encoder/decoder for text-based transfers.

The Vernam cipher is secure if, and only if, the following conditions are all met:

* There are only two copies of the key,
* Both sides of the communications link have the same key,
*The key is used only once,
*The key is destroyed immediately after use,
*The key contains truly random characters,
*The equipment is TEMPEST proof,
*The key was not compromised during transport.

More on the theory:
https://www.cryptomuseum.com/crypto/vernam.htm
