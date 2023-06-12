const express = require("express");

const cors  = require("cors");

const dataa = [
   {name : "abc1",
   age  : 25
  },
  {name : "abc2",
   age  : 26
  },
  {name : "abc3",
   age  : 20
  },
  {name : "abc4",
   age  : 30
  }
]

const  app = express();

app.use(cors());

app.use(express.urlencoded({extended:false}));
app.use(express.json());

app.get('/api/demo',(req,res)=>{
  res.json({data:dataa});
   console.log("working");
})

app.post('/api/add',(req,res)=>{
     dataa.push({"name":req.body.name,"age":req.body.age})
     console.log(dataa);
     res.json({data:dataa});
})


app.listen(3000,()=>console.log('server run at port 3000'))