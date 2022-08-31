import { Chain } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ExpertService } from '../../expert/expert.service';
import { ExpertSpec } from '../../expert/models/ExpertSpec';
import { Feature } from '../models/Feature';
import { MandatoryDocument } from '../models/MandatoryDocument';
import { SinisterNatureService } from '../sinister-nature.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { NgForm } from '@angular/forms';
import { selectedMandatoryDocument } from '../models/selectedMandatoryDocument';
import { selectedSpeciality } from '../models/selectedSpecialities';

@Component({
  selector: 'app-sinister-details-view',
  templateUrl: './sinister-details-view.component.html',
  styleUrls: ['./sinister-details-view.component.scss']
})
export class SinisterDetailsViewComponent implements OnInit {
  public id:any
  public isGotFeature : boolean = false; 
  public isGotSpeciality : boolean = false; 
  public sinisterNatureSpecialities = [] ;
  public sinisterNatureFeatures = [] ;
  public Features : Feature[]=[] ;
  public sinNatFeatures : any ; 
  public Specialities : selectedSpeciality[] =[];
  public chains : any ; 
  public Feature : any ;
  public Speciality : any ;
  public selectedSinisterNature : any ;
  // public chainElements : Chain[]=[] ;
  public chainsElements : ExpertSpec[] =[];
  public chainElmId : any ; 
  public chainElmIds : any ; 
  public featureId:any ; 
  public featureIds:any 
  public mandatoryDocuments : MandatoryDocument[] =[]; 
  public documentId:any ;
  public documentIds:any 
  public sinisterNatureMandatoryDocuments = [] ;
  public sinDocuments : selectedMandatoryDocument[] =[]; 
  public contentHeader : object ; 

