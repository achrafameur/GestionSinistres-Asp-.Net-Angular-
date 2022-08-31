import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChainService } from '../../chain/chain.service';
import { ChainDto } from '../../interfaces/chain';
import { ChainElementService } from '../chain-element.service';
import { locale as English } from '../../chain/i18n/en';
import { locale as Francais } from '../../chain/i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import { ChainElement } from '../../interfaces/chainElement';

@Component({
  selector: 'app-element-update',
  templateUrl: './element-update.component.html',
  styleUrls: ['./element-update.component.scss']
})
export class ElementUpdateComponent implements OnInit {
  Element:ChainElement
  chains:ChainDto[];
  public contentHeader: object;


  constructor(private elementService :ChainElementService ,private router:Router,private activatedroute :ActivatedRoute,private chainService:ChainService,private _coreTranslationService: CoreTranslationService) {
    this._coreTranslationService.translate(English,Francais);
   }

  ngOnInit(): void {
    this.chainService.loadChains().subscribe((data)=>{
      this.chains = data;
  })
  this.elementService.loadChainElementById(this.activatedroute.snapshot.params.id).subscribe(data => { this.Element= data; console.log(data)})
  this.contentHeader = {
    headerTitle: 'Modifier Element',
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
                name: 'Update',
                isLink: false
            }
        ]
    }
};
  
  }
  onUpdate (element:NgForm){
    this.elementService.updateChainElement(element.value,this.Element.chainElementId).subscribe({ 
      next:() => {
        console.log(element)
      this.router.navigate(["/apps/chain-element/list"])
    },
  error:(error) => {
    console.log(error); 
  }}); }
}
