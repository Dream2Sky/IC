var express = require('express');
var router = express.Router();

/**
 * 云通信基础能力业务短信发送、查询详情以及消费消息示例，供参考。
 * Created on 2017-07-31
 */
const SMSClient = require('@alicloud/sms-sdk')
// ACCESS_KEY_ID/ACCESS_KEY_SECRET 根据实际申请的账号信息进行替换
const accessKeyId = 'LTAInfJSYXbjKCJC'
const secretAccessKey = 'fA45ZrGIUPFSIhRSf8pyUKk8b7hutt'

/* GET users listing. */
router.get('/', function(req, res, next) {
    let phone = req.query.phone;
    let code = req.query.code;
    sendsms(phone,code);
});

var sendsms = function(phone, code) {
    //初始化sms_client
    let smsClient = new SMSClient({ accessKeyId, secretAccessKey })

    //发送短信
    smsClient.sendSMS({
        PhoneNumbers: phone + '',
        SignName: '新众联',
        TemplateCode: 'SMS_126270031',
        TemplateParam: '{"code":"' + code + '"}'
    }).then(function(res) {
        let { Code } = res
        if (Code === 'OK') {
            //处理返回参数
            res.send(res);
        }
    }, function(err) {
        res.send(err);
    })

}

module.exports = router;