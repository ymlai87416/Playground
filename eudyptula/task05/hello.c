#include <linux/module.h>
#include <linux/hid.h>
#include <linux/kernel.h>
#include <linux/usb.h>

#define DRIVER_DESC "Eudyptula challenge 5"



static int hello_probe(struct usb_interface *iface,
			const struct usb_device_id *id)
{
	pr_alert("USB keyboard detected\n");
	return 0;
}

static void hello_disconnect(struct usb_interface *interface)
{
	pr_alert("USB keyboard disconnected\n");
}

static const struct usb_device_id usb_kbd_id_table[] = {
	{ USB_INTERFACE_INFO(USB_INTERFACE_CLASS_HID, USB_INTERFACE_SUBCLASS_BOOT,
		USB_INTERFACE_PROTOCOL_KEYBOARD) },
	{ }						/* Terminating entry */
};

MODULE_DEVICE_TABLE (usb, usb_kbd_id_table);

static struct usb_driver hello_usb_kbd_driver = {
	.name =		"hellousbkb",
	.probe =	hello_probe,
	.disconnect =	hello_disconnect,
	.id_table =	usb_kbd_id_table,
};

static int __init hello_init(void)
{
	//If you trace module_usb_driver, you find a macro to create this function
	printk(KERN_ALERT "Hello World!\n");
	return usb_register(&hello_usb_kbd_driver);
}

static void __exit hello_exit(void)
{
    printk(KERN_ALERT "Bye~\n");
    usb_deregister(&hello_usb_kbd_driver);
}

//module_usb_driver(usb_kbd_driver) 

module_init(hello_init);
module_exit(hello_exit);

MODULE_AUTHOR("ymlai87416");
MODULE_DESCRIPTION(DRIVER_DESC);
MODULE_LICENSE("Dual BSD/GPL");