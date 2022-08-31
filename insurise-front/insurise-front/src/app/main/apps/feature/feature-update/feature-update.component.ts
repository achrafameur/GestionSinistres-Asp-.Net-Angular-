import { Chain } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ArticleService } from 'app/main/pages/article/article.service';
import { ChainService } from 'app/main/pages/chain/chain.service';
import { ChainDto } from 'app/main/pages/interfaces/chain';
import { FeatureDto } from 'app/main/pages/interfaces/feature';
import { Item } from 'app/main/pages/interfaces/item';
import { Nature } from 'app/main/pages/interfaces/nature';
import { NatureService } from 'app/main/pages/nature/nature.service';
import Swal from 'sweetalert2';
import { FeatureService } from '../feature.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-feature-update',
  templateUrl: './feature-update.component.html',
  styleUrls: ['./feature-update.component.scss']
})
export class FeatureUpdateComponent implements OnInit {
  Feature : FeatureDto ;
  natures:Nature[] ;
  chains:ChainDto[];
  articleList:Item[];
  id:any;
  public contentHeader: object;

  constructor(protected fb: FormBuilder,private router:Router,private articleService :ArticleService ,private featureService:FeatureService,private natureService :NatureService, private activatedroute :ActivatedRoute,private chainService:ChainService,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }

  ngOnInit(): void {
  
    
    this.natureService.loadNatures().subscribe((data)=>{
      this.natures=data;
      this.chainService.loadChains().subscribe((data)=>{
        this.chains = data;
        this.articleService.loadItems().subscribe((data)=>{
          this.articleList=data;
        })
      })
    })
    this.featureService.loadFeatureById(this.activatedroute.snapshot.params.id).subscribe(data => { this.Feature= data; console.log(data)})
    this.contentHeader = {
      headerTitle: ' Feature',
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
                  name: 'Feature',
                  isLink: true,
                  link: '/apps/feature/list'
              },
              {
                  name: 'Update',
                  isLink: false
              }
          ]
      }
  };
  }
  onUpdate (feature:NgForm){
    this.featureService.updateFeature(feature.value,this.Feature.featureId).subscribe({ 
      next:() => {
        console.log(feature)
        this.ConfirmTextOpen();
      this.router.navigate(["/apps/feature/list"])
    },
  error:(error) => {
    console.log(error); 
  }}); }

  getNatureValue(id:string){
    this.id=(this.Feature.natureId) ;
    
    for (let i = 0; i < this.natures.length; i++) {
      if(this.natures[i].id == Number.parseInt(id)){
        return this.natures[i].isList
      }
      
    }
    }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully updated this feature!",
      icon: 'success',
      confirmButtonColor: '#7367F0',
      cancelButtonColor: '#E42728',
      // confirmButtonText: 'Ok',
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger ml-1'
      }
    }).then((result) =>{
      if (result) {
        // this.add();
      }
    });
  }
}
