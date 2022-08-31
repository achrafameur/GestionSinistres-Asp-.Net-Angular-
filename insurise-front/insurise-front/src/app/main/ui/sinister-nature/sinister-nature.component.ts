import { Component, OnInit, ViewChild } from '@angular/core';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { SinisterNatureService } from './sinister-nature.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";

@Component({
  selector: 'app-sinister-nature',
  templateUrl: './sinister-nature.component.html',
  styleUrls: ['./sinister-nature.component.scss']
})
export class SinisterNatureComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public tempData: any;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  columns = [ 
    {name: 'Id', prop: 'sinisterNatureId'},
    {name: 'Title', prop: 'title'},
    {name: 'Code', prop: 'code'},
    {name: 'Branch Id', prop: 'branch'},
    {name: 'Rank', prop: 'rank'},
    {name: 'Actions', prop: 'sinisterNatureId'} 
  ];
  @ViewChild(DatatableComponent) table: DatatableComponent;
  constructor(private sinisterNatureService : SinisterNatureService,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.sinisterNatureService.getSinisterNatures().subscribe((data)=>{
      this.kitchenSinkRows=data
      this.tempData=this.kitchenSinkRows
    })
  }

  delete(value){
    this.sinisterNatureService.DeleteSinisterNature(value).subscribe(()=>{
      this.sinisterNatureService.getSinisterNatures().subscribe((data)=>{
        this.kitchenSinkRows=data
      })
    })
  }

  
  filterUpdate(event){
    const val = event.target.value;
    this.kitchenSinkRows = this.tempData.filter(function (d) {
      return d.title.indexOf(val) !== -1 || !val;
  });
  }

}
