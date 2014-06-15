# What is it?
This is .NET project which lets you use libnfc (https://code.google.com/p/libnfc/) from .NET code in OOP way.

# How to use it?
You must install libnfc on your computer and then you will be able to use this library (only Linux so far).

This is the code I used to download sources of libnfc and compile it on Raspberry PI running Arch Linux.

	wget https://libfreefare.googlecode.com/files/libfreefare-0.4.0.tar.bz2
	wget https://libnfc.googlecode.com/files/libnfc-1.7.0.tar.bz2
	tar xvjf libnfc-1.7.0.tar.bz2
	tar xvjf libfreefare-0.4.0.tar.bz2

	cd libnfc-1.7.0
	./configure --prefix=/usr
	make
	make install
	cd ..

	cd libfreefare-0.4.0
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

	On recent Linux kernel (>= 3.1) you need to prevent modprobe from autoload pn533 and nfc modules.
	To do that, create /etc/modprobe.d/blacklist-libnfc.conf with this content:
	blacklist pn533
	blacklist nfc
