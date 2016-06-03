[Libnfc .NET wrapper](https://github.com/episage/typescript-es7-boilerplate)
====================

This is .NET project which lets you use libnfc [NFC Tools](http://nfc-tools.org/index.php?title=Libnfc) from .NET (C#, F#, etc).


Requirements
---------------------

- Linux
- Mono

Installation
---------------------

In this particular case I used:

- Raspberry PI
- Arch Linux


Below is the code I use to download sources of libnfc, compile and install them.

```bash
wget https://libnfc.googlecode.com/files/libnfc-1.7.0.tar.bz2
tar xvjf libnfc-1.7.0.tar.bz2

cd libnfc-1.7.0
./configure --prefix=/usr
make
make install
cd ..

wget https://alioth.debian.org/frs/download.php/file/3991/pcsc-lite-1.8.11.tar.bz2
tar xvjf pcsc-lite-1.8.11.tar.bz2
cd pcsc-lite-1.8.11
./configure --disable-libudev --enable-libusb
make
make install
cd ..
```

On recent Linux kernel (>= 3.1) you need to prevent modprobe from autoload pn533 and nfc modules.
To do that, create `/etc/modprobe.d/blacklist-libnfc.conf` with this content:

```text
blacklist pn533
blacklist nfc
```


Usage
---------------------

Attach this project to your solution and reference it.


Contributions
---------------------

Please contribute to this project

- update libnfc and other dependencies in the bash script above
- make sure that the .NET unmanaged code is compatible with current libnfc
