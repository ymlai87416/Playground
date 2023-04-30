## Build instruction

### Env
- Fedora 37 on M1 (VM Player)


### Instruction
- To create make file, refer to this
The makefile reference the following URL:
https://fedoraproject.org/wiki/Building_a_custom_kernel

- Install kernel-devl
The kernel header is at /usr/src/kernels/6.2.11-200.fc37.aarch64
```
sudo dnf install kernel-devel-$(uname -r)
```

- Write the code
Please refer to Linux Device Driver 3rd Edition

- Load the module 

```sh
sudo insmod ./hello.ko
```

- Unload the module

```sh
sudo rmmod hello
```

- Check that the module is loaded

```sh
[tom@fedora task01]$ dmesg

[ 2275.155298] hello: version magic '6.2.11-200.fc37.aarch64 SMP preempt mod_unload aarch64' should be '6.0.7-301.fc37.aarch64 SMP preempt mod_unload aarch64'
[ 2585.244486] hello: loading out-of-tree module taints kernel.
[ 2585.244712] hello: module verification failed: signature and/or required key missing - tainting kernel
[ 2585.251905] Hello World!

====== (show after rmmod and run dmesg again) ======

[ 2728.353007] Bye~
```