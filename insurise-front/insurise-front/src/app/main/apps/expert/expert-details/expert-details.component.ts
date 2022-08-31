import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { title } from 'process';
import { SinisterNatureService } from '../../sinister-nature/sinister-nature.service';
import { ExpertService } from '../expert.service';
import { Chain } from '../models/Chain';
import { ExpertSpec } from '../models/ExpertSpec';
import { sinisterNature } from '../models/SinisterNature';

@Component({
  selector: 'app-expert-details',
  templateUrl: './expert-details.component.html',
  styleUrls: ['./expert-details.component.scss']
})
export class ExpertDetailsComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public expertsinisternatures:any
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public id:any
  public expertSinisterNatures = [] ;
  public expertspecialities = [] ;
  public expert :any ;
  public contentHeader : object ; 
  
  constructor(private expertService:ExpertService,private ar: ActivatedRoute) { }

  ngOnInit(): void {
    this.id=this.ar.snapshot.params.id;
    this.expertService.getExpertById(this.id).subscribe((data)=>{
      this.expert=data
    })

    this.expertService.getExpertSinisterNatures(this.id).subscribe((data)=>{
      this.expertsinisternatures=data
    })

    this.expertService.getExpertSpecialities(this.id).subscribe((data)=>{
      this.expertspecialities=data
    })
    this.contentHeader = {
      headerTitle: 'Expert',
      actionButton: false,
      breadcrumb: {
          type: '',
          links: [
              {
                  name: 'Home',
                  isLink: true,
                  link: '/'
              },
              {
                  name: 'Expert',
                  isLink: true,
                  link: '/apps/expert/list'
              },
              {
                  name: 'details',
                  isLink: false
              }
          ]
      }
    };
  } 
}
