obj-m += hello.o

# KDIR  := /usr/src/kernels/6.0.7-301.fc37.aarch64
KDIR  := /home/tom/GitProject/linux

PWD   := $(shell pwd)

default:
	$(MAKE) -C $(KDIR) M=$(PWD) modules

clean:
	$(MAKE) -C $(KDIR) M=$(PWD) cleanbuild