  constructor(private ar : ActivatedRoute, 
    private sinisterNatureService : SinisterNatureService, 
    private expertService : ExpertService,
    private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
    { 
      this._coreTranslationService.translate(english, french);
    }

  ngOnInit(): void {
    this.id=this.ar.snapshot.params.id;
    this.sinisterNatureService.getSinisterNatureById(this.id).subscribe((data)=>{
      this.selectedSinisterNature=data
    })
    
    // Specialities Section
    this.expertService.getChains().subscribe((data)=>{
      this.chains=data
          // for (let i = 0; i < this.chains.length; i++) {
          //   if (this.chains[i].title === 'specialities') {
          //     for (let x = 0; x < this.chains[i].elements.length; x++) {
          //       for (let j = 0; j < this.Specialities.length; j++) {
          //         this.Specialities[j].isChecked=true
          //         if (this.Specialities[j].chainElementId===this.chains[i].elements[x].chainElementId) {
          //           this.chains[i].elements[x].isChecked=true
          //           console.log(this.chains[i].elements)
          //         }
          //       } 
          //     }
          //   }
          // }
      console.log(this.chains)
    })
    this.sinisterNatureService.getSinisterNatureSpecialities(this.id).subscribe((data)=>{
      this.Specialities=data
      // for (let i = 0; i < this.Specialities.length; i++) {
      //   this.Specialities[i].isChecked=true
      // }
      console.log(this.Specialities)
    })
    this.expertService.getChainsElements().subscribe((data)=>{
      this.chainsElements=data
      console.log(this.chainsElements)
    })
    
    // Features Section
    this.sinisterNatureService.getFeatures().subscribe((data)=>{
      this.Features=data
    })
    this.sinisterNatureService.getSinisterNatureFeatures(this.id).subscribe((data)=>{
      this.sinNatFeatures=data
      console.log(this.sinNatFeatures)
    })

    // Mandatory Documents Section
    this.sinisterNatureService.getAllMandatoryDocuments().subscribe((data)=>{
      this.mandatoryDocuments=data
      // console.log(this.mandatoryDocuments)
    })
    this.sinisterNatureService.getSinisterNatureMandatoryDocuments(this.id).subscribe((data)=>{
      this.sinDocuments=data
      // console.log(this.sinDocuments)
    })

    this.contentHeader = {
      headerTitle: 'SinisterNature',
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
                  name: 'SinisterNature',
                  isLink: true,
                  link: '/apps/sinisterNature/list'
              },
              {
                  name: 'details',
                  isLink: false
              }
          ]
      }
    };
  }

  attachFeatures(SinisterNatureFeature:NgForm){
    this.featureId=this.Features.filter(x=>x.isChecked==true).map(x=>x.featureId).toString();
    console.log(this.featureId)
    this.featureIds=this.featureId.split(',');
    console.log(this.featureId)
    for (let i = 0; i < this.featureIds.length; i++) {
      if (SinisterNatureFeature.value.featureId == true) {
        this.sinisterNatureFeatures.push({
          "featureId":this.featureIds[i],
        });
      }
    }
    this.sinisterNatureService.setFeatures(this.sinisterNatureFeatures,this.id).subscribe(()=>{
      window.location.reload();
    })
  }

  attachSpecialities(SinisterNatureSpecialities:NgForm){
    for (let i = 0; i < this.chains.length; i++) {
      if  (this.chains[i].title == 'specialities'){
        this.chainElmId=this.chains[i].elements.filter(x=>x.isChecked==true).map(x=>x.chainElementId).toString();
        // console.log(this.chainElmId)
        this.chainElmIds = this.chainElmId.split(',');
        // console.log(this.chainElmIds)
        for (let i = 0; i < this.chainElmIds.length; i++) {
          if (SinisterNatureSpecialities.value.chainElementId == true) {
            this.sinisterNatureSpecialities.push({
              "chainElementId":this.chainElmIds[i],
            });  
          } 
        }
      } 
    }
    this.sinisterNatureService.setSinisterNatureSpecialities(this.sinisterNatureSpecialities,this.id).subscribe(()=>{
      window.location.reload();
    })
  }

  attachMandatoryDocuments(SinisterNatureMandatoryDocuments:NgForm){
    this.documentId=this.mandatoryDocuments.filter(x=>x.isChecked==true).map(x=>x.mandatoryDocumentId).toString();
    console.log(this.documentId)
    this.documentIds=this.documentId.split(',');
    for (let i = 0; i < this.documentIds.length; i++) {
      if (SinisterNatureMandatoryDocuments.value.mandatoryDocumentId == true) {
        this.sinisterNatureMandatoryDocuments.push({
          "mandatoryDocumentId":this.documentIds[i],
        });
      }
    }
    this.sinisterNatureService.setSinisterNatureMandatoryDocuments(this.sinisterNatureMandatoryDocuments,this.id).subscribe(()=>{
      window.location.reload();
    })
  }

  addEvaluationFormula(EvaluationFormula:NgForm){
    this.selectedSinisterNature.formulaEvaluationId=EvaluationFormula.value.formulaEvaluationId;
    console.log(this.selectedSinisterNature)
    this.sinisterNatureService.updateSinisterNature(this.selectedSinisterNature,this.id).subscribe(()=>{
      window.location.reload();
    });
  }

  addFeesFormula(FeesFormula:NgForm){
    this.selectedSinisterNature.formulaFeesId=FeesFormula.value.formulaFeesId;
    console.log(this.selectedSinisterNature)
    this.sinisterNatureService.updateSinisterNature(this.selectedSinisterNature,this.id).subscribe(()=>{
      window.location.reload();
    });
  }
  
  onChange(){
    console.log(this.chains)
    console.log(this.chainsElements)
  }
  onChangeFeature(){
    console.log(this.Features)
  }
  onChangeMandatoryDocument(){
    console.log(this.mandatoryDocuments)
  }


  modalOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }

  modalFeaturesOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }

  modalMandatoryDocumentsOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }

  modalFormulaOpenForm(modalFormula) {
    this.modalService.open(modalFormula);
  }

  modalFeesFormulaOpenForm(modalFeesFormula){
    this.modalService.open(modalFeesFormula);
  }

  // compareSpecialities(){
  //   for (let i = 0; i < this.chains.length; i++) {
  //     if (this.chains[i].title === 'specialities') {
  //       for (let x = 0; x < this.chains[i].elements.length; x++) {
  //         for (let j = 0; j < this.Specialities.length; j++) {
  //           if (this.Specialities[j].chainElementId===this.chains[i].elements[x].chainElementId) {
  //             this.chains[i].elements[x].isChecked=true
  //             console.log(this.chains[i].elements)
  //           }
  //         } 
  //       }
  //     }
  //   }
  //   console.log(this.chains)
  //   console.log(this.chainsElements)
  // }

}
