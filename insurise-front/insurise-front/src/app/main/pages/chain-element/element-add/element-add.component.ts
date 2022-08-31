import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { ChainService } from '../../chain/chain.service';
import { ChainElementService } from '../chain-element.service';
import { locale as English } from '../../chain/i18n/en';
import { locale as Francais } from '../../chain/i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import { ChainElement } from '../../interfaces/chainElement';

@Component({
  selector: 'app-element-add',
  templateUrl: './element-add.component.html',
  styleUrls: ['./element-add.component.scss']
})
export class ElementAddComponent implements OnInit {

  public contentHeader: object;

  public elements:ChainElement; 
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: ChainElement;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  form:FormGroup;
  chainList :any;

  constructor(private elementService:ChainElementService,private chainService:ChainService, private router:Router,private formBuilder:FormBuilder,private _coreTranslationService: CoreTranslationService) { 
    this._coreTranslationService.translate(English,Francais);
  }

  addElementForm = new FormGroup({
    title: new FormControl('', [
      Validators.required,
    ]),
    chainId: new  FormControl('') ,
  })
  ngOnInit(): void {
    this.chainService.loadChains().subscribe((data)=>{
      this.chainList=data;

    })
    this.contentHeader = {
      headerTitle: 'Ajouter Element',
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
                  name: 'Element',
                  isLink: true,
                  link: '/apps/chain-element/list'
              },
              {
                  name: 'Add',
                  isLink: false
              }
          ]
      }
  };
  }
  onSubmit() {
  
    if (this.addElementForm.valid) {
      console.log("Excecute create service", this.addElementForm.value);
      this.elementService.addChainElement(this.addElementForm.value).subscribe({
        next: () => {
            this.router.navigate(["/apps/chain-element/list"])
        },
        error: (err) => {
          console.log(err)
        }
      });
    }
  
  }

}
