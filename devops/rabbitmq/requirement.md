RabbitMQ 

version: 4.x

max cpu usage: 80%
max ram usage: 80%
max disk usage: 80%

max users: 20 					(default: undefined)
max message size: 8 MB				(default: 128 MB)
max virtual hosts: 10 				(default: undefined)

max connections per user: 1K			(default: undefined)
max channels per connection: 100		(default: undefined)
max channels per user: 5K			(default: undefined)
max queues per virtual host: 200		(default: undefined)
max connections per virtual host: 1K		(default: undefined)

log level: warning				(default: info)

watermark: 80% 					(default: 60% in 4.x, 40% in 3.x)

alert warning cpu usage: 60%
alert warning ram usage: 60%
alert warning disk usage: 60%

alert error cpu usage: 70%
alert error ram usage: 70%
alert error disk usage: 70%
