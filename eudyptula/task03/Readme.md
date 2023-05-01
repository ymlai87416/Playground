## Run the patch

Useful website:
- https://git-send-email.io/
- https://docs.kernel.org/process/submitting-patches.html
- https://open.mymy.tw/index-traitshow.html?id=109
- https://linuxconfig.org/configuring-gmail-as-sendmail-email-relay

```sh
git show
git log -1
git send-email --to="ymlai87416@gmail.com" HEAD^
```


## Setup sendmail

- install sendmail and mailx
- Get a set of Google app password