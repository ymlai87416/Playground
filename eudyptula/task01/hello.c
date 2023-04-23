#include <linux/init.h>
#include <linux/module.h>

MODULE_LICENSE("Dual BSD/GPL");
MODULE_AUTHOR("ymlai87416");
//MODULE_DESCRITION("Eudyptula challenge task 1");

static int hello_init(void){
    printk(KERN_ALERT "Hello World!\n");
    return 0;
}

static void hello_exit(void){
    printk(KERN_ALERT "Bye~\n");
}

module_init(hello_init);
module_exit(hello_exit);