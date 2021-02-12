import { Component, OnInit } from '@angular/core';
import { AuthService } from "../services/auth.service";
import { authread } from '../Types/authRead';


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  login:boolean=false;
  Username:string='';
  Password:string='';
  loginPageStat:number=0;

  constructor(private auth:AuthService) { }

  ngOnInit(): void { 
  }
Login():void{
  this.auth.login(this.Username,this.Password).subscribe((res)=>{
    if(res.response==="Cleared")
    {
      this.login=!this.login;
      this.loginPageStat=1; 

    }
    else{
      this.loginPageStat=2;
    }
  })

}

}
