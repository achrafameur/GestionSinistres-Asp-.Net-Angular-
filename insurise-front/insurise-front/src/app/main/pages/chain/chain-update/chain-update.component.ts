import { Component, OnInit } from "@angular/core";
import { FormArray, FormBuilder, NgForm, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CoreTranslationService } from "@core/services/translation.service";
import Swal from "sweetalert2";
import { ChainDto } from "../../interfaces/chain";
import { ChainElement } from "../../interfaces/chainElement";
import { ChainService } from "../chain.service";
import { locale as English } from "../i18n/en";
import { locale as Francais } from "../i18n/fr";

@Component({
  selector: "app-chain-update",
  templateUrl: "./chain-update.component.html",
  styleUrls: ["./chain-update.component.scss"],
})
export class ChainUpdateComponent implements OnInit {
  Chain: ChainDto;
  public contentHeader: object;
  public Elements: ChainElement[];
  public elementList: string[];

  updateChainForm = this.fb.group({
    title: this.fb.control("", [Validators.required]),
    elements: this.fb.array([]),
  });

  get elements() {
    return this.updateChainForm.controls["elements"] as FormArray;
  }

  // addElement() {
  //   const elementForm = this.fb.group({
  //     title: ["", Validators.required],
  //   });
  //   this.elements.push(elementForm);
  // }

  deleteElement(elementIndex: number) {
    console.log(elementIndex);
    this.elements.removeAt(elementIndex);
  }

  // editForm = this.fb.group({
  //   chainId: [],
  //   title: [null, [Validators.required]],
  //   chainElements:this.fb.array([]),

  // });

  constructor(
    private chainService: ChainService,
    private activatedrouter: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(English, Francais);
  }

  ngOnInit(): void {
    this.chainService
      .loadChainById(this.activatedrouter.snapshot.params.id)
      .subscribe((data) => {
        this.Chain = data;
        console.log(data);
        this.Elements = data.elements;
        console.log(this.Elements);
      });

    // for (let index = 0; index < this.Elements.length; index++) {
    //   this.elementList.push(this.Elements[index].title)
    //   console.log(this.elementList)

    // }
    // this.activatedrouter.data.subscribe(({ chain }) => {
    //   this.updateForm(chain);
    this.contentHeader = {
      headerTitle: " Chain",
      actionButton: false,
      breadcrumb: {
        type: "",
        links: [
          {
            name: "Home",
            isLink: true,
            link: "/",
          },
          {
            name: "Chain",
            isLink: true,
            link: "/apps/chain/list",
          },
          {
            name: "Update",
            isLink: false,
          },
        ],
      },
    };
  }
  onUpdate(chain: NgForm) {
   
    console.log(this.elements)
    console.log (chain.value);
    this.chainService.updateChain(chain.value).subscribe({
      next: () => {
        console.log(chain.value);
        this.ConfirmTextOpen();
        this.router.navigate(["/apps/chain/list"]);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this chain!",
      icon: "success",
      confirmButtonColor: "#7367F0",
      cancelButtonColor: "#E42728",
      // confirmButtonText: 'Ok',
      customClass: {
        confirmButton: "btn btn-success",
        cancelButton: "btn btn-danger ml-1",
      },
    }).then((result) => {
      if (result) {
        // this.add();
      }
    });
  }
  // onUpdate(chain:NgForm){
  //   this.chainService.updateChain(chain.value,this.Chain.chainId).subscribe({
  //     next:() => {   console.log(chain)
  //       this.router.navigate(["/pages/chain/list"])},
  //       error:(error) => {
  //         console.log(error);
  //       }}); }

  // test
  // protected updateForm(Chain: ChainDto): void {
  //   this.editForm.patchValue({
  //     chainId :Chain.chainId,
  //     title: Chain.title,
  //     chainElements: Chain.chainElements,

  //   });

  //fin test
}
