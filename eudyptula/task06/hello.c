#include <linux/module.h>
#include <linux/kernel.h>
#include <linux/miscdevice.h>
#include <linux/errno.h>

#define DRIVER_DESC "Eudyptula challenge 6"
#define MY_ID "15e6bab2e86e"
#define MY_ID_LEN 13	/* ID length including the final NULL */

/*
Refer to LDD3 page 65 for detailed explanation
file: file structure
buf: Buffer address provided. (in user space)
count: size of the buffer
ppos: the offset, driver update the offset
*/
static int hello_read(struct file *file, char __user *buf,
			size_t count, loff_t *ppos)
{
	int byte_copied = 0;
	if (!access_ok(buf))
		return -EINVAL;

	size_t left_char = min(MY_ID_LEN - (*ppos), count);
	
	byte_copied = copy_to_user(buf, hello_str + (*ppos), left_char);

	if (byte_copied < 0)
		return byte_copied;

	*ppos += byte_copied;

	return byte_copied;
}


static void hello_write(struct usb_interface *interface)
{
	//TODO: implement the write function
}


static struct file_operations hello_fops = {
	.owner = 	THIS_MODULE,
	.read = 	hello_read,
	.write = 	hello_write,
};

struct miscdevice etx_misc_device = {
    .minor = MISC_DYNAMIC_MINOR,
    .name = "eudyptula",
    .fops = &fops,
};


static int __init hello_init(void)
{
	//If you trace module_usb_driver, you find a macro to create this function
	printk(KERN_ALERT "Hello World!\n");
	return misc_register(&etx_misc_device);
}

static void __exit hello_exit(void)
{
    printk(KERN_ALERT "Bye~\n");
    misc_deregister(&hello_usb_kbd_driver);
}

module_init(hello_init);
module_exit(hello_exit);

MODULE_AUTHOR("ymlai87416");
MODULE_DESCRIPTION(DRIVER_DESC);
MODULE_LICENSE("Dual BSD/GPL");