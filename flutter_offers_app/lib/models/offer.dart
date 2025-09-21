class Offer {
  final int id;
  final String title;
  final String description;
  final int discountTypeId;
  final String discountValue;
  final DateTime validFrom;
  final DateTime validUntil;
  final int categoryId;
  final String? organizationName;
  final String? organizationNameEnglish;
  final String? directionsUrl;
  final double? rating;
  final int ratingCount;
  final int? dependentId;
  final String? imageUrl;
  final String name;
  final String? termsAndConditions;
  final int currentUses;
  final bool isActive;
  final DateTime? createdAt;
  final DateTime? updatedAt;

  // Related entities
  final OfferCategory? category;
  final DiscountType? discountType;
  final Dependent? dependent;
  final List<OfferLocation>? locations;
  final List<OfferPlatform>? platforms;
  final List<OfferSharingMethod>? sharingMethods;

  Offer({
    required this.id,
    required this.title,
    required this.description,
    required this.discountTypeId,
    required this.discountValue,
    required this.validFrom,
    required this.validUntil,
    required this.categoryId,
    this.organizationName,
    this.organizationNameEnglish,
    this.directionsUrl,
    this.rating,
    this.ratingCount = 0,
    this.dependentId,
    this.imageUrl,
    required this.name,
    this.termsAndConditions,
    this.currentUses = 0,
    this.isActive = true,
    this.createdAt,
    this.updatedAt,
    this.category,
    this.discountType,
    this.dependent,
    this.locations,
    this.platforms,
    this.sharingMethods,
  });

  factory Offer.fromJson(Map<String, dynamic> json) {
    return Offer(
      id: json['id'],
      title: json['title'],
      description: json['description'],
      discountTypeId: json['discountTypeId'],
      discountValue: json['discountValue'],
      validFrom: DateTime.parse(json['validFrom']),
      validUntil: DateTime.parse(json['validUntil']),
      categoryId: json['categoryId'],
      organizationName: json['organizationName'],
      organizationNameEnglish: json['organizationNameEnglish'],
      directionsUrl: json['directionsUrl'],
      rating: json['rating']?.toDouble(),
      ratingCount: json['ratingCount'] ?? 0,
      dependentId: json['dependentId'],
      imageUrl: json['imageUrl'],
      name: json['name'],
      termsAndConditions: json['termsAndConditions'],
      currentUses: json['currentUses'] ?? 0,
      isActive: json['isActive'] ?? true,
      createdAt: json['createdAt'] != null ? DateTime.parse(json['createdAt']) : null,
      updatedAt: json['updatedAt'] != null ? DateTime.parse(json['updatedAt']) : null,
      category: json['category'] != null ? OfferCategory.fromJson(json['category']) : null,
      discountType: json['discountType'] != null ? DiscountType.fromJson(json['discountType']) : null,
      dependent: json['dependent'] != null ? Dependent.fromJson(json['dependent']) : null,
      locations: json['locations'] != null 
          ? (json['locations'] as List).map((e) => OfferLocation.fromJson(e)).toList()
          : null,
      platforms: json['platforms'] != null 
          ? (json['platforms'] as List).map((e) => OfferPlatform.fromJson(e)).toList()
          : null,
      sharingMethods: json['sharingMethods'] != null 
          ? (json['sharingMethods'] as List).map((e) => OfferSharingMethod.fromJson(e)).toList()
          : null,
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'description': description,
      'discountTypeId': discountTypeId,
      'discountValue': discountValue,
      'validFrom': validFrom.toIso8601String(),
      'validUntil': validUntil.toIso8601String(),
      'categoryId': categoryId,
      'organizationName': organizationName,
      'organizationNameEnglish': organizationNameEnglish,
      'directionsUrl': directionsUrl,
      'rating': rating,
      'ratingCount': ratingCount,
      'dependentId': dependentId,
      'imageUrl': imageUrl,
      'name': name,
      'termsAndConditions': termsAndConditions,
      'currentUses': currentUses,
      'isActive': isActive,
      'createdAt': createdAt?.toIso8601String(),
      'updatedAt': updatedAt?.toIso8601String(),
    };
  }
}

class OfferCategory {
  final int id;
  final String name;
  final String? description;
  final String? icon;
  final bool isActive;

  OfferCategory({
    required this.id,
    required this.name,
    this.description,
    this.icon,
    this.isActive = true,
  });

  factory OfferCategory.fromJson(Map<String, dynamic> json) {
    return OfferCategory(
      id: json['id'],
      name: json['name'],
      description: json['description'],
      icon: json['icon'],
      isActive: json['isActive'] ?? true,
    );
  }
}

class DiscountType {
  final int id;
  final String name;
  final String? description;
  final String? icon;
  final bool isActive;

  DiscountType({
    required this.id,
    required this.name,
    this.description,
    this.icon,
    this.isActive = true,
  });

  factory DiscountType.fromJson(Map<String, dynamic> json) {
    return DiscountType(
      id: json['id'],
      name: json['name'],
      description: json['description'],
      icon: json['icon'],
      isActive: json['isActive'] ?? true,
    );
  }
}

class Dependent {
  final int id;
  final String relationship;
  final String relationshipEnglish;
  final bool isActive;

  Dependent({
    required this.id,
    required this.relationship,
    required this.relationshipEnglish,
    this.isActive = true,
  });

  factory Dependent.fromJson(Map<String, dynamic> json) {
    return Dependent(
      id: json['id'],
      relationship: json['relationship'],
      relationshipEnglish: json['relationshipEnglish'],
      isActive: json['isActive'] ?? true,
    );
  }
}

class OfferLocation {
  final int id;
  final String name;
  final String? address;
  final String? city;
  final String? state;
  final String? postalCode;
  final String? country;
  final double? latitude;
  final double? longitude;
  final bool isActive;

  OfferLocation({
    required this.id,
    required this.name,
    this.address,
    this.city,
    this.state,
    this.postalCode,
    this.country,
    this.latitude,
    this.longitude,
    this.isActive = true,
  });

  factory OfferLocation.fromJson(Map<String, dynamic> json) {
    return OfferLocation(
      id: json['id'],
      name: json['name'],
      address: json['address'],
      city: json['city'],
      state: json['state'],
      postalCode: json['postalCode'],
      country: json['country'],
      latitude: json['latitude']?.toDouble(),
      longitude: json['longitude']?.toDouble(),
      isActive: json['isActive'] ?? true,
    );
  }
}

class OfferPlatform {
  final int id;
  final String name;
  final String? description;
  final String? icon;
  final bool isActive;

  OfferPlatform({
    required this.id,
    required this.name,
    this.description,
    this.icon,
    this.isActive = true,
  });

  factory OfferPlatform.fromJson(Map<String, dynamic> json) {
    return OfferPlatform(
      id: json['id'],
      name: json['name'],
      description: json['description'],
      icon: json['icon'],
      isActive: json['isActive'] ?? true,
    );
  }
}

class OfferSharingMethod {
  final int id;
  final String name;
  final String? description;
  final String? type;
  final String? icon;
  final bool isActive;

  OfferSharingMethod({
    required this.id,
    required this.name,
    this.description,
    this.type,
    this.icon,
    this.isActive = true,
  });

  factory OfferSharingMethod.fromJson(Map<String, dynamic> json) {
    return OfferSharingMethod(
      id: json['id'],
      name: json['name'],
      description: json['description'],
      type: json['type'],
      icon: json['icon'],
      isActive: json['isActive'] ?? true,
    );
  }
}
