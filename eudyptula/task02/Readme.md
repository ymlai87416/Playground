## Task 2

### Env

Fedora 37

### Instruction

- Linux repo is at https://git.kernel.org/pub/scm/linux/kernel/git/torvalds/linux.git


```sh
# Clone repo
git clone  git://git.kernel.org/pub/scm/linux/kernel/git/torvalds/linux.git

# Get the latest update
git pull

[tom@fedora linux]$ git rev-parse --verify HEAD
457391b0380335d5e9a5babdec90ac53928b23b4

```

- Compile it with Fedora default?

- Watch the youtube video: youtube.com/watch?v=APQY0wUbBow

```sh
make localmodconfig
make menuconfig  # I confirmed that the option is selected under General -> Automatically ....
make -j8
make modules
make modules_install
make install
grub2-mkconfig -o /boot/grub2/grub.cfg #update-grub2, seems this is an redundent step.
```


make with multi-thread support


```